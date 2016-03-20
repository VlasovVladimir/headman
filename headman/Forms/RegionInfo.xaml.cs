using System;
using System.Windows;
using headman.Forms.EventMenu;
using headman.Event;
using headman.Repository;

namespace headman.Forms
{
    /// <summary>
    /// Логика взаимодействия для RegionInfo.xaml
    /// </summary>
    public partial class RegionInfo : Window
    {
        Repo Repo;
        int index;

        public RegionInfo(Repo repo, int ind)
        {
            InitializeComponent();
            Repo = repo;
            index = ind;
            this.NameInfo.Text = Repo.currentSituation.Regions[ind].Name;
            this.StonesInfo.Text = Repo.currentSituation.Regions[ind].Stone.ToString();
            this.WaterInfo.Text = Repo.currentSituation.Regions[ind].Water.ToString();
            this.WoodenInfo.Text = Repo.currentSituation.Regions[ind].Wood.ToString();
            if ((this.Repo.currentSituation.CurrentRegionIndex != ind) && (Repo.currentSituation.Items[0])
                && (Math.Abs(this.Repo.currentSituation.CurrentRegionIndex - ind) <= 2)
                && (Repo.currentSituation.GameMonth - Repo.currentSituation.LastMonthOfMoving > 9))
            {
                this.MoveTo.IsEnabled = true;
            }
        }



        private void MoveTo_Click(object sender, RoutedEventArgs e)
        {

            Repo.currentSituation.LastMonthOfMoving = Repo.currentSituation.GameMonth;
            int prev_ind = Repo.currentSituation.CurrentRegionIndex;
            int ind = Repo.currentSituation.CurrentRegionIndex;

            Repo.currentSituation.CurrentRegionIndex = this.index;
            Repo.currentSituation.Regions[prev_ind].Wood += Repo.currentSituation.Wood;
            Repo.currentSituation.Regions[prev_ind].Stone += Repo.currentSituation.Stone;
            Repo.currentSituation.Wood = 0;
            Repo.currentSituation.Stone = 0;


            if (!Repo.currentSituation.Items[2])
                Repo.currentSituation.Water = 0;

            Repo.currentSituation.Items[4] = false;



            this.Close();

            if (Repo.currentSituation.Regions[index].Event != 0)
            {
                EventGetter getter = new EventGetter();
                IRegionEvent curEvent = getter.GetRegEventByIndex(Repo.currentSituation.Regions[index].Event);
                curEvent.Moment = Repo.currentSituation;
                curEvent.action();
                IslandEvent EventWindow = new IslandEvent(curEvent);
                EventWindow.ShowDialog();
            }


        }
    }
}
