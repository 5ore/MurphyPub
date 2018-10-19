using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace MurphyPubAndroid
{
    [Activity(Label = "EventActivity", Theme = "@android:style/Theme.DeviceDefault.Light.NoActionBar.Fullscreen")]
    public class EventActivity : Activity
    {

        public List<Dogadjaj> Dogadjaji = new List<Dogadjaj>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Events);

            SetOnClickEvents();
        }

        protected override void OnStart()
        {
            base.OnStart();

            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(Service.ConnectivityService);
            if (connectivityManager != null && connectivityManager.ActiveNetworkInfo != null && connectivityManager.ActiveNetworkInfo.IsConnected)
                GetDogadjajiAsync();
            else
                Toast.MakeText(this, "Nije pronadjena stabilna internet veza.", ToastLength.Long).Show();
        }

        public T DownloadSerializedJSON<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());

                }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                if (!string.IsNullOrEmpty(json_data))
                {
                    try
                    {
                        return JsonConvert.DeserializeObject<T>(json_data);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                }
                return new T();
            }
        }

        public async void GetDogadjajiAsync()
        {
            ListView events = FindViewById<ListView>(Resource.Id.EventsList);
            Toast.MakeText(this, "Ucitavanje...", ToastLength.Long).Show();
            await Task.Run(() =>
            {
                events.SetFriction(ViewConfiguration.ScrollFriction * 0.1f);
                Dogadjaji = DownloadSerializedJSON<List<Dogadjaj>>("http://marfipab.com/scripts/events.php/");
            });

            if (Dogadjaji == null || Dogadjaji.Count < 1)
                return;

            DogadjajAdapter adapter = new DogadjajAdapter(this, Dogadjaji);
            events.Adapter = adapter;
            
        }

        private void SetOnClickEvents()
        {
            Button eventsButtonPromotions = FindViewById<Button>(Resource.Id.EventsButtonPromotions);
            Button eventsButtonEvents = FindViewById<Button>(Resource.Id.EventsButtonEvents);
            eventsButtonPromotions.Click += delegate
            {
                Intent intent = new Intent(this, typeof(PromotionActivity));
                eventsButtonPromotions.SetBackgroundResource(Resource.Drawable.promocije_selektovane);
                eventsButtonEvents.SetBackgroundResource(Resource.Drawable.dogadjaji_neselektovani);
              //  Task.Run(() => { Toast.MakeText(this, "Ucitavanje...", ToastLength.Long).Show(); });
                StartActivity(intent);
            };
            eventsButtonEvents.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                eventsButtonEvents.SetBackgroundResource(Resource.Drawable.dogadjaji_neselektovani);
              //  Task.Run(() => { Toast.MakeText(this, "Ucitavanje...", ToastLength.Long).Show(); });
                StartActivity(intent);
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