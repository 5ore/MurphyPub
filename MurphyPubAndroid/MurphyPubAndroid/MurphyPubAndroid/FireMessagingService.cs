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
using Firebase.Messaging;
using Android.Graphics;

namespace MurphyPubAndroid
{
    [Service]
    [IntentFilter(new[] {
        "com.google.firebase.MESSAGING_EVENT"
    })]
    class FireMessagingService : FirebaseMessagingService
    {
        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);
            SendNotificatios(message.GetNotification().Body, message.GetNotification().Title);
        }
        public void SendNotificatios(string body, string Header)
        {
            Notification.Builder builder = new Notification.Builder(this);
            builder.SetSmallIcon(Resource.Drawable.logo_leprechaun);
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            PendingIntent pendingIntent = PendingIntent.GetActivity(this, 0, intent, 0);
            builder.SetContentIntent(pendingIntent);
            builder.SetLargeIcon(BitmapFactory.DecodeResource(Resources, Resource.Drawable.logo_leprechaun));
            builder.SetContentTitle("Murphy's Pub");
            builder.SetContentText(body);
            builder.SetDefaults(NotificationDefaults.Sound);
            builder.SetAutoCancel(true);
            NotificationManager notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.Notify(1, builder.Build());
        }
    }
}