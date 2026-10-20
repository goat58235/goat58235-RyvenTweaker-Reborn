
using System;
using System.Windows;
using System.Windows.Controls;

namespace RyvenTweaker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StatusText.Text = "READY";
            CpuText.Text = Environment.GetEnvironmentVariable(
                "PROCESSOR_IDENTIFIER") ?? "Not detected";

            GpuText.Text = "Not scanned";
            RamText.Text = "Not scanned";

            PageTitle.Text = "Performance Center";
            PageDescription.Text =
                "Welcome to Ryven Tweaker. Scan your PC to begin.";
            SearchBox.Text = "";
        }

        private void ScanButton_Click(object sender, RoutedEventArgs e)
        {
            CpuText.Text = Environment.GetEnvironmentVariable(
                "PROCESSOR_IDENTIFIER") ?? "Unknown";

            GpuText.Text = "Hardware scan coming next";
            RamText.Text = "Hardware scan coming next";
            StatusText.Text = "BASIC SCAN COMPLETE";

            PageDescription.Text =
                "Basic processor information loaded. Full hardware detection is coming next.";
        }

        private void ShowPage(string title, string description)
        {
            PageTitle.Text = title;
            PageDescription.Text = description;
            TweakList.ItemsSource = null;
            EmptyStateText.Visibility = Visibility.Visible;
            EmptyStateText.Text =
                "Tools for this category will be added in the next steps.";
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
            object sender, TextChangedEventArgs e)
        {
            if (EmptyStateText != null && TweakList != null)
            {
                string query = SearchBox.Text.Trim();

                if (TweakList.ItemsSource == null)
                {
                    EmptyStateText.Text = string.IsNullOrWhiteSpace(query)
                        ? "Tools for this category will be added in the next steps."
                        : "No tools have been added yet. Search will work when tools are available.";
                }
            }
        }
    }
}
