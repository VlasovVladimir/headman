using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using headman.СurrentMoment;

namespace headman.Repository
{
    class FirstRepo: IRepo
    {
        public Window MainMenu { get; set; }
        public Window Map { get; set; }

        public CurrentMoment currentSituation { get; set; }
        
    }
}
