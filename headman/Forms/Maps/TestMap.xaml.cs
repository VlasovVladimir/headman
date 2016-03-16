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

        private void Green_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("эта штука работает");
        }

        private void DarkBlue_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Turquoise_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Violet_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Blue_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Lilac_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Gray_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Eared_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Marsh_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Ruby_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Pink_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Black_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Orange_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void LittleTurquoise_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void DarkGreen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void LightGreen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Left_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Right_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Red_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
