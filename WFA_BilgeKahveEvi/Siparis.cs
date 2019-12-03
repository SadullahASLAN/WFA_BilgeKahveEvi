using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_BilgeKahveEvi
{
    class Siparis
    {
        private string _boyut;
        private decimal _boyutCarpani = 1;
        public string Boyut
        {
            get { return _boyut; }
            set
            {
                switch (value)
                {
                    case "Grande":
                        _boyutCarpani = 1.25m;
                        break;
                    case "Venti":
                        _boyutCarpani = 1.75m;
                        break;
                    default:
                        break;
                }
                _boyut = value;
            }
        }

        private string _icecek;
        private decimal _icecekfiyat;
        public string Icecek
        {
            get { return _icecek; }
            set
            {
                switch (value)
                {
                    case "Misto":
                        _icecekfiyat = 4.5m;
                        break;
                    case "Americano":
                        _icecekfiyat = 5.75m;
                        break;
                    case "Bianco":
                        _icecekfiyat = 6;
                        break;
                    case "Cappucino":
                        _icecekfiyat = 7.5m;
                        break;
                    case "Macchiato":
                        _icecekfiyat = 6.75m;
                        break;
                    case "Con Panna":
                        _icecekfiyat = 8;
                        break;
                    case "Mocha":
                        _icecekfiyat = 7.75m;
                        break;
                    case "Buzlu Caffee Latte":
                    case "Ice Americano":
                    case "Espresso Frappe":
                    case "Buzlu Caramel Crest":
                    case "Milkshake":
                        _icecekfiyat = 5.5m;
                        break;
                    case "Çay":
                        _icecekfiyat = 3;
                        break;
                    case "Hot Chocolate":
                        _icecekfiyat = 4.5m;
                        break;
                    case "Chai Tea Latte":
                        _icecekfiyat = 6.5m;
                        break;
                }
                _icecek = value;
            }
        }

        private string _shot;
        private decimal _shotFiyat = 0;
        public string Shot
        {
            get { return _shot; }
            set
            {
                switch (value)
                {
                    case "1x":
                        _shotFiyat = 0.75m;
                        break;
                    case "2x":
                        _shotFiyat = 1.5m;
                        break;
                }
                _shot = ", " + value + " Shot ";
            }
        }


        private string _sut;
        private decimal _sutFiyat = 0;
        public string Sut
        {
            get { return _sut; }
            set
            {
                if (value != string.Empty)
                {
                    _sutFiyat = 0.5m;
                }
                _sut = ", " + value + " Süt ";
            }
        }

        public int Adet { get; set; }

        public decimal Fiyat { get { return Adet * ((_boyutCarpani * _icecekfiyat) + _shotFiyat + _sutFiyat); } }

        public override string ToString()
        {
            return $"{Adet}X, {Boyut}, {Icecek}{Sut}{Shot}:{Fiyat.ToString("c2")}";
        }
    }
}
