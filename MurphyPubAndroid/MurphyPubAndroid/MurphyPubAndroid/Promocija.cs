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
    public class Promocija
    {
        public int ID { get; set; }
        public string naziv { get; set; }
        public float cena { get; set; }
        public string tip { get; set; }
        public DateTime datum { get; set; }
        public string opis { get; set; }
        public string slika { get; set; }   


        public Promocija()
        {

        }

        public Promocija(int ID, string naziv, float cena, string tip, DateTime datum, string opis, string slika)
        {
            this.ID = ID;
            this.slika = slika;
            this.tip = tip;
            this.naziv = naziv;
            this.cena = cena;
            this.datum = datum;
            this.opis = opis;
        }
    }
}