using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RyvenTweaker.Models;
using RyvenTweaker.Services;
namespace RyvenTweaker;
public partial class MainWindow : Window
{
    private readonly HardwareDetector _hardwareDetector=new();
    private readonly TweakEngine _tweakEngine=new();
    private readonly Logger _logger=new();
    private string _currentCategory="Overview";
    public MainWindow()
    {
        InitializeComponent();
        foreach(var tweak in TweakFactory.CreateDefaultTweaks()) _tweakEngine.Register(tweak);
        _tweakEngine.TweakStatusChanged += t=>_logger.Info($"{t.Id}: {t.Status}");
        ShowPage("Overview","Browse real Windows settings and reversible actions.");
    }
    private void ScanButton_Click(object sender,RoutedEventArgs e)
    {
        try { StatusText.Text="SCANNING"; CpuText.Text=_hardwareDetector.GetProcessor(); GpuText.Text=_hardwareDetector.GetGraphicsCard(); RamText.Text=_hardwareDetector.GetMemory(); StatusText.Text="SCAN COMPLETE"; }
        catch(Exception ex) { StatusText.Text="SCAN ERROR"; _logger.Error(ex.Message); MessageBox.Show(ex.Message,"Hardware scan"); }
    }
    private void ShowPage(string category,string description)
    {
        _currentCategory=category; PageTitle.Text=category=="Overview"?"Performance Center":category;
        PageDescription.Text=description; SearchBox.Text=""; RefreshTweakList();
    }
    private void RefreshTweakList()
    {
        if(TweakList is null || SearchBox is null) return;
        var query=SearchBox.Text.Trim();
        var tweaks=_tweakEngine.Tweaks.Where(t=>_currentCategory=="Overview" || t.Category.Equals(_currentCategory,StringComparison.OrdinalIgnoreCase))
        .Where(t=>string.IsNullOrEmpty(query) || t.Name.Contains(query,StringComparison.OrdinalIgnoreCase) || t.Description.Contains(query,StringComparison.OrdinalIgnoreCase) || t.Category.Contains(query,StringComparison.OrdinalIgnoreCase)).ToList();
        TweakList.ItemsSource=null; TweakList.ItemsSource=tweaks;
        EmptyStateText.Visibility=tweaks.Count==0?Visibility.Visible:Visibility.Collapsed;
    }
    private void RunAction(object sender,bool undo)
    {
        if(sender is not Button b || b.Tag is not string id) return;
        try
        {
            if(undo) _tweakEngine.Undo(id);
            else
            {
                if(MessageBox.Show($"Apply { _tweakEngine.Find(id)?.Name }?\n\nUndo is only available before closing this app. Some changes may need sign out to take effect.","Confirm tweak",MessageBoxButton.YesNo,MessageBoxImage.Question)!=MessageBoxResult.Yes) return;
                _tweakEngine.Apply(id);
            }
            StatusText.Text=undo?"UNDONE":"APPLIED"; RefreshTweakList();
        }
        catch(Exception ex) { _logger.Error(ex.ToString()); MessageBox.Show(ex.Message,"Ryven Tweaker",MessageBoxButton.OK,MessageBoxImage.Warning); }
    }
    private void Apply_Click(object sender,RoutedEventArgs e)=>RunAction(sender,false);
    private void Undo_Click(object sender,RoutedEventArgs e)=>RunAction(sender,true);
    private void OverviewButton_Click(object sender,RoutedEventArgs e)=>ShowPage("Overview","Browse all available optimization options.");
    private void WindowsButton_Click(object sender,RoutedEventArgs e)=>ShowPage("Windows","Windows settings and visual effects.");
    private void HardwareButton_Click(object sender,RoutedEventArgs e)=>ShowPage("CPU & RAM","Processor and memory options.");
    private void GpuButton_Click(object sender,RoutedEventArgs e)=>ShowPage("GPU","Graphics optimization options.");
    private void NetworkButton_Click(object sender,RoutedEventArgs e)=>ShowPage("Network","Network settings and diagnostics.");
    private void InputButton_Click(object sender,RoutedEventArgs e)=>ShowPage("Input","Mouse and input settings.");
    private void GamesButton_Click(object sender,RoutedEventArgs e)=>ShowPage("Gaming","Gaming settings and profiles.");
    private void SearchBox_TextChanged(object sender,TextChangedEventArgs e)=>RefreshTweakList();
}
