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

namespace headman.Forms
{
    /// <summary>
    /// Логика взаимодействия для Finish.xaml
    /// </summary>
    public partial class Finish : Window
    {
        IRepo RepositorySingle;

        public Finish(IRepo InputRepositorySingle)
        {
            InitializeComponent();
            RepositorySingle = InputRepositorySingle;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            RepositorySingle.Map.Close();

            this.Close();
            RepositorySingle.MainMenu.Show();
            RepositorySingle.Map = null;
            RepositorySingle.currentSituation = null;
            RepositorySingle.Islands = null;
        }
    }
}
