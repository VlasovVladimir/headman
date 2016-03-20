using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Xml.Serialization;
using headman.Repository;
using headman.Forms.Maps.First;
using headman.Forms.Maps.Second;
using headman.СurrentMoment;

namespace headman.Forms
{
    /// <summary>
    /// Interaction logic for Saving.xaml
    /// </summary>
    public partial class Saving : Window
    {
        Repo RepositirySingle;
        string DirectoryPath;
        private CurrentMoment operatingSave;

        public Saving(Repo inputSingle)
        {
            this.RepositirySingle = inputSingle;
            InitializeComponent();
            List<string> saves = new List<string>();
            DirectoryPath = @"..\..\Saves\";
            string path = DirectoryPath + "list.txt";

            if (File.Exists(path))
                using (StreamReader sr = new StreamReader(path, true))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != "")
                            saves.Add(line);
                    }
                }
            else
                using (FileStream fs = new FileStream(path, FileMode.CreateNew))
                {
                }
            SavingList.ItemsSource = saves;
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
            if (SavingList.SelectedItem != null)
                if (RepositirySingle.Map == null)
                {
                    CurrentMoment moment = operatingSave;

                    switch (moment.MapName)
                    {
                        case ("First"):
                            {
                                First map = new First(RepositirySingle);
                                this.Close();
                                RepositirySingle.currentSituation = moment;
                                map.Show();
                                RepositirySingle.upload();
                                return;
                            }

                        case ("Second"):
                            {
                                Second map = new Second(RepositirySingle);
                                this.Close();
                                RepositirySingle.currentSituation = moment;
                                map.Show();
                                RepositirySingle.upload();
                                return;
                            }
                    }
                }
        }

        private void LoadMoment(string name)
        {
            operatingSave = new CurrentMoment();

            XmlSerializer ser = new XmlSerializer(typeof(CurrentMoment));
            string path = DirectoryPath + name + ".xml";
            if (File.Exists(path))
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    operatingSave = (CurrentMoment)(ser.Deserialize(fs));
                }
            else
            {
                operatingSave = null;
                MessageBox.Show("Шаловливые духи украли карту! Ваше племя потерялось в океане.", "Ошибка...", MessageBoxButton.OK);
            }


        }

        private void SaveMoment(string name)
        {
            XmlSerializer ser = new XmlSerializer(typeof(CurrentMoment));
            CurrentMoment savingMoment = RepositirySingle.currentSituation;
            savingMoment.SaveDate = DateTime.Now;

            if (name != "")
                using (FileStream fs = new FileStream(DirectoryPath + name + ".xml", FileMode.OpenOrCreate))
                {
                    ser.Serialize(fs, savingMoment);
                    MessageBox.Show("Готово");
                    if (!SavingList.Items.Contains(name))
                        using (StreamWriter sw = new StreamWriter(new FileStream(DirectoryPath + "list.txt", FileMode.Append, FileAccess.Write)))
                        {
                            sw.WriteLine(name);
                        }
                }
            else
            {
                MessageBox.Show("Надо бы ввести название сохранения!", "Ошибка...", MessageBoxButton.OK);
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (RepositirySingle.currentSituation != null)
            {
                if (SavingList.Items.Contains(Name.Text))
                {

                    MessageBoxResult result = MessageBox.Show("Уже есть такое сохранение. Перезаписать?", "У нас вопрос!", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                    if (result == MessageBoxResult.Yes)
                    {
                        SaveMoment(Name.Text);
                    }
                }
                else
                {
                    SaveMoment(Name.Text);
                }
            }
            else
            {
                MessageBox.Show("Нечего сохранять", "Эмммм...", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SavingList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.LoadMoment(SavingList.SelectedItem.ToString());
            if (operatingSave != null)
            {
                Info.Text = SavingList.SelectedItem.ToString() + "  " + operatingSave.SaveDate.ToString() + "\n" + "\n" +
                    "Название карты: " + operatingSave.MapName + "\n" +
                    "Численность племени: " + operatingSave.Population.ToString() + "\n" +
                    "Текущая локация: " + operatingSave.Regions[operatingSave.CurrentRegionIndex].Name + "\n" +
                    "Шансы на победу: в этой игре вообще вряд ли возможно выиграть";
            }
            else
                Info.Text = "";
            Name.Text = SavingList.SelectedItem.ToString();
        }
    }
}
