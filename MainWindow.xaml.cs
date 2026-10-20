
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RyvenTweaker.Models;
using RyvenTweaker.Services;

namespace RyvenTweaker
{
    public partial class MainWindow : Window
    {
        private readonly HardwareDetector _hardwareDetector = new();
        private readonly TweakEngine _tweakEngine = new();
        private readonly Logger _logger = new();
        private string _currentCategory = "Overview";

        public MainWindow()
        {
            InitializeComponent();

            StatusText.Text = "READY";
            CpuText.Text = "Not scanned";
            GpuText.Text = "Not scanned";
            RamText.Text = "Not scanned";

            foreach (Tweak tweak in TweakFactory.CreateDefaultTweaks())
            {
                _tweakEngine.Register(tweak);
            }

            _tweakEngine.TweakStatusChanged += tweak =>
            {
                _logger.Info($"Tweak '{tweak.Id}' status: {tweak.Status}");
            };

            ShowPage(
                "Overview",
                "Your dashboard for gaming performance and optimization."
            );
        }

        private void ScanButton_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "SCANNING...";

            try
            {
                CpuText.Text = _hardwareDetector.GetProcessor();
                GpuText.Text = _hardwareDetector.GetGraphicsCard();
                RamText.Text = _hardwareDetector.GetMemory();

                StatusText.Text = "SCAN COMPLETE";
                _logger.Info("Hardware scan completed.");
            }
            catch (Exception ex)
            {
                StatusText.Text = "SCAN ERROR";
                _logger.Error($"Hardware scan failed: {ex.Message}");

                MessageBox.Show(
                    "Hardware scanning failed:\n" + ex.Message,
                    "Ryven Tweaker",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
            }
        }

        private void ShowPage(string category, string description)
        {
            _currentCategory = category;

            PageTitle.Text = category == "Overview"
                ? "Performance Center"
                : category;

            PageDescription.Text = description;
            SearchBox.Text = string.Empty;
            RefreshTweakList();
        }

        private void RefreshTweakList()
        {
            string query = SearchBox.Text.Trim();

            var tweaks = _tweakEngine.Tweaks
                .Where(t =>
                    _currentCategory == "Overview" ||
                    t.Category.Equals(
                        _currentCategory,
                        StringComparison.OrdinalIgnoreCase
                    )
                )
                .Where(t =>
                    string.IsNullOrWhiteSpace(query) ||
                    t.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    t.Description.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    t.Category.Contains(query, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();

            TweakList.ItemsSource = tweaks;

            EmptyStateText.Visibility = tweaks.Count == 0
                ? Visibility.Visible
                : Visibility.Collapsed;

            EmptyStateText.Text = "No matching tweaks in this category.";
        }

        private void OverviewButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(
                "Overview",
                "Browse all available optimization options."
            );
        }

        private void WindowsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(
                "Windows",
                "Windows settings and visual effects."
            );
        }

        private void HardwareButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(
                "CPU & RAM",
                "Processor and memory optimization options."
            );
        }

        private void GpuButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(
                "GPU",
                "Graphics optimization options."
            );
        }

        private void NetworkButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(
                "Network",
                "Network diagnostics and connection settings."
            );
        }

        private void InputButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(
                "Input",
                "Mouse and input settings."
            );
        }

        private void GamesButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(
                "Gaming",
                "Gaming settings and profiles."
            );
        }

        private void SearchBox_TextChanged(
            object sender,
            TextChangedEventArgs e
        )
        {
            if (TweakList != null && SearchBox != null)
            {
                RefreshTweakList();
            }
        }
    }
}
