using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MurphyPubAndroid
{
    public class PromocijaAdapter : ArrayAdapter<Promocija>
    {
        private Context mContext;
        private List<Promocija> promocije = new List<Promocija>();

        public PromocijaAdapter(Context context, List<Promocija> list)
            : base(context, 0, list)
        {
            mContext = context;
            promocije = list;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View listItem = convertView;

            Promocija currentPromocija = promocije[position];

            if (listItem == null)
                listItem = currentPromocija.tip.ToUpper() == "PRIV" ?
                    LayoutInflater.From(mContext).Inflate(Resource.Layout.Element_promocija_priv, parent, false)
                    :
                    LayoutInflater.From(mContext).Inflate(Resource.Layout.Element_promocija_fiks, parent, false);

            switch (currentPromocija.tip.ToUpper())
            {
                case "PRIV":

                    ImageView imagePriv = listItem.FindViewById<ImageView>(Resource.Id.promotion_priv_element_image_placeholder);
                    Task.Run(() => JSONParser.SetImageWithURL(mContext, imagePriv, currentPromocija.slika));

                    TextView nazivPriv = listItem.FindViewById<TextView>(Resource.Id.promocija_priv_element_naziv);
                    nazivPriv.Text = currentPromocija.naziv;

                    TextView cenaPriv = listItem.FindViewById<TextView>(Resource.Id.promocija_priv_element_cena);
                    cenaPriv.Text = currentPromocija.cena + " RSD";

                    TextView datumPriv = listItem.FindViewById<TextView>(Resource.Id.promocija_priv_element_datum);
                    datumPriv.Text = "Promocija traje do:\n" + currentPromocija.datum.ToString("dd.M.yyyy");

                    Button button_infoPriv = listItem.FindViewById<Button>(Resource.Id.promocija_priv_element_info);

                    button_infoPriv.Click += delegate
                    {
                        Intent intent = new Intent(mContext, typeof(SelectedPromotionActivity));
                        intent.PutExtra("PromocijaID", currentPromocija.ID);
                        mContext.StartActivity(intent);
                    };
                    break;
                case "FIKS":

                    ImageView imageFiks = listItem.FindViewById<ImageView>(Resource.Id.promotion_fiks_element_image_placeholder);
                    Task.Run(() => JSONParser.SetImageWithURL(mContext, imageFiks, currentPromocija.slika));

                    TextView nazivFiks = listItem.FindViewById<TextView>(Resource.Id.promocija_fiks_element_naziv);
                    nazivFiks.Text = currentPromocija.naziv;

                    Button button_infoFiks = listItem.FindViewById<Button>(Resource.Id.promocija_fiks_element_info);
                    button_infoFiks.Click += delegate
                    {
                        Intent intent = new Intent(mContext, typeof(SelectedPromotionActivity));
                        intent.PutExtra("PromocijaID", currentPromocija.ID);
                        mContext.StartActivity(intent);
                    };
                    break;
            }
            return listItem;
        }
    }
}