﻿using System;
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
    /// Interaction logic for NeoV.xaml
    /// </summary>
    public partial class NeoV : UserControl
    {
        private ViewModels.NeoVM NeoVM { get; set; }
        public NeoV()
        {
            InitializeComponent();
            NeoVM = new ViewModels.NeoVM();
            this.DataContext = NeoVM;
        }
    }
}
