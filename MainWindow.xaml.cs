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
        }

        private void BtnTap_Click(object sender, RoutedEventArgs e)
        {
            var glow = new RadialGradientBrush
            {
                GradientOrigin = new Point(0.5, 0.6),
                Center = new Point(0.5, 0.5),
                RadiusX = 0.8,
                RadiusY = 0.8
            };
            glow.GradientStops.Add(new GradientStop(Color.FromArgb(0x60, 0xFF, 0x1A, 0x3D), 0));
            glow.GradientStops.Add(new GradientStop(Colors.Transparent, 1));

            var grid = (Grid)((StackPanel)BtnTap.Parent).Parent;
            grid.Background = glow;
        }
    }
}
