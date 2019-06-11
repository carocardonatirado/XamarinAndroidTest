using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace TestPeople
{
    [Activity(Label = "BaseActivity")]
    public class BaseActivity : AppCompatActivity
    {

        private ProgressDialog progressDialog;
        public ProgressDialog ProgressDialog { get => progressDialog; set => progressDialog = value; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Couchbase.Lite.Support.Droid.Activate(this);
            CreateDialog();
        }

        public void CreateDialog()
        {
            progressDialog = new ProgressDialog(this);
            progressDialog.SetIcon(Resource.Mipmap.ic_launcher);
            progressDialog.SetMessage("Cargando...");
        }
    }
}