using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace headman.Forms.EventMenu
{
    /// <summary>
    /// Логика взаимодействия для Description.xaml
    /// </summary>
    public partial class Description : Window
    {
        public Description(string info, string path)
        {
            InitializeComponent();
            if (path != null)
            {
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource = new BitmapImage(new Uri(path, UriKind.Absolute));
                this.Background = myBrush;
            }
            
            description.Text = info;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
