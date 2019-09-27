using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using TestPeople.Interfaces;
using TestPeople.Logic.Business.Dtos;
using TestPeople.Utilities;

namespace TestPeople.ViewHolders
{
    public class PeopleViewHolder : RecyclerView.ViewHolder
    {
        public LinearLayout LyContentCard { get; private set; }
        public TextView TvName { get; private set; }
        public LinearLayout LyContentPhone { get; private set; }
        public ImageView ImagePhone { get; private set; }
        public TextView TvPhone { get; private set; }
        public LinearLayout LyContentEmail { get; private set; }
        public TextView TvEmail { get; private set; }
        public RelativeLayout RyContentBtnViewPost { get; private set; }
        public Button Btn_view_post { get; private set; }
        public Button Btn_view_book { get; private set; }

        public PeopleViewHolder(View itemView, IPeople item, IList<People> listPeople) : base(itemView)
        {
            LyContentCard = itemView.FindViewById<LinearLayout>(Resource.Id.contentCard);
            TvName = itemView.FindViewById<TextView>(Resource.Id.name);
            LyContentPhone = itemView.FindViewById<LinearLayout>(Resource.Id.contentPhone);
            ImagePhone = itemView.FindViewById<ImageView>(Resource.Id.imagePhone);
            TvPhone = itemView.FindViewById<TextView>(Resource.Id.phone);
            LyContentEmail = itemView.FindViewById<LinearLayout>(Resource.Id.contentEmail);
            TvEmail = itemView.FindViewById<TextView>(Resource.Id.email);
            RyContentBtnViewPost = itemView.FindViewById<RelativeLayout>(Resource.Id.contentBtnViewPost);
            Btn_view_post = itemView.FindViewById<Button>(Resource.Id.btn_view_post);
            Btn_view_post.Click += delegate { item.OnItemSelected(listPeople[AdapterPosition], (int)NavigationAction.ShowPeople); };

            Btn_view_book = itemView.FindViewById<Button>(Resource.Id.btn_view_book);
            Btn_view_book.Click += delegate { item.OnItemSelected(listPeople[AdapterPosition], (int)NavigationAction.ShowBooks); };
        }
    }
}