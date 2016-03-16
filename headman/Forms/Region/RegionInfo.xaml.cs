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
using headman.СurrentMoment;
using headman.Region;

namespace headman.Forms.Region
{
    /// <summary>
    /// Логика взаимодействия для RegionInfo.xaml
    /// </summary>
    public partial class RegionInfo : Window
    {
        CurrentMoment Moment;
        public RegionInfo(CurrentMoment moment, int ind)
        {
            InitializeComponent();
            Moment = moment;
            this.Name.Text = moment.Regions[ind].Name;
            this.StonesInfo.Text = moment.Regions[ind].Stone.ToString();
            this.WaterInfo.Text = moment.Regions[ind].Water.ToString();
            this.WoodenInfo.Text = moment.Regions[ind].Wood.ToString();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
