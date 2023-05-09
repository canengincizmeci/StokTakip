using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.ORM.Entity
{
    public class Urunler
    {
        public int ID { get; set; }
        public string UrunAd { get; set; }
        public string Adet { get; set; }
        public int KategoriID { get; set; }

    }
}
