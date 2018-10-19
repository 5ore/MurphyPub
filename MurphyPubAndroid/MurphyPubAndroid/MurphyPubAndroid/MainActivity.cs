using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Android.Views;
using System;
using Android.Content;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using Android.Graphics;
using Firebase.Iid;
using Android.Util;
using Firebase;
namespace MurphyPubAndroid
{
    [Activity(Label = "Murphy's Pub", MainLauncher = true, Theme = "@android:style/Theme.DeviceDefault.Light.NoActionBar.Fullscreen")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Task.Run(() =>
            {
                Firebase.Messaging.FirebaseMessaging.Instance.SubscribeToTopic("murphypub");
            });

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            SetOnClickEvents();

        }


        private void SetOnClickEvents()
        {
            Button buttonEvents = FindViewById<Button>(Resource.Id.MainButtonEvents);
            buttonEvents.Click += delegate
            {
                Intent intent = new Intent(this, typeof(EventActivity));
                buttonEvents.SetBackgroundResource(Resource.Drawable.dogadjaji_selektovani);
                // await Task.Run(() => { Toast.MakeText(this, "Ucitavanje...", ToastLength.Long).Show(); });
                StartActivity(intent);
            };

            Button buttonPromotions = FindViewById<Button>(Resource.Id.MainButtonPromotions);
            buttonPromotions.Click += delegate
            {
                Intent intent = new Intent(this, typeof(PromotionActivity));
                buttonPromotions.SetBackgroundResource(Resource.Drawable.promocije_selektovane);
                // await  Task.Run(() => { Toast.MakeText(this, "Ucitavanje...", ToastLength.Long).Show(); });
                StartActivity(intent);
            };
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            Finish();
        }
    }
}
