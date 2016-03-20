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
using headman.Forms;

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
