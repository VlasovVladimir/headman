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
using headman.Event;

namespace headman.Forms.EventMenu
{
    /// <summary>
    /// Interaction logic for IslandEvent.xaml
    /// </summary>
    public partial class IslandEvent : Window
    {
        public IslandEvent(IRegionEvent regEvent)
        {
            InitializeComponent();
            this.Description.Text = regEvent.Description;
            this.Content = regEvent.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
