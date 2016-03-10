using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace headman.Event
{
    [Serializable]
    public class TestBadEvent : IEvent 
    {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Log { get; set; }

            public string Exit1 { get; set; }
            public string Exit2 { get; set; }
            public string Exit3 { get; set; }

            public void Exit_1()
            {
                MessageBox.Show("Правильный выбор");
                Log += "И вы сделали правильный выбор";
            }


            public void Exit_2()
            {
                MessageBox.Show("Средненький выбор");
                Log += "И вы сделали средненький выбор";
            }
            public void Exit_3()
            {
                MessageBox.Show("Отвратный выбор");
                Log += "И вы сделали отвратный выбор";
            }

        public TestBadEvent()
        {
            Name = "Что-то ужасное";
            Description = "Ох какой ужас";
            Log = "cлучилось что-то ужасное.";

            Exit1 = "Выход 1";
            Exit2 = "Выход 2";
            Exit3 = "Выход 3";
        }
    }
}
