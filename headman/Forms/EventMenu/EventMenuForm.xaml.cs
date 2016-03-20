using System.Windows;
using headman.Event;

namespace headman.Forms.EventMenu
{
    /// <summary>
    /// Логика взаимодействия для EventMenu.xaml
    /// </summary>
    public partial class EventMenuForm : Window
    {
        IEvent thisEvent;
        bool ChoiseMade;

        public EventMenuForm(IEvent SomeEvent) 
        {
            InitializeComponent();
            this.Name.Text = SomeEvent.Name;
            this.Description.Text = SomeEvent.Description;
            this.Exit1.Content = SomeEvent.Exit1;
            this.Exit2.Content = SomeEvent.Exit2;
            this.Exit3.Content = SomeEvent.Exit3;
            thisEvent = SomeEvent;
            ChoiseMade = false;
        }

        private void Exit1_Click(object sender, RoutedEventArgs e)
        {
            ChoiseMade = true;
            this.Close();
            thisEvent.Exit_1();
        }

        private void Exit2_Click(object sender, RoutedEventArgs e)
        {
            ChoiseMade = true;
            this.Close();
            thisEvent.Exit_2();
        }

        private void Exit3_Click(object sender, RoutedEventArgs e)
        {
            ChoiseMade = true;
            this.Close();
            thisEvent.Exit_3();            
        }

        private void StopWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ChoiseMade)
            {
                MessageBox.Show("Вы должны сделать выбор! От этого зависит судьба человечества!", "Неа, нельзя так уйти");
                e.Cancel = true;
            }
        }

        
    }
}
