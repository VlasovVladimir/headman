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
using headman.Forms.Help;
using headman.Forms.Maps;
using headman.Repository;

namespace headman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IRepo RepositorySingle;

        public MainWindow()
        {
            InitializeComponent();

            RepositorySingle = new FirstRepo();  // задание репозитория
            RepositorySingle.MainMenu = this;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow HelpWindow = new HelpWindow();
            HelpWindow.Show();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            PatternMap map = new PatternMap(RepositorySingle);
            this.Hide();
            map.Show();
        }
    }
}
