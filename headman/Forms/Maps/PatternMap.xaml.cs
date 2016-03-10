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
            TikTacSpeed = 500;

            MiniMenuOpened = false;

            this.InfoRefresh();
            Timing.Text = "Месяц №" + RepositorySingle.currentSituation.GameMonth.ToString();
            MonthFinished += () => {RepositorySingle.currentSituation.GameMonth+=1; this.Timing.Text = "Месяц №" + RepositorySingle.currentSituation.GameMonth.ToString(); };
            MonthFinished += EventCaller;
        }

        private int Timer { get; set; }
        private int Speed { get; set; }
        private int TikTacSpeed { get; set; }
        
        private bool TimeStarted { get; set; }
        public bool MiniMenuOpened { get; set; }

        private Action MonthFinished;
        private Random Randomizator;

        private IEvent currentEvent;

        private async void TimeRun ()  // главный цикл программы
        {
            while (true)
            {
                if (Timer<10)
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
                Speed = 3;
            }
            else
            {
                TimeRun();
                Speed = 3;
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

        private void EventCaller ()
        {
            int decision = (Randomizator).Next(100);
            if (decision >= 80)
                currentEvent = RepositorySingle.currentSituation.BadEvents[(Randomizator.Next(RepositorySingle.currentSituation.BadEvents.Count))];
            else
                if (decision <= 10)
                    currentEvent = RepositorySingle.currentSituation.GoodEvents[(Randomizator.Next(RepositorySingle.currentSituation.GoodEvents.Count))];
            
            if (currentEvent!=null)
            {
                EventMenuForm curentEventMenu = new EventMenuForm(currentEvent);
                Pause_Click(null, null);
                curentEventMenu.ShowDialog();
                
                Log.Text += "Месяц №" + RepositorySingle.currentSituation.GameMonth.ToString() + ": " + currentEvent.Log + "\n";
                currentEvent = null;
                Start_Click(null, null);
            }
        }

        // обработка нажатия на крестик сверху
        private void MapClose(object sender, EventArgs e)
        {
            if(!MiniMenuOpened)
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
        }
    }
}
