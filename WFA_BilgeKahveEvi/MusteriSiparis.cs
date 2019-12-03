using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_BilgeKahveEvi
{
    class MusteriSiparis
    {
        public string adiSoyadi { get; set; }
        public string telefonNumarasi { get; set; }
        public string adresi { get; set; }

        public List<Siparis> siparisleri = new List<Siparis>();
    }
}
