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
using headman.Forms;

namespace headman.Forms.Maps
{
    /// <summary>
    /// Interaction logic for TestMap.xaml
    /// </summary>
    public partial class TestMap : Window
    {
        IRepo RepositorySingle;

        public TestMap(IRepo InputRepositorySingle)
        {
            InitializeComponent();

            RepositorySingle = InputRepositorySingle;
            RepositorySingle.Map = this;
            
            Timer = 0;
            Speed = 0;
            MonthNum = 1;
            Pause.IsEnabled = false;

            Timing.Text = "Месяц №" + MonthNum.ToString();
            MonthFinished += (object obj) => {this.Timing.Text = "Месяц №" + MonthNum.ToString(); MonthNum+=1;};
        }

        private int Timer { get; set; }
        private int Speed { get; set; }
        private int MonthNum { get; set; }
        private bool TimeStarted { get; set; }

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

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            Speed = 0;

            Start.IsEnabled = true;
            Pause.IsEnabled = false;
            SpeedUp.IsEnabled = true;
        }

        private void SpeedUp_Click(object sender, RoutedEventArgs e)
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

        private void GoTo_Click(object sender, RoutedEventArgs e)
        {
            MiniMenu MiniMenuSingle = new MiniMenu(RepositorySingle);
            Pause_Click(null, null);
            MiniMenuSingle.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rect3338_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("эта штука работает");
        }

        private void MapClose(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SureDialog(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Sure sureQuestion = new Sure();
            sureQuestion.ShowDialog();
            if (!(bool)sureQuestion.DialogResult)
            {
                e.Cancel = false;
             }
        }
    }
}
