using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using headman.СurrentMoment;

namespace headman.Repository
{
    public class Repo
    {
        public Window MainMenu { get; set; }
        public Window Map { get; set; }
        public Window MiniMenu { get; set; }

        public CurrentMoment currentSituation { get; set; }
        public List<Path> Islands { get; set; }
        public Action upload { get; set; }
    }
}
