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

            RepositorySingle = InputRepositorySingle;
        }

        private void ToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            RepositorySingle.Map.Close();
            this.Close();
            RepositorySingle.MainMenu.Show();
        }
    }
}
