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
using headman.Repository;
using headman.Forms.Maps;

namespace headman.Forms.MapChoise
{
    /// <summary>
    /// Логика взаимодействия для MapChoise.xaml
    /// </summary>
    public partial class MapChoise : Window
    {
        IRepo currentRepository;

        public MapChoise(IRepo RepositorySingle)
        {
            InitializeComponent();
            GeneralInfo Info = new GeneralInfo();
            MapsList.ItemsSource = Info.Maps;
            currentRepository = RepositorySingle;
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            switch (MapsList.SelectedItem.ToString())
            {
                case ("Pattern"):
                    {
                        PatternMap map = new PatternMap(currentRepository);
                        this.Close();
                        map.Show();
                        return;
                    }
                    

                case ("Test map"):
                    {
                        TestMap map = new TestMap(currentRepository);
                        this.Close();
                        map.Show();
                        return;
                    }
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
            currentRepository.MainMenu.Show();

        }

        private void MapsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //switch (MapsList.SelectedItem.ToString())
            //{
            //    case ("Pattern"):
            //        {
            //            MapPicture.Source = new BitmapImage(new Uri(@"\Image\svgMaps\pattern.svg"));
            //            return;
            //        }


            //    case ("Test map"):
            //        {
            //            MapPicture.Source = new BitmapImage(new Uri(@"\Image\Volcano2.jpg"));
            //            return;
            //        }
            //}

        }
    }
}
