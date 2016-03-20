using System.Windows;
using headman.Repository;
using headman.Forms;

namespace headman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repo RepositorySingle;

        public MainWindow()
        {
            InitializeComponent();


            RepositorySingle = new Repo();  // задание репозитория
            RepositorySingle.MainMenu = this;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            Help HelpWindow = new Help();
            HelpWindow.Show();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            MapChoise choise = new MapChoise(RepositorySingle);
            this.Hide();
            choise.Show();
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Saving uploadMenu = new Saving(RepositorySingle);
            uploadMenu.Show();
        }
    }
}
