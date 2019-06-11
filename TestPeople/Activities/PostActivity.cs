using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using DataAgent.Services;
using Entities.Business;
using Entities.Response;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPeople.Android.Adapters;
using TestPeople.Utilities;

namespace TestPeople
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]

    public class PostActivity : BaseActivity
    {
        private CardView CardcontentUserInfo;
        private LinearLayout LyContentCard;
        private TextView TvName;
        private LinearLayout LyContentPhone;
        private ImageView ImagePhone;
        private TextView TvPhone;
        private LinearLayout LyContentEmail;
        private TextView TvEmail;
        private TextView TvTitlePosts;
        private RecyclerView recyclerViewPostsResults;
        private PostAdapter _PostAdapter;
        private Person _Person;
        private PostModel _PostsModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _PostsModel = new PostModel(new PostService(DeviceManager.Instance));
            SetContentView(Resource.Layout.activity_post);
            CardcontentUserInfo = FindViewById<CardView>(Resource.Id.contentUserInfo);
            LyContentCard = FindViewById<LinearLayout>(Resource.Id.contentCard);
            TvName = FindViewById<TextView>(Resource.Id.name);
            LyContentPhone = FindViewById<LinearLayout>(Resource.Id.contentPhone);
            ImagePhone = FindViewById<ImageView>(Resource.Id.imagePhone);
            TvPhone = FindViewById<TextView>(Resource.Id.phone);
            LyContentEmail = FindViewById<LinearLayout>(Resource.Id.contentEmail);
            TvEmail = FindViewById<TextView>(Resource.Id.email);
            TvTitlePosts = FindViewById<TextView>(Resource.Id.titlePosts);
            recyclerViewPostsResults = FindViewById<RecyclerView>(Resource.Id.recyclerViewPostsResults);

            Bundle bundle = Intent.Extras;

            if (bundle != null)
            {
                if (!string.IsNullOrEmpty(Intent.Extras.GetString("person")))
                {
                    ProgressDialog.Show();
                    _Person = JsonConvert.DeserializeObject<Person>(Intent.Extras.GetString("person"));
                    TvName.Text = _Person.Name;
                    TvPhone.Text = _Person.Phone;
                    TvEmail.Text = _Person.Email;

                    this.RunOnUiThread(async () =>
                    {
                        await GetPostsAsync();
                    });
                }
            }
        }

        public void DrawPosts(IList<Post> posts)
        {
            LinearLayoutManager linerLayoutManager = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);
            recyclerViewPostsResults.HasFixedSize = false;
            recyclerViewPostsResults.SetLayoutManager(linerLayoutManager);
            _PostAdapter = new PostAdapter(posts, this);
            recyclerViewPostsResults.SetAdapter(_PostAdapter);
        }

        public void OnItemSelected(Post people)
        {
        }

        public async Task GetPostsAsync()
        {
            try
            {
                PostsResponse _postsResponse = await _PostsModel.GetPosts(_Person.Id);

                if (_postsResponse != null && _postsResponse.Posts != null && _postsResponse.Posts.Any())
                {                   
                    DrawPosts(_postsResponse.Posts);                   
                }

                ProgressDialog.Dismiss();
            }
            catch (Exception exeption)
            {
            }
        }
    }
}

