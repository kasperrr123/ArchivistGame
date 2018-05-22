using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivistGame.models
{
    public class Bike
    {

        public string id { get; set; }
        public string type { get; set; }
        public string model { get; set; }

        public string gender { get; set; }
        public decimal price { get; set; }

        public string stelid { get; set; }
        public bool available { get; set; }
    }
}
