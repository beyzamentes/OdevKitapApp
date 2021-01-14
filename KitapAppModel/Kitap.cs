using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapAppModel
{
    public class Kitap
    {
        public Kitap()
        {

        }
        public Kitap(string kitapad, string yazarad, string yazarsoyad, string sayfasayisi, string kitaptürü)
        {
            Kitapad = kitapad;
            Yazarad = yazarad;
            Yazarsoyad = yazarsoyad;
            Sayfasayisi = sayfasayisi;
            Kitaptürü = kitaptürü;
        }
        public int Kitapid { get; set; }
        public string Kitapad { get; set; }
        public string Yazarad { get; set; }
        public string Yazarsoyad { get; set; }
        public string Sayfasayisi { get; set; }
        public string Kitaptürü { get; set; }

    }
}
