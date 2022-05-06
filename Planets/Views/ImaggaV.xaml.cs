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
using System.Windows.Shapes;

namespace Planets.Views
{
    /// <summary>
    /// Interaction logic for ImaggaV.xaml
    /// </summary>
    public partial class ImaggaV : Window
    {
        private ImaggaVM ImaggaVM;
        public ImaggaV(string ImageUrl)
        {
            InitializeComponent();
            ImaggaVM = new ImaggaVM();
            ImaggaVM.GetImagga(ImageUrl);
        }
    }
}
