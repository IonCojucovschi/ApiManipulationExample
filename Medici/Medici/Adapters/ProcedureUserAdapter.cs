
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medici.Extensions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Medici.Models.AdapterHelpers;

namespace Medici.Adapters
{

    public class ProcedureUserAdapter : BaseAdapter<ProcedureModel>
    {
        public List<ProcedureModel> list;
        Activity context;
        public ProcedureUserAdapter(Activity context, List<ProcedureModel> _list)
        {
            this.context = context;
            list = _list;
        }


        public override ProcedureModel this[int position]
        {
            get
            {
                return list[position];
            }
        }

        public override int Count
        {
            get
            {
                return list.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = list[position];

            if (convertView == null)
            {
                if (!item.isExpanded)
                {
                    convertView = context.LayoutInflater.Inflate(Resource.Layout.programation_item_view, null);
                }
                else
                {
                    convertView = context.LayoutInflater.Inflate(Resource.Layout.expanded_item_view, null);
                }
            }
            
            convertView.FindViewById<TextView>(Resource.Id.name_proc).Text = item.name;
            convertView.FindViewById<TextView>(Resource.Id.day_proc).Text = item.date.DateFormatter();
            convertView.FindViewById<TextView>(Resource.Id.hour_proc).Text = item.hour;
            convertView.FindViewById<TextView>(Resource.Id.comment_content_proc).Text =item.isExpanded ? item.coment.Replace("%20", " ") : "";
            return convertView;
        }
    }
}
