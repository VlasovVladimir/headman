using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using headman.СurrentMoment;


namespace headman.Repository
{
    public interface IRepo
    {
        Window MainMenu { get; set; }
        Window Map { get; set; }

        CurrentMoment currentSituation { get; set; }
    }
}
