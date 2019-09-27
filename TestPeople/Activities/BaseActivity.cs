using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace TestPeople.Activities
{
    [Activity(Label = "BaseActivity")]
    public class BaseActivity : AppCompatActivity
    {
        //[InjectView(Resource.Id.toolbar)]
       // protected Android.Support.V7.Widget.Toolbar toolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Couchbase.Lite.Support.Droid.Activate(this);
        }

        public void InitToolbar()
        {
           // SetSupportActionBar(toolbar);
         //   SupportActionBar.Title = "App Demo";
        }
    }
}