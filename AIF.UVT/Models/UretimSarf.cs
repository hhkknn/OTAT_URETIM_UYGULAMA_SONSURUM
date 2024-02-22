using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIF.UVT.Models
{
    public class UretimSarf
    {
        public string KalemNo { get; set; }
        public string UretimSiparisNo { get; set; } 
        public double PlanlananSarf { get; set; }
        public double GerceklesenSarf { get; set; }
        public double BeklenenSarf { get; set; }

        public List<UretimSarfParti> uretimSarfPartis { get; set; }
    }

    public class UretimSarfParti
    {
        public int SatirNo { get; set; }

        public string Parti { get; set; }

        public double PartiMiktari { get; set; }
    }
}