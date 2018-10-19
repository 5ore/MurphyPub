using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MurphyPubAndroid
{
    public class DogadjajAdapter : ArrayAdapter<Dogadjaj>
    {
        private Context mContext;
        private List<Dogadjaj> dogadjaji = new List<Dogadjaj>();

        public DogadjajAdapter(Context context, List<Dogadjaj> list)
            : base(context, 0, list)
        {
            mContext = context;
            dogadjaji = list;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            DogadjajViewHolder dogadjajViewHolder = null;
            if (convertView == null)
            {
                convertView = LayoutInflater.From(mContext).Inflate(Resource.Layout.Element_dogadjaj, parent, false);
                dogadjajViewHolder = new DogadjajViewHolder()
                {
                    dogadjaj_slika = convertView.FindViewById<ImageView>(Resource.Id.event_element_image_placeholder),
                    naziv = convertView.FindViewById<TextView>(Resource.Id.dogadjaj_element_naziv),
                    datum = convertView.FindViewById<TextView>(Resource.Id.dogadjaj_element_datum),
                    vise_info = convertView.FindViewById<Button>(Resource.Id.dogadjaj_element_info)
                };
                convertView.Tag = new JavaHolder(dogadjajViewHolder);
            }
            else
                dogadjajViewHolder = ((JavaHolder)convertView.Tag).Instance as DogadjajViewHolder;

            Dogadjaj currentDogadjaj = dogadjaji[position];
            Task.Run(() => JSONParser.SetImageWithURL(mContext, dogadjajViewHolder.dogadjaj_slika, currentDogadjaj.slika));
            dogadjajViewHolder.naziv.Text = currentDogadjaj.naziv;
            dogadjajViewHolder.datum.Text = currentDogadjaj.datum.ToShortDateString();
            dogadjajViewHolder.vise_info.Click += delegate
            {
                Intent intent = new Intent(mContext, typeof(SelectedEventActivity));
                       intent.PutExtra("DogadjajID", currentDogadjaj.ID);
                       mContext.StartActivity(intent);
            };

            return convertView;

            //    ImageView image = listItem.FindViewById<ImageView>(Resource.Id.event_element_image_placeholder);
            //    Task.Run(() => JSONParser.SetImageWithURL(mContext, image, currentDogadjaj.slika));

            //    TextView naziv = listItem.FindViewById<TextView>(Resource.Id.dogadjaj_element_naziv);
            //    naziv.Text = currentDogadjaj.naziv;

            //    TextView datum = listItem.FindViewById<TextView>(Resource.Id.dogadjaj_element_datum);
            //    datum.Text = currentDogadjaj.datum.ToString("dd.M.yyyy");

            //    Button button_info = listItem.FindViewById<Button>(Resource.Id.dogadjaj_element_info);
            //    button_info.Click += delegate
            //    {
            //        Intent intent = new Intent(mContext, typeof(SelectedEventActivity));
            //        intent.PutExtra("DogadjajID", currentDogadjaj.ID);
            //        mContext.StartActivity(intent);
            //    };
              
            //return listItem;
        }
    }
}