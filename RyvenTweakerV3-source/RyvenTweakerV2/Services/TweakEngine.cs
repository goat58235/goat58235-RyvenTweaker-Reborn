using Microsoft.Win32;
using RyvenTweaker.Models;
namespace RyvenTweaker.Services;
public sealed class TweakEngine
{
    private readonly Dictionary<string,Tweak> _tweaks = new();
    private readonly Dictionary<string,List<(string path,string name,object? old,RegistryValueKind kind)>> _backup = new();
    public IReadOnlyCollection<Tweak> Tweaks => _tweaks.Values;
    public event Action<Tweak>? TweakStatusChanged;
    public void Register(Tweak tweak) => _tweaks.Add(tweak.Id,tweak);
    public Tweak? Find(string id) => _tweaks.GetValueOrDefault(id);
    private static List<(string path,string name,object value)> Changes(string id) => id switch
    {
        "windows.game-mode" => new() { (@"Software\Microsoft\GameBar","AutoGameModeEnabled",1) },
        "windows.transparency" => new() { (@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize","EnableTransparency",0) },
        "input.mouse-acceleration" => new() { (@"Control Panel\Mouse","MouseSpeed","0"),(@"Control Panel\Mouse","MouseThreshold1","0"),(@"Control Panel\Mouse","MouseThreshold2","0") },
        "windows.gamebar-capture" => new() { (@"Software\Microsoft\Windows\CurrentVersion\GameDVR","AppCaptureEnabled",0) },
        "windows.gamebar-dvr" => new() { (@"System\GameConfigStore","GameDVR_Enabled",0) },
        "windows.animations" => new() { (@"Control Panel\Desktop\WindowMetrics","MinAnimate","0") },
        "windows.taskbar-animation" => new() { (@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced","TaskbarAnimations",0) },
        "windows.menu-delay" => new() { (@"Control Panel\Desktop","MenuShowDelay","100") },
        "windows.dark-apps" => new() { (@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize","AppsUseLightTheme",0) },
        "windows.dark-system" => new() { (@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize","SystemUsesLightTheme",0) },
        "windows.show-extensions" => new() { (@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced","HideFileExt",0) },
        "windows.show-hidden" => new() { (@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced","Hidden",1) },
        "windows.snap-assist" => new() { (@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced","SnapAssist",0) },
        "windows.start-recommendations" => new() { (@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced","Start_IrisRecommendations",0) },
        "windows.search-highlights" => new() { (@"Software\Microsoft\Windows\CurrentVersion\SearchSettings","IsDynamicSearchBoxEnabled",0) },
        _ => new()
    };
    public void Apply(string id)
    {
        var tweak=Find(id) ?? throw new InvalidOperationException("Tweak not found");
        if(!tweak.IsCompatible) throw new InvalidOperationException("This tweak is manual review only");
        if(_backup.ContainsKey(id)) throw new InvalidOperationException("Already applied this session");
        var changes=Changes(id);
        if(changes.Count==0) throw new InvalidOperationException("No supported action");
        var originals=new List<(string path,string name,object? old,RegistryValueKind kind)>();
        try
        {
            foreach(var c in changes)
            {
                using var key=Registry.CurrentUser.CreateSubKey(c.path,true) ?? throw new InvalidOperationException("Cannot open registry key");
                var old=key.GetValue(c.name,null,RegistryValueOptions.DoNotExpandEnvironmentNames);
                var kind=old is null ? RegistryValueKind.None : key.GetValueKind(c.name);
                originals.Add((c.path,c.name,old,kind));
                key.SetValue(c.name,c.value,c.value is string ? RegistryValueKind.String : RegistryValueKind.DWord);
            }
            _backup[id]=originals;
            tweak.IsApplied=true; tweak.Status="Applied this session"; TweakStatusChanged?.Invoke(tweak);
        }
        catch
        {
            Restore(originals);
            throw;
        }
    }
    private static void Restore(IEnumerable<(string path,string name,object? old,RegistryValueKind kind)> originals)
    {
        foreach(var c in originals.Reverse())
        {
            using var key=Registry.CurrentUser.CreateSubKey(c.path,true) ?? throw new InvalidOperationException("Cannot open registry key");
            if(c.old is null) key.DeleteValue(c.name,false);
            else key.SetValue(c.name,c.old,c.kind);
        }
    }
    public void Undo(string id)
    {
        if(!_backup.TryGetValue(id,out var originals)) throw new InvalidOperationException("Undo is only available in the same app session");
        Restore(originals);
        _backup.Remove(id);
        var tweak=Find(id)!; tweak.IsApplied=false; tweak.Status="Not applied"; TweakStatusChanged?.Invoke(tweak);
    }
}
