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
            PlanetsDAL.PlanetsDal dalReference = new PlanetsDAL.PlanetsDal();

            showCB.ItemsSource = dalReference.GetPicturesIds();
            podCB.ItemsSource = from pod in dalReference.GetAllPictureOfTheDay() select pod.Id;

            //dalReference.AddPOD();
            dalReference.GetMediaFromNasa("");

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
            Picture picture = new Picture();
            picture.PictureName = "moon";
            picture.PlanetId = 2;
            picture.Path = UploadTB.Text;
            dalReference.AddPicture(picture);
            UploadTB.Text = "Successfully uploaded";
        }

      

        private void showCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlanetsDAL.PlanetsDal dalReference = new PlanetsDAL.PlanetsDal();

            ImageSourceConverter converted = new ImageSourceConverter();
            Byte[] picture = dalReference.GetPictureById((int)showCB.SelectedItem);



            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(picture);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;


            image.Source = imgSrc;

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            PlanetsDAL.PlanetsDal planetsDal = new PlanetsDAL.PlanetsDal();
            planetsDal.DeletePictureById((int)showCB.SelectedItem);
            MessageBox.Show("picture deleted");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            PlanetsDAL.PlanetsDal dalReference = new PlanetsDAL.PlanetsDal();

            showCB.ItemsSource = dalReference.GetPicturesIds();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            PlanetsDAL.PlanetsDal planetsDal = new PlanetsDAL.PlanetsDal();
            planetsDal.DeletePictureOfTheDay(planetsDal.GetPictureOfTheDayById((int)podCB.SelectedItem));
            MessageBox.Show("pod deleted");

        }
    }
}
