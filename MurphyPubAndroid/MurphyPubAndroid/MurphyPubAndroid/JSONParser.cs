using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Android.Graphics;
using System.Threading.Tasks;
using Android.Graphics.Drawables;
using Android.Content.Res;
using Android.Util;

namespace MurphyPubAndroid
{
    public static class JSONParser
    {
        public static List<Promocija> Promocije = new List<Promocija>();

        public static T DownloadSerializedJSON<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                    Console.WriteLine();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.ToString());

                }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
        public static void SetImageWithURL(Context context,ImageView img, string url)
        {
            try
            {
                var webclient = new WebClient();
                var imageBytes = webclient.DownloadData("http://marfipab.com/murphypub/" + url);
                var imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                img.SetImageDrawable(new BitmapDrawable(context.Resources, imageBitmap));
            }
            catch(Exception ex)
            {
                Log.Debug("Slika", ex.Message);
            }
        }

    }
}