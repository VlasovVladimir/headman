﻿using System.Windows;
using headman.СurrentMoment;

namespace headman.Event
{
    public class _20_TestGoodEvent: IEvent 
    {

            public CurrentMoment Moment { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Log { get; set; }
            public string result { get; set; }

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

        public _20_TestGoodEvent()
        {
            Name = "Что-то прекрасное";
            Description = "Ох как хорошо";
            Log = "cлучилось что-то чудесное.";

            Exit1 = "Выход 1";
            Exit2 = "Выход 2";
            Exit3 = "Выход 3";
        }
    }
}
