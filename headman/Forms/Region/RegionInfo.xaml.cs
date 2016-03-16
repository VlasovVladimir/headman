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

namespace headman.Forms.Region
{
    /// <summary>
    /// Логика взаимодействия для RegionInfo.xaml
    /// </summary>
    public partial class RegionInfo : Window
    {
        CurrentMoment Moment;
        public RegionInfo(CurrentMoment moment)
        {
            InitializeComponent();
            Moment = moment;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
