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
using headman.Forms.Help;
using headman.Forms.Maps;
using headman.Forms.Saving;

namespace headman.Forms.Menus
{
    /// <summary>
    /// Interaction logic for MiniMenu.xaml
    /// </summary>
    public partial class MiniMenu : Window
    {
        IRepo RepositorySingle;

        public MiniMenu(IRepo InputRepositorySingle)
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
            //RepositorySingle.MainMenu = null;
            RepositorySingle.currentSituation = null;
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow HelpWindowSingle = new HelpWindow();
            HelpWindowSingle.Show();
        }

        private void BackToGame_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Saving.Saving uploadMenu = new Saving.Saving(RepositorySingle);
            uploadMenu.ShowDialog();
        }
    }
}
