using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DualSenseRed
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppendLog("Application started.");
        }

        private void Nav_Checked(object sender, RoutedEventArgs e)
        {
            if (!IsLoaded) return;

            PageDashboard.Visibility = Visibility.Collapsed;
            PageController.Visibility = Visibility.Collapsed;
            PageProfiles.Visibility = Visibility.Collapsed;
            PageSettings.Visibility = Visibility.Collapsed;

            if (NavDashboard.IsChecked == true)
                PageDashboard.Visibility = Visibility.Visible;
            else if (NavController.IsChecked == true)
                PageController.Visibility = Visibility.Visible;
            else if (NavProfiles.IsChecked == true)
                PageProfiles.Visibility = Visibility.Visible;
            else if (NavSettings.IsChecked == true)
                PageSettings.Visibility = Visibility.Visible;

            UpdateNavColors();
        }

        private void UpdateNavColors()
        {
            var active = (Brush)FindResource("RedPrimary");
            var inactive = (Brush)FindResource("TextGray");

            NavDashboard.Foreground = NavDashboard.IsChecked == true ? active : inactive;
            NavController.Foreground = NavController.IsChecked == true ? active : inactive;
            NavProfiles.Foreground = NavProfiles.IsChecked == true ? active : inactive;
            NavSettings.Foreground = NavSettings.IsChecked == true ? active : inactive;
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            TxtStatus.Text = "CONNECTED";
            TxtStatus.Foreground = (Brush)FindResource("RedGlow");
            DotConnection.Fill = (Brush)FindResource("RedPrimary");
            TxtConnection.Text = "DualSense connected";
            TxtStatusBar.Text = "Controller connected successfully.";
            AppendLog("[CONNECT] DualSense controller detected.");
        }

        private void BtnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            TxtStatus.Text = "DISCONNECTED";
            TxtStatus.Foreground = (Brush)FindResource("RedPrimary");
            DotConnection.Fill = (Brush)FindResource("RedDark");
            TxtConnection.Text = "No device";
            TxtStatusBar.Text = "Controller disconnected.";
            AppendLog("[DISCONNECT] Controller removed.");
        }

        private void BtnRumble_Click(object sender, RoutedEventArgs e)
        {
            AppendLog("[TEST] Rumble test triggered.");
            TxtStatusBar.Text = "Rumble test sent.";
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            AppendLog($"[APPLY] L2={SliderL2.Value:F0} R2={SliderR2.Value:F0} VibL={SliderVibL.Value:F0} VibR={SliderVibR.Value:F0}");
            TxtStatusBar.Text = "Controller settings applied.";
        }

        private void AppendLog(string message)
        {
            TxtLog.Text += $"\n[{DateTime.Now:HH:mm:ss}] {message}";
            LogScroller.ScrollToEnd();
        }
    }
}
