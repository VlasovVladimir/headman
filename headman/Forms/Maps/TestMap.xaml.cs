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
/* <Window x:Class="headman.Region.RegionInfo"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:headman.Region"
        mc:Ignorable="d"
       Title="RegionName" Height="406" Width="800" WindowStartupLocation="CenterScreen">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="145*"/>
            <ColumnDefinition Width="647*"/>
        </Grid.ColumnDefinitions>
        <TextBox x:Name="Name" HorizontalAlignment="Left" Height="30" Margin="10,45,0,0" TextWrapping="Wrap" Text="Название" VerticalAlignment="Top" Width="225" FontSize="21.333" Grid.ColumnSpan="2" FontStyle="Italic" IsEnabled="False"/>
        <TextBox x:Name="NameInfo" Grid.Column="1" HorizontalAlignment="Left" Height="30" Margin="185,45,0,0" TextWrapping="Wrap" Text="TextBox" VerticalAlignment="Top" Width="440" FontSize="21.333" IsEnabled="False"/>
        <TextBox x:Name="Resources" HorizontalAlignment="Left" Height="50" Margin="10,120,0,0" TextWrapping="Wrap" Text="Ресурсообеспеченность" VerticalAlignment="Top" Width="300" FontSize="24" Grid.ColumnSpan="2" TextDecorations="Underline" IsEnabled="False"/>
        <TextBlock x:Name="Wooden" Grid.Column="1" HorizontalAlignment="Left" Height="40" Margin="5,255,0,0" TextWrapping="Wrap" Text="✿" VerticalAlignment="Top" Width="40" FontSize="32"/>
        <TextBlock x:Name="Water" Grid.Column="1" HorizontalAlignment="Left" Height="40" Margin="5,310,0,0" TextWrapping="Wrap" Text="☂" VerticalAlignment="Top" Width="40" RenderTransformOrigin="0.5,1.833" FontSize="32"/>
        <TextBlock x:Name="Stones" Grid.Column="1" HorizontalAlignment="Left" Height="40" Margin="5,200,0,0" TextWrapping="Wrap" Text="●" VerticalAlignment="Top" Width="40" RenderTransformOrigin="1,4" FontSize="32"/>
        <TextBox x:Name="StonesInfo" Grid.Column="1" HorizontalAlignment="Left" Height="30" Margin="60,210,0,0" TextWrapping="Wrap" Text="Сколько-та тут" VerticalAlignment="Top" Width="180" FontSize="18.667" IsEnabled="False"/>
        <TextBox x:Name="WoodenInfo" Grid.Column="1" HorizontalAlignment="Left" Height="30" Margin="60,266,0,0" TextWrapping="Wrap" Text="Сколько-та там" VerticalAlignment="Top" Width="180" FontSize="18.667" IsEnabled="False"/>
        <TextBox x:Name="WaterInfo" Grid.Column="1" HorizontalAlignment="Left" Height="30" Margin="60,320,0,0" TextWrapping="Wrap" Text="Сколько-та там" VerticalAlignment="Top" Width="180" FontSize="18.667" IsEnabled="False"/>
        <Button x:Name="button" Content="Переплыть!" Grid.Column="1" HorizontalAlignment="Left" Height="175" Margin="350,120,0,0" VerticalAlignment="Top" Width="210" FontSize="32" IsEnabled="False"/>

    </Grid>
</Window>
*/