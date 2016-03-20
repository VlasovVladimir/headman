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
using headman.Forms.Maps.First;
using headman.Forms.Maps.Second;

namespace headman.Forms
{
    /// <summary>
    /// Логика взаимодействия для MapChoise.xaml
    /// </summary>
    public partial class MapChoise : Window
    {
        Repo currentRepository;
        GeneralInfo Info;

        public MapChoise(Repo RepositorySingle)
        {
            InitializeComponent();
            Info = new GeneralInfo();
            MapsList.ItemsSource = Info.Maps;
            currentRepository = RepositorySingle;
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            if (MapsList.SelectedIndex >= 0)        // обработка исключения - ФУ ее не проводить!
            {
                switch (MapsList.SelectedIndex)
                {

                    case (0):
                        {
                            StartWindow start = new StartWindow(Info.Goals[0]);
                            this.Close();
                            start.ShowDialog();
                            First map = new First(currentRepository);
                            map.Show();
                            return;
                        }

                    case (1):
                        {
                            StartWindow start = new StartWindow(Info.Goals[1]);
                            this.Close();
                            start.ShowDialog();
                            Second map = new Second(currentRepository);
                            map.Show();
                            return;
                        }
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
            switch (MapsList.SelectedItem.ToString())
            {
                case ("Pattern"):
                    {
                        description.Text = "Название: шаблончик" + "\n" +
                            "Описание: это очень странное место без каких либо островов. Но там все же живут какие-то люди" + "\n" + "\n" +
                            "Стартовые условия" + "\n" +
                            "Человек: 100" + "\n" +
                            "Камня: 0" + "\n" +
                            "Дерева: 0" + "\n" +
                            "Воды: 5" + "\n" +
                            "Сложность: какая сложность?";
                        return;
                    }


                case ("Test map"):
                    {
                        description.Text = "Название: ой... Оно еще осталось тут, ну ладно..." + "\n" +
                            "Описание: тут вы можете посмотреть на какую-то карту, Но зачем?" + "\n" + "\n" +
                            "Стартовые условия" + "\n" +
                            "Человек: 0" + "\n" +
                            "Камня: 0" + "\n" +
                            "Дерева: 0" + "\n" +
                            "Воды: 0" + "\n" +
                            "Сложность: какая сложность?";
                        return;
                    }

                case ("First"):
                    {
                        description.Text = "Название: первая (и единственная)" + "\n" +
                            "Описание: пройдите нелегкий путь из 17 островов на пути к Земле Обетованной! Подсказка: вы начинаете в левом верхнем углу." + "\n" + "\n" +
                            "Стартовые условия" + "\n" +
                            "Человек: 100" + "\n" +
                            "Камня: 0" + "\n" +
                            "Дерева: 0" + "\n" +
                            "Воды: 5" + "\n" +
                            "Сложность: почти невозможно";
                        return;
                    }

                case ("Second"):
                    {
                        description.Text = "Название: вторая (она же демо)" + "\n" +
                            "Описание: Здесь-таки может быть не одна карта!" + "\n" + "\n" +
                            "Стартовые условия" + "\n" +
                            "Человек: 100" + "\n" +
                            "Камня: 0" + "\n" +
                            "Дерева: 0" + "\n" +
                            "Воды: 5" + "\n" +
                            "Сложность: как знать..";
                        return;
                    }


                //case ("Test map"):
                //    {
                //        description.Text = "Название: ой... Оно еще осталось тут, ну ладно..." + "\n" +
                //            "Описание: тут вы можете посмотреть на какую-то карту, Но зачем?" + "\n" + "\n" +
                //            "Стартовые условия" + "\n" +
                //            "Человек: 0" + "\n" +
                //            "Камня: 0" + "\n" +
                //            "Дерева: 0" + "\n" +
                //            "Воды: 0" + "\n" +
                //            "Сложность: какая сложность?";
                //        return;
                //    }
            }

        }
    }
}
