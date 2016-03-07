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

namespace headman.Forms.Maps
{
    /// <summary>
    /// Interaction logic for PatternMap.xaml
    /// </summary>
    public partial class PatternMap : Window
    {
        public PatternMap()
        {
            InitializeComponent();
            Timer = 0;
            Speed = 1;
            MonthNum = 1;
            Timing.Text = "Месяц №" + MonthNum.ToString();
            MonthFinished += (object obj) => {this.Timing.Text = "Месяц №" + MonthNum.ToString(); MonthNum+=1;};
        }

        private int Timer { get; set; }
        private int Speed { get; set; }
        private int MonthNum { get; set; }   

        Action <object> MonthFinished;

        private async void TimeRun ()
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
                    MonthFinished(null);
                }
                await Task.Delay(100);
            }

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            TimeRun();
        }


    }
}
