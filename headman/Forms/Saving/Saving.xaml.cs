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
using System.IO;
using System.Xml.Serialization;
using headman.Repository;
using headman.Forms.Maps;
using headman.Forms.Maps.First;
using headman.Forms.Maps.Second;
using headman.СurrentMoment;


namespace headman.Forms.Saving
{
    /// <summary>
    /// Логика взаимодействия для Saving.xaml
    /// </summary>
    public partial class Saving : Window
    {
        IRepo RepositirySingle;
        string DirectoryPath;

        public Saving(IRepo inputSingle)
        {
            this.RepositirySingle = inputSingle;
            InitializeComponent();
            List<string> saves = new List<string>();
            DirectoryPath = @"C:\Users\СаняВолков\Source\Repos\headman2\headman\Saves\";
            string path = DirectoryPath + "list.txt";
            
            if (File.Exists(path))
                using (StreamReader sr = new StreamReader(path, true))      
                {
                    string line;
                    while ((line =  sr.ReadLine()) != null)
                    {
                        saves.Add(line);
                    }
                }
            else
                using (FileStream fs = new FileStream(path, FileMode.CreateNew))
                {
                }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            if (RepositirySingle.MiniMenu == null)
                RepositirySingle.MainMenu.Show();
            else
                RepositirySingle.MiniMenu.Show();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            if (SavingList.SelectedItem!=null)
                if (RepositirySingle.Map == null)
                {
                    CurrentMoment moment = LoadMoment((string)(SavingList.SelectedItem));
                
                    switch (moment.MapName)
                    {
                        case ("Pattern"):
                            {
                                PatternMap map = new PatternMap(RepositirySingle);
                                this.Close();
                                map.Show();
                                RepositirySingle.currentSituation = moment;
                                return;
                            }


                        case ("Test map"):
                            {
                                TestMap map = new TestMap(RepositirySingle);
                                this.Close();
                                map.Show();
                                RepositirySingle.currentSituation = moment;
                                return;
                            }

                        case ("First"):
                            {
                                First map = new First(RepositirySingle);
                                this.Close();
                                map.Show();
                                RepositirySingle.currentSituation = moment;
                                return;
                            }

                        case ("Second"):
                            {
                                Second map = new Second(RepositirySingle);
                                this.Close();
                                map.Show();
                                RepositirySingle.currentSituation = moment;
                                return;
                            }
                    }
            }
        }

        private CurrentMoment LoadMoment(string name)
        {
            CurrentMoment output = new CurrentMoment();

            XmlSerializer ser = new XmlSerializer(typeof(CurrentMoment));
            string path = DirectoryPath + name + ".xml";
            if (File.Exists(path))
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    output = (CurrentMoment)(ser.Deserialize(fs));
                }
            return output;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer ser = new XmlSerializer(typeof(CurrentMoment));
            CurrentMoment savingMoment= RepositirySingle.currentSituation;


            if (this.Name.Text !=null)
                using (FileStream fs = new FileStream(DirectoryPath + this.Name.Text + ".xml", FileMode.OpenOrCreate))
                {
                    ser.Serialize(fs, savingMoment);
                    MessageBox.Show("Готово");
                    using (StreamWriter sw = new StreamWriter (new FileStream(DirectoryPath + "list.txt", FileMode.Append, FileAccess.Write)))
                    {
                        sw.WriteLine(Name.Text);
                    }
                }

        }
    }
}
