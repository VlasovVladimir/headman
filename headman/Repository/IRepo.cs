using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace headman.Repository
{
    public interface IRepo
    {
        Window MainMenu { get; set; }
        Window Map { get; set; }
    }
}
