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

            //Загоняем все события внутрь массивов
            #region SetEvents 

            TestGoodEvent smthGood = new TestGoodEvent();
            GoodEvents = new IEvent[] {smthGood};

            TestBadEvent smthBad = new TestBadEvent();
            BadEvents = new IEvent[] { smthBad };

            #endregion

            Timer = 0;
            Speed = 0;
            MonthNum = 1;
            Randomizator = new Random();
            currentEvent = null;
            Pause.IsEnabled = false;

            Timing.Text = "Месяц №" + MonthNum.ToString();
            MonthFinished += (object obj) => {this.Timing.Text = "Месяц №" + MonthNum.ToString(); MonthNum+=1;};
            MonthFinished += EventCaller;
        }

        private int Timer { get; set; }
        private int Speed { get; set; }
        private int MonthNum { get; set; }
        private bool TimeStarted { get; set; }

        private Action <object> MonthFinished;
        private Random Randomizator;

        private IEvent[] BadEvents;
        private IEvent[] GoodEvents;
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
                    MonthFinished(Randomizator);  // делегат, который вызывает события по "завершению месяца"
                }
                await Task.Delay(100);
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
            MiniMenu MiniMenuSingle = new MiniMenu(RepositorySingle);
            Pause_Click(null, null);
            MiniMenuSingle.Show();
        }

        private void EventCaller (object secretOfProgramm)
        {
            int decision = ((Random)secretOfProgramm).Next(100);
            if (decision >= 80)
                currentEvent = BadEvents[((Random)secretOfProgramm).Next(BadEvents.Length)];
            else
                if (decision <= 10)
                    currentEvent = GoodEvents[((Random)secretOfProgramm).Next(GoodEvents.Length)];
            
            if (currentEvent!=null)
            {
                EventMenuForm curentEventMenu = new EventMenuForm(currentEvent);
                Pause_Click(null, null);
                curentEventMenu.ShowDialog();
                
                Log.Text += "Месяц №" + MonthNum.ToString() + ": " + currentEvent.Log + "\n";
                currentEvent = null;
                Start_Click(null, null);
            }


        }

    }
}
