using System.Windows;
using headman.Repository;

namespace headman.Forms
{
    /// <summary>
    /// Логика взаимодействия для Finish.xaml
    /// </summary>
    public partial class Finish : Window
    {
        Repo RepositorySingle;

        public Finish(Repo InputRepositorySingle)
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
