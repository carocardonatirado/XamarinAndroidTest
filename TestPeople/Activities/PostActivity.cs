using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using Newtonsoft.Json;
using TestPeople.Adapters;
using TestPeople.Logic.Business.Dtos;
using TestPeople.Logic.Business.Managers;
using TestPeople.Logic.Repositories.Remote.Base;
using TestPeople.Utilities;

namespace TestPeople.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", ScreenOrientation = ScreenOrientation.Portrait)]

    public class PostActivity : BaseActivity
    {
        [InjectView(Resource.Id.contentUserInfo)]
        private CardView CardcontentUserInfo;

        [InjectView(Resource.Id.contentCard)]
        private LinearLayout LyContentCard;

        [InjectView(Resource.Id.name)]
        private TextView TvName;

        [InjectView(Resource.Id.contentPhone)]
        private LinearLayout LyContentPhone;

        [InjectView(Resource.Id.imagePhone)]
        private ImageView ImagePhone;

        [InjectView(Resource.Id.phone)]
        private TextView TvPhone;

        [InjectView(Resource.Id.contentEmail)]
        private LinearLayout LyContentEmail;

        [InjectView(Resource.Id.email)]
        private TextView TvEmail;

        [InjectView(Resource.Id.titlePosts)]
        private TextView TvTitlePosts;

        [InjectView(Resource.Id.recyclerViewPostsResults)]
        private RecyclerView recyclerViewPostsResults;

        private PostAdapter _PostAdapter;
        private People _Person;
        private PostManager _PostsManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_post);
            Cheeseknife.Inject(this);
            _PostsManager = new PostManager(new PostService(DeviceManager.Instance));

            Bundle bundle = Intent.Extras;

            if (bundle != null)
            {
                if (!string.IsNullOrEmpty(Intent.Extras.GetString("person")))
                {
                   
                    _Person = JsonConvert.DeserializeObject<People>(Intent.Extras.GetString("person"));
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

        public async Task GetPostsAsync()
        {
            try
            {
                PostsResponse _postsResponse = await _PostsManager.GetPosts(_Person.Id);

                if (_postsResponse != null && _postsResponse.Posts != null && _postsResponse.Posts.Any())
                {                   
                    DrawPosts(_postsResponse.Posts);                   
                }
            }
            catch (Exception exception)
            {
                Console.Write($" : {exception}");
            }
        }
    }
}

