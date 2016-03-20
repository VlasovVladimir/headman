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
using headman.Forms.Menus;
using headman.Repository;
using headman.Event;
using headman.Forms.EventMenu;
using headman.Forms.Maps;
using headman.Forms.Region;
using headman.Forms;


namespace headman.Forms.Maps.First
{
    /// <summary>
    /// Interaction logic for First.xaml
    /// </summary>
    public partial class First : Window
    {
        IRepo RepositorySingle;
        EventGetter eventGetter;

        private int Timer { get; set; }
        private int Speed { get; set; }
        private int TikTacSpeed { get; set; }
        private int RandomNum { get; set; }

        private bool TimeStarted { get; set; }
        public bool UnstandartClose { get; set; }

        private Action MonthFinished;
        private Random Randomizator;

        private IEvent currentEvent;  

        public First(IRepo InputRepositorySingle)
        {
            InitializeComponent();

            List<Path> newIslands = new List<Path>();

            newIslands.Add(this.Green);
            newIslands.Add(this.DarkBlue);
            newIslands.Add(this.Turquoise);
            newIslands.Add(this.Violet);
            newIslands.Add(this.Blue);
            newIslands.Add(this.Lilac);
            newIslands.Add(this.Gray);
            newIslands.Add(this.Eared);
            newIslands.Add(this.Marsh);
            newIslands.Add(this.Ruby);
            newIslands.Add(this.Pink);
            newIslands.Add(this.Black);
            newIslands.Add(this.Orange);
            newIslands.Add(this.LittleTurquoise);
            newIslands.Add(this.DarkGreen);
            newIslands.Add(this.LightGreen);
            newIslands.Add(this.Left);
            newIslands.Add(this.Right);
            newIslands.Add(this.Red);

            RepositorySingle = InputRepositorySingle;
            RepositorySingle.Map = this;
            eventGetter = new EventGetter();
            MomentCreator_First momentCreator = new MomentCreator_First(); // тут менять при создании новой карты
            RepositorySingle.currentSituation = momentCreator.Create();
            RepositorySingle.Islands = newIslands;

            //Islands.Clear();

            RepositorySingle.upload += InfoRefresh;


            Timer = 0;
            Speed = 0;
            Randomizator = new Random();
            currentEvent = null;
            Pause.IsEnabled = false;
            TikTacSpeed = 2000;

            UnstandartClose = false;

            this.InfoRefresh();
            Timing.Text = "Месяц  №" + RepositorySingle.currentSituation.GameMonth.ToString();

            MonthFinished += () =>  RepositorySingle.currentSituation.GameMonth += 1;
            MonthFinished += EventCaller;
            MonthFinished += StandartTurn;
        }      

        private async void TimeRun()  // главный цикл программы
        {
            while (true)
            {
                if (Timer < 10)
                {
                    Timer += Speed;
                }
                else
                {
                    Timer = 0;
                    MonthFinished();  // делегат, который вызывает события по "завершению месяца"
                }
                await Task.Delay(TikTacSpeed);
            }

        }

        private void Start_Click(object sender, RoutedEventArgs e)  //кнопочка, запускающая время
        {
            if (TimeStarted)
            {
                Speed = 1;
            }
            else
            {
                TimeRun();
                Speed = 1;
            }

            Start.IsEnabled = false;
            Pause.IsEnabled = true;
            SpeedUp.IsEnabled = true;
        }

        private void Pause_Click(object sender, RoutedEventArgs e) //кнопочка, останавливающая время
        {
            Speed = 0;

            Start.IsEnabled = true;
            Pause.IsEnabled = false;
            SpeedUp.IsEnabled = true;
        }

        private void SpeedUp_Click(object sender, RoutedEventArgs e) //кнопочка, ускоряющая время
        {
            if (TimeStarted)
            {
                Speed = 300;
            }
            else
            {
                TimeRun();
                Speed = 300;
            }

            Start.IsEnabled = true;
            Pause.IsEnabled = true;
            SpeedUp.IsEnabled = false;

        }

        private void GoTo_Click(object sender, RoutedEventArgs e) // вызов маленького меню
        {
            UnstandartClose = true;
            MiniMenu MiniMenuSingle = new MiniMenu(RepositorySingle);
            Pause_Click(null, null);
            MiniMenuSingle.ShowDialog();
            UnstandartClose = false;
        }

        private void EventCaller()
        {
            int decision = (Randomizator).Next(100);
            if ((decision >= 91) && (RepositorySingle.currentSituation.BadEvents.Count != 0))
            {
                RandomNum = Randomizator.Next(RepositorySingle.currentSituation.BadEvents.Count);
                currentEvent = eventGetter.GetEventByIndex(RepositorySingle.currentSituation.BadEvents[RandomNum]);
                RepositorySingle.currentSituation.BadEvents.RemoveAt(RandomNum);
            }
            else
                if ((decision <= 3) && (RepositorySingle.currentSituation.GoodEvents.Count != 0))
                {
                    RandomNum = Randomizator.Next(RepositorySingle.currentSituation.GoodEvents.Count);
                    currentEvent = eventGetter.GetEventByIndex(RepositorySingle.currentSituation.GoodEvents[RandomNum]);
                    RepositorySingle.currentSituation.GoodEvents.RemoveAt(RandomNum);
                }

            if (currentEvent != null)
            {
                currentEvent.Moment = RepositorySingle.currentSituation;
                EventMenuForm curentEventMenu = new EventMenuForm(currentEvent);
                Pause_Click(null, null);
                curentEventMenu.ShowDialog();

                if (currentEvent.result == null)
                    currentEvent.result = "";

                if (currentEvent.result != "") 
                {
                    Description desc = new Description(currentEvent.result, null);
                    desc.ShowDialog();
                }
                
                
                Log.Text += "Месяц №" + RepositorySingle.currentSituation.GameMonth.ToString() + ". " + currentEvent.Log + "\n";
                currentEvent = null;
                Start_Click(null, null);
            }
        }

        // обработка нажатия на крестик сверху
        private void MapClose(object sender, EventArgs e)
        {
            if (!UnstandartClose)
                Application.Current.Shutdown();
        }

        private void SureDialog(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!UnstandartClose)
            {
                Pause_Click(null, null);
                Sure sureQuestion = new Sure();
                sureQuestion.ShowDialog();
                if (!(bool)sureQuestion.DialogResult)
                {
                    e.Cancel = true;
                }
            }
        }


        private void InfoRefresh()
        {
            StonesInfo.Text = RepositorySingle.currentSituation.Stone.ToString();
            WoodenInfo.Text = RepositorySingle.currentSituation.Wood.ToString();
            WaterInfo.Text = RepositorySingle.currentSituation.Water.ToString();
            PeopleInfo.Text = RepositorySingle.currentSituation.Population.ToString();
            this.Timing.Text = "Месяц №" + RepositorySingle.currentSituation.GameMonth.ToString();

            bool[] items = RepositorySingle.currentSituation.Items;

            for (int i = 0; i < RepositorySingle.Islands.Count; i++)
            {
                RepositorySingle.Islands[i].Stroke = new SolidColorBrush(Colors.Black);
            }
            RepositorySingle.Islands[RepositorySingle.currentSituation.CurrentRegionIndex].Stroke
                = new SolidColorBrush(Colors.Gold);

            #region ButtonsAndColours

            if (items[0])
            {
                Smile0.Background = new SolidColorBrush(Colors.Green);
                Smile0.BorderBrush = new SolidColorBrush(Colors.Green);
                Smile0.Text = " ☺";
                Get0.IsEnabled = false;

            }
            else
            {
                Smile0.Background = new SolidColorBrush(Colors.Red);
                Smile0.BorderBrush = new SolidColorBrush(Colors.Red);
                Smile0.Text = " ☹";
                Get0.IsEnabled = true;
            }

            if (items[1])
            {
                Smile1.Background = new SolidColorBrush(Colors.Green);
                Smile1.BorderBrush = new SolidColorBrush(Colors.Green);
                Smile1.Text = " ☺";
                Get1.IsEnabled = false;

            }
            else
            {
                Smile1.Background = new SolidColorBrush(Colors.Red);
                Smile1.BorderBrush = new SolidColorBrush(Colors.Red);
                Smile1.Text = " ☹";
                Get1.IsEnabled = true;
            }

            if (items[2])
            {
                Smile2.Background = new SolidColorBrush(Colors.Green);
                Smile2.BorderBrush = new SolidColorBrush(Colors.Green);
                Smile2.Text = " ☺";
                Get2.IsEnabled = false;

            }
            else
            {
                Smile2.Background = new SolidColorBrush(Colors.Red);
                Smile2.BorderBrush = new SolidColorBrush(Colors.Red);
                Smile2.Text = " ☹";
                Get2.IsEnabled = true;
            }

            if (items[3])
            {
                Smile3.Background = new SolidColorBrush(Colors.Green);
                Smile3.BorderBrush = new SolidColorBrush(Colors.Green);
                Smile3.Text = " ☺";
                Get3.IsEnabled = false;

            }
            else
            {
                Smile3.Background = new SolidColorBrush(Colors.Red);
                Smile3.BorderBrush = new SolidColorBrush(Colors.Red);
                Smile3.Text = " ☹";
                Get3.IsEnabled = true;
            }

            if (items[4])
            {
                Smile4.Background = new SolidColorBrush(Colors.Green);
                Smile4.BorderBrush = new SolidColorBrush(Colors.Green);
                Smile4.Text = " ☺";
                Get4.IsEnabled = false;

            }
            else
            {
                Smile4.Background = new SolidColorBrush(Colors.Red);
                Smile4.BorderBrush = new SolidColorBrush(Colors.Red);
                Smile4.Text = " ☹";
                Get4.IsEnabled = true;
            }

            if (items[5])
            {
                Smile5.Background = new SolidColorBrush(Colors.Green);
                Smile5.BorderBrush = new SolidColorBrush(Colors.Green);
                Smile5.Text = " ☺";
                Get5.IsEnabled = false;

            }
            else
            {
                Smile5.Background = new SolidColorBrush(Colors.Red);
                Smile5.BorderBrush = new SolidColorBrush(Colors.Red);
                Smile5.Text = " ☹";
                Get5.IsEnabled = true;
            }
            #endregion

        }

        private void StandartTurn()
        {

            int people = this.RepositorySingle.currentSituation.Population;

            if (people <= 50)
                this.RepositorySingle.currentSituation.Water -= 1;
            else if (people <= 100)
                this.RepositorySingle.currentSituation.Water -= 2;
            else
                this.RepositorySingle.currentSituation.Water -= 3;

            if (this.RepositorySingle.currentSituation.Water < 0)
            {
                people -= 1;
                this.RepositorySingle.currentSituation.Water = 0;
            }

            if (!RepositorySingle.currentSituation.Items[4])
                people -= 1;
            else if ((RepositorySingle.currentSituation.GameMonth % 3) == 0)
                people += 1;



            GetStones.IsEnabled = true;
            GetWood.IsEnabled = true;
            GetWater.IsEnabled = true;


            this.RepositorySingle.currentSituation.Population = people;

            this.InfoRefresh();

            if (ChekWinning())
            {
                Pause_Click(null, null);
                Start.IsEnabled = false;
                SpeedUp.IsEnabled = false;
                UnstandartClose = true;
                WinWindow winning = new WinWindow(RepositorySingle);
                winning.ShowDialog();
            }

            if (people <= 0)
            {
                people = 0;
                Pause_Click(null, null);
                Start.IsEnabled = false;
                SpeedUp.IsEnabled = false;
                UnstandartClose = true;
                Finish finish = new Finish(RepositorySingle);
                finish.ShowDialog();
            }
        }

        private bool ChekWinning()
        {
            if ((RepositorySingle.currentSituation.CurrentRegionIndex == (RepositorySingle.Islands.Count - 1)) && 
                (RepositorySingle.currentSituation.Population > 0))
                return true;
            else
                return false; 
        }

        #region Get_Resourses
        private void GetStones_Click(object sender, RoutedEventArgs e)
        {
            if (RepositorySingle.currentSituation.Regions[RepositorySingle.currentSituation.CurrentRegionIndex].Stone > 0)
                if (RepositorySingle.currentSituation.Items[3])
                {
                    RepositorySingle.currentSituation.Stone += 10;
                    RepositorySingle.currentSituation.Regions[RepositorySingle.currentSituation.CurrentRegionIndex].Stone -= 10;
                }
                else
                {
                    RepositorySingle.currentSituation.Stone += 5;
                    RepositorySingle.currentSituation.Regions[RepositorySingle.currentSituation.CurrentRegionIndex].Stone -= 5;
                }
            else
            {
                MessageBox.Show("Вы пошли за камнями, но, к сожалению их не нашли. Видимо закончились. Пора валить");
                RepositorySingle.currentSituation.Regions[RepositorySingle.currentSituation.CurrentRegionIndex].Stone = 0;
            }

            GetStones.IsEnabled = false;
            GetWood.IsEnabled = false;
            GetWater.IsEnabled = false;

            this.InfoRefresh();
        }

        private void GetWood_Click(object sender, RoutedEventArgs e)
        {
            if (RepositorySingle.currentSituation.Regions[RepositorySingle.currentSituation.CurrentRegionIndex].Wood > 0)
                if (RepositorySingle.currentSituation.Items[1])
                {
                    RepositorySingle.currentSituation.Wood += 10;
                    RepositorySingle.currentSituation.Regions[RepositorySingle.currentSituation.CurrentRegionIndex].Wood -= 10;
                }
                else
                {
                    RepositorySingle.currentSituation.Wood += 5;
                    RepositorySingle.currentSituation.Regions[RepositorySingle.currentSituation.CurrentRegionIndex].Wood -= 5;
                }
            else
            {
                MessageBox.Show("Вы пошли за деревом, но, к сожалению, обнаружили, что вырубили уже весь лес. Надеюсь у вас уже есть лодка, ведь пора валить");
                RepositorySingle.currentSituation.Regions[RepositorySingle.currentSituation.CurrentRegionIndex].Wood = 0;
            }

            GetStones.IsEnabled = false;
            GetWood.IsEnabled = false;
            GetWater.IsEnabled = false;

            this.InfoRefresh();
        }

        private void GetWater_Click(object sender, RoutedEventArgs e)
        {
            if (RepositorySingle.currentSituation.Regions[RepositorySingle.currentSituation.CurrentRegionIndex].Water > 0)
                if (RepositorySingle.currentSituation.Items[2])
                {
                    RepositorySingle.currentSituation.Regions[RepositorySingle.currentSituation.CurrentRegionIndex].Water -= 20 - RepositorySingle.currentSituation.Water;
                    RepositorySingle.currentSituation.Water = 20;
                }
                else
                {
                    RepositorySingle.currentSituation.Regions[RepositorySingle.currentSituation.CurrentRegionIndex].Water -= 10 - RepositorySingle.currentSituation.Water;
                    RepositorySingle.currentSituation.Water = 10;
                }
            else
            {
                MessageBox.Show("Во даете! Выпили уже все озеро! \n \n Хотя не то чтобы вам следует этому радоваться, ведь вы скоро умрете...");
                RepositorySingle.currentSituation.Regions[RepositorySingle.currentSituation.CurrentRegionIndex].Wood = 0;
            }

            GetStones.IsEnabled = false;
            GetWood.IsEnabled = false;
            GetWater.IsEnabled = false;

            this.InfoRefresh();
        }
        #endregion

        #region Building

        private void Get0_Click(object sender, RoutedEventArgs e)
        {
            if ((!RepositorySingle.currentSituation.Items[0])
                && (RepositorySingle.currentSituation.Water >= 1)
                && (RepositorySingle.currentSituation.Wood >= (RepositorySingle.currentSituation.Population / 4)))
            {
                RepositorySingle.currentSituation.Items[0] = true;
                RepositorySingle.currentSituation.Water -= 1;
                RepositorySingle.currentSituation.Wood -= RepositorySingle.currentSituation.Population / 4;
                this.InfoRefresh();
            }
            else
            {
                MessageBox.Show("Не хватает ресурсов");
            }
        }

        private void Get1_Click(object sender, RoutedEventArgs e)
        {
            if ((!RepositorySingle.currentSituation.Items[1])
                && (RepositorySingle.currentSituation.Water >= 1)
                && (RepositorySingle.currentSituation.Wood >= 12)
                && (RepositorySingle.currentSituation.Stone >= 10))
            {
                RepositorySingle.currentSituation.Items[1] = true;
                RepositorySingle.currentSituation.Water -= 1;
                RepositorySingle.currentSituation.Wood -= 12;
                RepositorySingle.currentSituation.Stone -= 10;
                this.InfoRefresh();
            }
            else
            {
                MessageBox.Show("Не хватает ресурсов");
            }
        }

        private void Get2_Click(object sender, RoutedEventArgs e)
        {
            if ((!RepositorySingle.currentSituation.Items[2])
                && (RepositorySingle.currentSituation.Water >= 1)
                && (RepositorySingle.currentSituation.Wood >= 25))
            {
                RepositorySingle.currentSituation.Items[2] = true;
                RepositorySingle.currentSituation.Water -= 1;
                RepositorySingle.currentSituation.Wood -= 25;
                this.InfoRefresh();
            }
            else
            {
                MessageBox.Show("Не хватает ресурсов");
            }
        }

        private void Get3_Click(object sender, RoutedEventArgs e)
        {
            if ((!RepositorySingle.currentSituation.Items[3])
                && (RepositorySingle.currentSituation.Water >= 1)
                && (RepositorySingle.currentSituation.Wood >= 12)
                && (RepositorySingle.currentSituation.Stone >= 8))
            {
                RepositorySingle.currentSituation.Items[3] = true;
                RepositorySingle.currentSituation.Water -= 1;
                RepositorySingle.currentSituation.Wood -= 12;
                RepositorySingle.currentSituation.Stone -= 10;
                this.InfoRefresh();
            }
            else
            {
                MessageBox.Show("Не хватает ресурсов");
            }

        }

        private void Get4_Click(object sender, RoutedEventArgs e)
        {
            if ((!RepositorySingle.currentSituation.Items[4])
                && (RepositorySingle.currentSituation.Water >= 1)
                && (RepositorySingle.currentSituation.Wood >= 10)
                && (RepositorySingle.currentSituation.Stone >= 2))
            {
                RepositorySingle.currentSituation.Items[4] = true;
                RepositorySingle.currentSituation.Water -= 1;
                RepositorySingle.currentSituation.Wood -= 10;
                RepositorySingle.currentSituation.Stone -= 2;
                this.InfoRefresh();
            }
            else
            {
                MessageBox.Show("Не хватает ресурсов");
            }

        }

        private void Get5_Click(object sender, RoutedEventArgs e)
        {
            if ((!RepositorySingle.currentSituation.Items[5])
                && (RepositorySingle.currentSituation.Water >= 1)
                && (RepositorySingle.currentSituation.Wood >= 15)
                && (RepositorySingle.currentSituation.Stone >= 15))
            {
                RepositorySingle.currentSituation.Items[5] = true;
                RepositorySingle.currentSituation.Water -= 1;
                RepositorySingle.currentSituation.Wood -= 15;
                RepositorySingle.currentSituation.Stone -= 15;
                this.InfoRefresh();
            }
            else
            {
                MessageBox.Show("Не хватает ресурсов");
            }
        }
        #endregion

        private void AddInformation(int ind)
        {
            RegionInfo Info = new RegionInfo(RepositorySingle, ind);
            this.Pause_Click(null, null);
            Info.ShowDialog();
            this.Start_Click(null, null);
            this.InfoRefresh();
        }

        #region RegionInfoCall

        private void Green_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(0);
        }

        private void DarkBlue_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(1);
        }

        private void Turquoise_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(2);
        }

        private void Violet_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(3);
        }

        private void Blue_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(4);
        }

        private void Lilac_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(5);
        }

        private void Gray_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(6);
        }

        private void Eared_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(7);
        }

        private void Marsh_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(8);
        }

        private void Ruby_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(9);
        }

        private void Pink_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(10);
        }

        private void Black_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(11);
        }

        private void Orange_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(12);
        }

        private void LittleTurquoise_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(13);
        }

        private void DarkGreen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(14);
        }

        private void LightGreen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(15);
        }

        private void Left_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(16);
        }

        private void Right_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(17);
        }

        private void Red_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddInformation(18);
        }
        #endregion
    }
}