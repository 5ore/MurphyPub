using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurphyPub
{
    public class Promocija
    {
        private string Naziv;
        private string Opis;
        private string Tip;
        private float Cena;
        private DateTime Datum;
        private string Slika;

        public Promocija(string naziv, string opis, string tip, float cena, DateTime datum, string slika)
        {
            Naziv = naziv;
            Opis = opis;
            Tip = tip;
            Cena = cena;
            Datum = datum;
            Slika = slika;
        }
    }
}
