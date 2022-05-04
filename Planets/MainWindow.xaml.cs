using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PlanetsBE;


namespace Planets
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PodsB_Click(object sender, RoutedEventArgs e)
        {
            NeovUC.Visibility = Visibility.Hidden;
            PodUC.Visibility = Visibility.Visible;
        }

        private void NeosB_Click(object sender, RoutedEventArgs e)
        {
            NeovUC.Visibility = Visibility.Visible;
            PodUC.Visibility = Visibility.Hidden;
        }
    }
}
