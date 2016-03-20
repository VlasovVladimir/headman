using System.Windows;
using headman.Repository;

namespace headman.Forms
{
    /// <summary>
    /// Interaction logic for MiniMenu.xaml
    /// </summary>
    public partial class MiniMenu : Window
    {
        Repo RepositorySingle;

        public MiniMenu(Repo InputRepositorySingle)
        {
            InitializeComponent();
            InputRepositorySingle.MiniMenu = this;
            RepositorySingle = InputRepositorySingle;

        }

        private void ToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            RepositorySingle.Map.Close();

            this.Close();
            RepositorySingle.MainMenu.Show();
            RepositorySingle.Map = null;
            RepositorySingle.MiniMenu = null;
            RepositorySingle.currentSituation = null;
            RepositorySingle.Islands = null;
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Help HelpWindowSingle = new Help();
            HelpWindowSingle.Show();
        }

        private void BackToGame_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // this.Hide();
            Saving uploadMenu = new Saving(RepositorySingle);
            uploadMenu.ShowDialog();
        }
    }
}
