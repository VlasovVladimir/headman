using System.Windows;

namespace headman.Forms
{
    /// <summary>
    /// Interaction logic for Sure.xaml
    /// </summary>
    public partial class Sure : Window
    {
        public Sure()
        {
            InitializeComponent();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
