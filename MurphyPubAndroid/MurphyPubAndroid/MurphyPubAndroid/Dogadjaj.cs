using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MurphyPubAndroid
{
    public class Dogadjaj
    {
        public int ID { get; set; }
        public string slika { get; set; }
        public DateTime datum { get; set; }
        public string naziv { get; set; }
        public string opis { get; set; }

        public Dogadjaj()
        {

        }

        public Dogadjaj(int ID, string slika, DateTime datum, string naziv, string opis)
        {
            this.ID = ID;
            this.slika = slika;
            this.datum = datum;
            this.naziv = naziv;
            this.opis = opis;
        }

    }
}