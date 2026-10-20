
using System;
using System.Windows;
using System.Windows.Controls;
using RyvenTweaker.Services;

namespace RyvenTweaker
{
    public partial class MainWindow : Window
    {
        private readonly HardwareDetector _hardwareDetector = new();

        public MainWindow()
        {
            InitializeComponent();

            StatusText.Text = "READY";
            CpuText.Text = "Not scanned";
            GpuText.Text = "Not scanned";
            RamText.Text = "Not scanned";

            PageTitle.Text = "Performance Center";
            PageDescription.Text =
                "Scan your PC to identify your hardware and explore optimization options.";

            SearchBox.Text = string.Empty;
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
                PageDescription.Text =
                    "Hardware scan finished. Detected specifications are shown above.";
            }
            catch (Exception ex)
            {
                StatusText.Text = "SCAN ERROR";

                MessageBox.Show(
                    "Hardware scanning failed:\n" + ex.Message,
                    "Ryven Tweaker",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void ShowPage(string title, string description)
        {
            PageTitle.Text = title;
            PageDescription.Text = description;
            TweakList.ItemsSource = null;

            EmptyStateText.Visibility = Visibility.Visible;
            EmptyStateText.Text =
                "Tools for this category will be added as they are implemented.";

            SearchBox.Text = string.Empty;
        }

        private void OverviewButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(
                "Performance Center",
                "Your dashboard for gaming performance and system optimization.");
        }

        private void WindowsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(
                "Windows Optimization",
                "Windows settings, visual effects, and gaming features.");
        }

        private void HardwareButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(
                "CPU & RAM",
                "Processor information, memory, and compatible settings.");
        }

        private void GpuButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(
                "Graphics Optimization",
                "GPU detection and graphics settings for supported hardware.");
        }

        private void NetworkButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(
                "Network Optimization",
                "Connection diagnostics and carefully tested network settings.");
        }

        private void InputButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(
                "Input & Mouse",
                "Mouse settings and input consistency options.");
        }

        private void GamesButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(
                "Game Profiles",
                "Profiles for supported games and different PC configurations.");
        }

        private void SearchBox_TextChanged(
            object sender,
            TextChangedEventArgs e)
        {
            if (EmptyStateText == null || TweakList == null ||
                SearchBox == null)
            {
                return;
            }

            string query = SearchBox.Text.Trim();

            if (TweakList.ItemsSource == null)
            {
                EmptyStateText.Visibility = Visibility.Visible;
                EmptyStateText.Text = string.IsNullOrWhiteSpace(query)
                    ? "Tools for this category will be added as they are implemented."
                    : "No matching tools yet. Search will work when optimization tools are added.";
            }
        }
    }
}
