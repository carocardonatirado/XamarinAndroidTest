using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Entities.Business;
using System.Collections.Generic;
using System.Linq;
using TestPeople.Android.ViewHolders;

namespace TestPeople.Android.Adapters
{
    public class PostAdapter : RecyclerView.Adapter
    {
        private IList<Post> ListPost { get; set; }
        private Context Context { get; set; }
        private PostViewHolder _PostViewHolder { get; set; }
        private int LayoutHeight { get; set; }

        public PostAdapter(IList<Post> ListPost, Context Context)
        {
            this.ListPost = ListPost;
            this.Context = Context;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.post_list_item, parent, false);

            PostViewHolder postViewHolder = new PostViewHolder(itemView, ListPost);

            return postViewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            _PostViewHolder = holder as PostViewHolder;
            Post _Post = ListPost[position];

            _PostViewHolder.TvTitle.Text = _Post.Title;
            _PostViewHolder.TvBody.Text = _Post.Body;
        }

        public override int ItemCount
        {
            get { return ListPost != null ? ListPost.Count() : 0; }
        }
    }
}