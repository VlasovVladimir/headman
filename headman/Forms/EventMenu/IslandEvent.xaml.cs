using System.Windows;
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
            this.NameInfo.Text = regEvent.Name;
            this.Description.Text = regEvent.Description;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
