using RyvenTweaker.Models;
namespace RyvenTweaker.Services;
public static class TweakFactory
{
    public static List<Tweak> CreateDefaultTweaks() => new()
    {
        new() { Id="windows.game-mode", Name="Windows Game Mode", Category="Windows", Description="Enable Windows Game Mode for the current user.", ExpectedBenefit="May improve gaming workload scheduling; results vary.", Risk=TweakRisk.Low },
        new() { Id="windows.transparency", Name="Disable Transparency Effects", Category="Windows", Description="Disable acrylic and transparency effects for the current user.", ExpectedBenefit="Slightly reduces desktop visual overhead.", Risk=TweakRisk.Low },
        new() { Id="input.mouse-acceleration", Name="Disable Mouse Acceleration", Category="Input", Description="Disable Enhance Pointer Precision for Windows cursor movement.", ExpectedBenefit="More consistent Windows pointer movement; games using raw input may be unaffected.", Risk=TweakRisk.Low },
        new() { Id="windows.gamebar-capture", Name="Disable App Capture", Category="Windows", Description="Disable Windows app capture for the current user.", ExpectedBenefit="May avoid unwanted background recording.", Risk=TweakRisk.Low },
        new() { Id="windows.gamebar-dvr", Name="Disable Game DVR", Category="Gaming", Description="Turn off Windows Game DVR recording flag.", ExpectedBenefit="May reduce recording overhead when not used.", Risk=TweakRisk.Low },
        new() { Id="windows.animations", Name="Disable Window Animations", Category="Windows", Description="Turn off window minimize and maximize animations.", ExpectedBenefit="Changes desktop responsiveness, not game FPS.", Risk=TweakRisk.Low },
        new() { Id="windows.taskbar-animation", Name="Disable Taskbar Animations", Category="Windows", Description="Turn off taskbar animations.", ExpectedBenefit="Slightly simpler desktop transitions.", Risk=TweakRisk.Low },
        new() { Id="windows.menu-delay", Name="Shorter Menu Delay", Category="Windows", Description="Set menu hover delay to 100 ms.", ExpectedBenefit="Menus may feel more responsive.", Risk=TweakRisk.Low },
        new() { Id="windows.dark-apps", Name="Dark App Theme", Category="Windows", Description="Use dark mode for supported Windows apps.", ExpectedBenefit="Appearance only.", Risk=TweakRisk.Low },
        new() { Id="windows.dark-system", Name="Dark System Theme", Category="Windows", Description="Use dark mode for Windows shell surfaces.", ExpectedBenefit="Appearance only.", Risk=TweakRisk.Low },
        new() { Id="windows.show-extensions", Name="Show File Extensions", Category="Windows", Description="Show known file extensions in File Explorer.", ExpectedBenefit="Makes file types easier to identify.", Risk=TweakRisk.Low },
        new() { Id="windows.show-hidden", Name="Show Hidden Files", Category="Windows", Description="Show hidden files in File Explorer.", ExpectedBenefit="Useful for advanced users; be careful editing system files.", Risk=TweakRisk.Low },
        new() { Id="windows.snap-assist", Name="Disable Snap Suggestions", Category="Windows", Description="Turn off Snap Assist suggestions.", ExpectedBenefit="Less desktop UI interruption.", Risk=TweakRisk.Low },
        new() { Id="windows.start-recommendations", Name="Reduce Start Recommendations", Category="Windows", Description="Disable supported Start recommendations flag.", ExpectedBenefit="Less Start menu clutter on supported builds.", Risk=TweakRisk.Low },
        new() { Id="windows.search-highlights", Name="Disable Search Highlights", Category="Windows", Description="Turn off dynamic search box highlights.", ExpectedBenefit="Less distracting taskbar search UI.", Risk=TweakRisk.Low },
        new() { Id="windows.visual-effects", Name="Visual Effects Review", Category="Windows", Description="Manual review recommended; not automatically modified.", ExpectedBenefit="No automatic change.", Risk=TweakRisk.Medium, IsCompatible=false, Status="Manual review" },
        new() { Id="gaming.fullscreen", Name="Fullscreen Optimization Review", Category="Gaming", Description="Per-game compatibility settings need an explicit game executable.", ExpectedBenefit="No automatic change.", Risk=TweakRisk.Medium, IsCompatible=false, Status="Manual review" }
    };
}
