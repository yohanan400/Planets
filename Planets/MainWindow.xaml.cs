using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Planet planet = new Planet();
            PlanetsDAL.PlanetsDal dalReference = new PlanetsDAL.PlanetsDal();
            planet = dalReference.GetPlanetByName("Hello");
            tb.Text = planet.ToString();

           // dalReference.AddPlanet(new Planet { Id = 10, Name = "Hello2" });
            //tb.Text = "Done";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Planet planet = new Planet();
            PlanetsDAL.PlanetsDal dalReference = new PlanetsDAL.PlanetsDal();
            List<Planet> planets = dalReference.GetAllPlanets();
            lv.ItemsSource = planets;

           // dalReference.AddPlanet(new Planet { Id = 0, Name = "Hello" });
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Planet planet = new Planet();
            PlanetsDAL.PlanetsDal dalReference = new PlanetsDAL.PlanetsDal();
            planet = dalReference.GetPlanetByName(updateTB.Text);

            planet.Mass = 5555;

            dalReference.UpdatePlanetByName(planet);
            lv.Items.Refresh();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PlanetsDAL.PlanetsDal dalReference = new PlanetsDAL.PlanetsDal();
            dalReference.DeletePlanetByName(deleteTB.Text);
            lv.Items.Refresh();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            PlanetsDAL.PlanetsDal dalReference = new PlanetsDAL.PlanetsDal();
            dalReference.UploadPictureToFireBase(UploadTB.Text);
            UploadTB.Text = "Successfully uploaded";
        }
    }
}
