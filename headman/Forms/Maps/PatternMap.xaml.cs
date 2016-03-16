﻿using System;
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


namespace headman.Forms.Maps
{
    /// <summary>
    /// Interaction logic for PatternMap.xaml
    /// </summary>
    public partial class PatternMap : Window
    {
        IRepo RepositorySingle;

        public PatternMap(IRepo InputRepositorySingle)
        {
            InitializeComponent();

            RepositorySingle = InputRepositorySingle;
            RepositorySingle.Map = this;
            StartCurrentPatternMomentCreator momentCreator = new StartCurrentPatternMomentCreator(); // тут менять при создании новой карты
            RepositorySingle.currentSituation = momentCreator.Create();

            Timer = 0;
            Speed = 0;
            Randomizator = new Random();
            currentEvent = null;
            Pause.IsEnabled = false;
            TikTacSpeed = 200;

            MiniMenuOpened = false;

            this.InfoRefresh();
            Timing.Text = "Месяц  №" + RepositorySingle.currentSituation.GameMonth.ToString();
            MonthFinished += () => { RepositorySingle.currentSituation.GameMonth += 1; this.Timing.Text = "Месяц №" + RepositorySingle.currentSituation.GameMonth.ToString(); };
            MonthFinished += EventCaller;
            MonthFinished += StandartTurn;
        }



        private int Timer { get; set; }
        private int Speed { get; set; }
        private int TikTacSpeed { get; set; }
        private int RandomNum { get; set; }

        private bool TimeStarted { get; set; }
        public bool MiniMenuOpened { get; set; }

        private Action MonthFinished;
        private Random Randomizator;

        private IEvent currentEvent;

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
                    this.InfoRefresh();
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
            MiniMenuOpened = true;
            MiniMenu MiniMenuSingle = new MiniMenu(RepositorySingle);
            Pause_Click(null, null);
            MiniMenuSingle.ShowDialog();
            MiniMenuOpened = false;
        }

        private void EventCaller()
        {
            int decision = (Randomizator).Next(100);
            if ((decision >= 91) && (RepositorySingle.currentSituation.BadEvents.Count != 0))
            {
                RandomNum = Randomizator.Next(RepositorySingle.currentSituation.BadEvents.Count);
                currentEvent = RepositorySingle.currentSituation.BadEvents[RandomNum];
                RepositorySingle.currentSituation.BadEvents.RemoveAt(RandomNum);
            }
            else
                if ((decision <= 3) && (RepositorySingle.currentSituation.GoodEvents.Count != 0))
                {
                    RandomNum = Randomizator.Next(RepositorySingle.currentSituation.GoodEvents.Count);
                    currentEvent = RepositorySingle.currentSituation.GoodEvents[RandomNum];
                    RepositorySingle.currentSituation.GoodEvents.RemoveAt(RandomNum);
                }

            if (currentEvent != null)
            {
                currentEvent.Moment = RepositorySingle.currentSituation;
                EventMenuForm curentEventMenu = new EventMenuForm(currentEvent);
                Pause_Click(null, null);
                curentEventMenu.ShowDialog();

                if (currentEvent.result != "" || currentEvent.result != null)
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
            if (!MiniMenuOpened)
                Application.Current.Shutdown();
        }

        private void SureDialog(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Pause_Click(null, null);
            Sure sureQuestion = new Sure();
            sureQuestion.ShowDialog();
            if (!(bool)sureQuestion.DialogResult)
            {
                e.Cancel = true;
            }
        }


        private void InfoRefresh()
        {
            StonesInfo.Text = RepositorySingle.currentSituation.Stone.ToString();
            WoodenInfo.Text = RepositorySingle.currentSituation.Wood.ToString();
            WaterInfo.Text = RepositorySingle.currentSituation.Water.ToString();
            PeopleInfo.Text = RepositorySingle.currentSituation.Population.ToString();

            bool[] items = RepositorySingle.currentSituation.Items;

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



            GetStones.IsEnabled = true;
            GetWood.IsEnabled = true;
            GetWater.IsEnabled = true;

            if (people <= 0)
            {
                people = 0;
                Pause_Click(null, null);
                Start.IsEnabled = false;
                SpeedUp.IsEnabled = false;
                MessageBox.Show("GAME OVER");
            }

            this.RepositorySingle.currentSituation.Population = people;

        }

        private void MoveToAnotherIsland()
        {
            

        }

        #region Get_Resourses
        private void GetStones_Click(object sender, RoutedEventArgs e)
        {
            if (RepositorySingle.currentSituation.Items[1])
                RepositorySingle.currentSituation.Stone += 10;
            else
                RepositorySingle.currentSituation.Stone += 5;

            GetStones.IsEnabled = false;
            GetWood.IsEnabled = false;
            GetWater.IsEnabled = false;
        }

        private void GetWood_Click(object sender, RoutedEventArgs e)
        {
            if (RepositorySingle.currentSituation.Items[1])
                RepositorySingle.currentSituation.Wood += 10;
            else
                RepositorySingle.currentSituation.Wood += 5;

            GetStones.IsEnabled = false;
            GetWood.IsEnabled = false;
            GetWater.IsEnabled = false;
        }

        private void GetWater_Click(object sender, RoutedEventArgs e)
        {
            if (RepositorySingle.currentSituation.Items[2])
                RepositorySingle.currentSituation.Water = 20;
            else
                RepositorySingle.currentSituation.Water = 10;

            GetStones.IsEnabled = false;
            GetWood.IsEnabled = false;
            GetWater.IsEnabled = false;
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
            }
            else
            {
                MessageBox.Show("Не хватает ресурсов");
            }
        }
        #endregion
    }
}