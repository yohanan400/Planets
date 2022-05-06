using Planets.Models;
using Planets.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Planets.Views;

namespace Planets.Views
{
    /// <summary>
    /// Interaction logic for MediaV.xaml
    /// </summary>
    public partial class MediaV : UserControl
    {
        public MediaVM mediaVM { get; set; }

        public MediaV()
        {
            InitializeComponent();
            mediaVM = new MediaVM();
            this.DataContext = mediaVM;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mediaVM.Search(subjectTB.Text);
            mediaLB.ItemsSource = mediaVM.MediaInfos;
        }
    }
}
