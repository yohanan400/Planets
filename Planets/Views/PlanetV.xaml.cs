﻿using PlanetsBE;
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
    /// Interaction logic for PlanetsV.xaml
    /// </summary>
    public partial class PlanetsV : UserControl
    {
        public ViewModels.PlanetVM PlanetVM { get; set; }
        public PlanetsV()
        {
            InitializeComponent();

            PlanetVM = new ViewModels.PlanetVM();
            this.DataContext = PlanetVM;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // PlanetVM.currentPlanet = (Planet)PickupCB.SelectedItem;
        }
    }
}
