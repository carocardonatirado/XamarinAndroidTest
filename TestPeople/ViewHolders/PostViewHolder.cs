using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Entities.Business;
using System.Collections.Generic;

namespace TestPeople.Android.ViewHolders
{
    public class PostViewHolder : RecyclerView.ViewHolder
    {
        public LinearLayout LyContentCard { get; private set; }
        public TextView TvTitle { get; private set; }
        public TextView TvBody { get; private set; }

        public PostViewHolder(View itemView, IList<Post> listPost) : base(itemView)
        {
            LyContentCard = itemView.FindViewById<LinearLayout>(Resource.Id.contentCard);
            TvTitle = itemView.FindViewById<TextView>(Resource.Id.title);
            TvBody = itemView.FindViewById<TextView>(Resource.Id.body);
        }
    }
}