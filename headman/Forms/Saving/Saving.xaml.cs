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
using headman.СurrentMoment;


namespace headman.Forms.Saving
{
    /// <summary>
    /// Логика взаимодействия для Saving.xaml
    /// </summary>
    public partial class Saving : Window
    {
        IRepo RepositirySingle;

        public Saving(IRepo inputSingle)
        {
            this.RepositirySingle = inputSingle;
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            if (RepositirySingle.MiniMenu == null)
                RepositirySingle.MainMenu.Show();
            else
                RepositirySingle.MiniMenu.Show();
        }
    }
}
