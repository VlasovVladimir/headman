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
using headman.Forms.EventMenu;

namespace headman.Forms.Region
{
    /// <summary>
    /// Логика взаимодействия для RegionInfo.xaml
    /// </summary>
    public partial class RegionInfo : Window
    {
        CurrentMoment Moment;
        int index;

        public RegionInfo(CurrentMoment moment, int ind)
        {
            InitializeComponent();
            Moment = moment;
            index = ind;
            this.NameInfo.Text = moment.Regions[ind].Name;
            this.StonesInfo.Text = moment.Regions[ind].Stone.ToString();
            this.WaterInfo.Text = moment.Regions[ind].Water.ToString();
            this.WoodenInfo.Text = moment.Regions[ind].Wood.ToString();
            if ((this.Moment.CurrentRegionIndex != ind) && (Moment.Items[0]) && (Math.Abs(this.Moment.CurrentRegionIndex - ind) <= 2 ))
                this.MoveTo.IsEnabled = true;
        }

        

        private void MoveTo_Click(object sender, RoutedEventArgs e)
        {
            Moment.CurrentRegionIndex = this.index;
            Moment.Wood = 0;
            Moment.Stone = 0;

            if (!Moment.Items[2])
                Moment.Water = 0;

            for (int i = 0; i < Moment.Items.Length; i++)
            {
                if ((i != 0) && (i != 2) && (i != 5))
                    Moment.Items[i] = false;                
            }

            this.Close();

            if (Moment.Regions[index].Event!=null)
            {
                IslandEvent EventWindow = new IslandEvent(Moment.Regions[index].Event);
                EventWindow.ShowDialog();
            }
                
            
        }
    }
}
