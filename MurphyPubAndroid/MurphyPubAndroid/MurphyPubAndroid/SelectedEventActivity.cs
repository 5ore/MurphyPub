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
using Newtonsoft.Json;

namespace MurphyPubAndroid
{
    [Activity(Label = "SelectedEventActivity", Theme = "@android:style/Theme.DeviceDefault.Light.NoActionBar.Fullscreen")]
    public class SelectedEventActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SelectedEvent);
            SetValues();
            SetOnClickEvents();
        }

        private void SetValues()
        {
            try
            {   
                Dogadjaj dogadjaj = JSONParser.DownloadSerializedJSON<List<Dogadjaj>>("http://marfipab.com/scripts/current_event.php?id="+Intent.GetIntExtra("DogadjajID",-1))[0];
                if (dogadjaj == null)
                    throw new Exception("Error when loading event.");
                FindViewById<TextView>(Resource.Id.SelectedEventNaziv).Text = dogadjaj.naziv;
                JSONParser.SetImageWithURL(this,FindViewById<ImageView>(Resource.Id.SelectedEventSlika), dogadjaj.slika);
                FindViewById<TextView>(Resource.Id.SelectedEventDatum).Text = dogadjaj.datum.ToShortDateString();
                FindViewById<TextView>(Resource.Id.SelectedEventOpis).Text = dogadjaj.opis;
                
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void SetOnClickEvents()
        {
            FindViewById<Button>(Resource.Id.SelectedEventButtonEvents).Click += delegate
            {
                Intent intent = new Intent(this, typeof(EventActivity));
                StartActivity(intent);
                Finish();
            };

            FindViewById<Button>(Resource.Id.SelectedEventButtonPromotions).Click += delegate
            {
                Intent intent = new Intent(this, typeof(PromotionActivity));
                StartActivity(intent);
                Finish();
            };

        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }
    }
}