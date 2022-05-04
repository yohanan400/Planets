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

namespace Planets.Views
{
    /// <summary>
    /// Interaction logic for PodV.xaml
    /// </summary>
    public partial class PodV : UserControl
    {
        private PodVM podVM { get; set; }
        public PodV()
        {
            InitializeComponent();
            podVM = new PodVM();
            this.DataContext = podVM;
        }
    }
}
