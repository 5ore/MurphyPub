using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurphyPub
{
    public class Dogadjaj
    {
        private string Naziv;
        private string Opis;
        private DateTime Datum;
        private string Slika;

        public Dogadjaj(string naziv, string opis, DateTime datum, string slika)
        {
            Naziv = naziv;
            Opis = opis;
            Datum = datum;
            Slika = slika;
        }
    }
}
