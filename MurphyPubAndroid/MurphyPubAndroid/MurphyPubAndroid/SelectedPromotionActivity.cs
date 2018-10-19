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
    [Activity(Label = "SelectedPromotionActivity", Theme = "@android:style/Theme.DeviceDefault.Light.NoActionBar.Fullscreen")]
    public class SelectedPromotionActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SelectedPromotion);
            SetValues();
            SetOnClickEvents();
        }

        void SetValues()
        {
            try
            {
                int PromocijaID = Intent.GetIntExtra("PromocijaID", -1);
                if (PromocijaID == -1)
                    throw new Exception("Error when loading event.");
                Promocija promocija = JSONParser.DownloadSerializedJSON<List<Promocija>>("http://marfipab.com/scripts/current_promotion.php?id="+PromocijaID)[0];
                if (promocija == null)
                    throw new Exception("Error when loading event.");
                FindViewById<TextView>(Resource.Id.SelectedPromocijaNaziv).Text = promocija.naziv;
                JSONParser.SetImageWithURL(this, FindViewById<ImageView>(Resource.Id.SelectedPromocijaSlika), promocija.slika);
                if (promocija.tip.ToUpper() == "PRIV")
                {
                    FindViewById<TextView>(Resource.Id.SelectedPromocijaDatum).Text = promocija.datum.ToShortDateString();
                    FindViewById<TextView>(Resource.Id.SelectedPromocijaCena).Text = promocija.cena + " RSD";
                }
                else
                {
                    FindViewById<TextView>(Resource.Id.SelectedPromocijaOpis).Text = promocija.opis;
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        void SetOnClickEvents()
        {
            FindViewById<Button>(Resource.Id.SelectedPromotionButtonEvents).Click += delegate
            {
                Intent intent = new Intent(this, typeof(EventActivity));
                StartActivity(intent);
                Finish();
            };

            FindViewById<Button>(Resource.Id.SelectedPromotionButtonPromotions).Click += delegate
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