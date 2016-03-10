using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using headman.Region;

namespace headman.СurrentMoment
{
    public class CurrentMoment
    {
        public int Population { get; set; }
        public int Water { get; set; }
        public int Wood { get; set; }
        public int Stone { get; set; }

        public List<IRegion> Regions {get; set;}


    }
}
