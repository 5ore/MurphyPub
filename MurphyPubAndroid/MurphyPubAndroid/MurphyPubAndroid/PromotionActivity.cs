using System;
using System.Collections.Generic;
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
using Felipecsl.GifImageViewLibrary;
using Newtonsoft.Json;

namespace MurphyPubAndroid
{
    [Activity(Label = "PromotionActivity", Theme = "@android:style/Theme.DeviceDefault.Light.NoActionBar.Fullscreen")]
    public class PromotionActivity : Activity
    {
        public List<Promocija> Promocije = new List<Promocija>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Promotions);

            SetOnClickEvents();

            GetPromocijeAsync();
        }

        protected override void OnStart()
        {
            base.OnStart();
            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(Service.ConnectivityService);
            if (connectivityManager != null && connectivityManager.ActiveNetworkInfo != null && connectivityManager.ActiveNetworkInfo.IsConnected)
                GetPromocijeAsync();
            else
                Toast.MakeText(this, "Nije pronadjena stabilna internet veza", ToastLength.Long).Show();
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

        private void SetOnClickEvents()
        {
            Button promotionsButtonPromotions = FindViewById<Button>(Resource.Id.PromotionsButtonPromotions);
            Button promotionsButtonEvents = FindViewById<Button>(Resource.Id.PromotionsButtonEvents);
            promotionsButtonPromotions.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                promotionsButtonPromotions.SetBackgroundResource(Resource.Drawable.promocije_neselektovane);
                // Task.Run(() => { Toast.MakeText(this, "Ucitavanje...", ToastLength.Long).Show(); });
                StartActivity(intent);
            };

            promotionsButtonEvents.Click += delegate
            {
                Intent intent = new Intent(this, typeof(EventActivity));
                promotionsButtonEvents.SetBackgroundResource(Resource.Drawable.dogadjaji_selektovani);
                promotionsButtonPromotions.SetBackgroundResource(Resource.Drawable.promocije_neselektovane);
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

        public async void GetPromocijeAsync()
        {
            ListView promotions = FindViewById<ListView>(Resource.Id.PromotionsList);
            promotions.SetFriction(ViewConfiguration.ScrollFriction * 0.1f);
            Toast.MakeText(this, "Ucitavanje...", ToastLength.Long).Show();
          
            await Task.Run(() =>
            {
                Promocije = DownloadSerializedJSON<List<Promocija>>("http://marfipab.com/scripts/promotions.php/");
            });
            if (Promocije == null && Promocije.Count < 1)
                return;
   
            PromocijaAdapter adapter = new PromocijaAdapter(this, Promocije);
            promotions.Adapter = adapter;
        }

        //private class LoaderTask : AsyncTask<Java.Lang.Void, Java.Lang.Void, List<Promocija>>
        //{
        //    PromotionActivity activity;
        //    ImageView loadingImage;
        //    ListView promotionsList;

        //    public LoaderTask(PromotionActivity activity)
        //    {
        //        this.activity = activity;
        //        loadingImage = activity.FindViewById<ImageView>(Resource.Id.promocije_loading_image);
        //        promotionsList = activity.FindViewById<ListView>(Resource.Id.PromotionsList);
        //    }
        //    protected override void OnPreExecute()
        //    {
        //        base.OnPreExecute();
        //        try
        //        {
        //            loadingImage.Visibility = ViewStates.Visible;
        //        }
        //        catch (Exception ex)
        //        {
        //            System.Diagnostics.Debug.Print(ex.Message);
        //        }
        //    }
        //    protected override List<Promocija> RunInBackground(params Java.Lang.Void[] @params)
        //    {
        //        List<Promocija> promocije = DownloadSerializedJSON<List<Promocija>>("http://marfipab.com/scripts/promotions.php/");
        //        return promocije;
        //    }
        //    protected override void OnPostExecute(List<Promocija> promocije)
        //    {
        //        base.OnPostExecute(promocije);
        //        loadingImage.Visibility = ViewStates.Gone;
        //        promotionsList.SetFriction(ViewConfiguration.ScrollFriction * 0.1f);
        //    }

        //    public T DownloadSerializedJSON<T>(string url) where T : new()
        //    {
        //        using (var w = new WebClient())
        //        {
        //            var json_data = string.Empty;
        //            // attempt to download JSON data as a string
        //            try
        //            {
        //                json_data = w.DownloadString(url);
        //            }
        //            catch (Exception ex)
        //            {

        //                Console.WriteLine(ex.ToString());

        //            }
        //            // if string with JSON data is not empty, deserialize it to class and return its instance 
        //            return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
        //        }
        //    }
        //}
    }
}