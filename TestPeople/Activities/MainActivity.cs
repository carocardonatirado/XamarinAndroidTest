using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using DTestPeople.Logic.Repositories.Remote;
using Newtonsoft.Json;
using TestPeople.Adapters;
using TestPeople.Interfaces;
using TestPeople.Logic.Business.Dtos;
using TestPeople.Logic.Business.Managers;
using TestPeople.Logic.Repositories.Local;
using TestPeople.Utilities;

namespace TestPeople.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]

    public class MainActivity : BaseActivity, IPeople
    {
        [InjectView(Resource.Id.editTextSearch)]
        private EditText EditTextSearch;

        [InjectView(Resource.Id.recyclerViewSearchResults)]
        private RecyclerView recyclerViewSearchResults;

        [InjectView(Resource.Id.progressDialog)]
        public ProgressBar progressDialog;

        [InjectView(Resource.Id.content)]
        public RelativeLayout content;

        private PeopleAdapter _PeopleAdapter;
        private PeopleManager _PeopleModel;
        private IList<People> people;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Cheeseknife.Inject(this);
            //InitToolbar();

            _PeopleModel = new PeopleManager(new PeopleService(DeviceManager.Instance), new DocumentsDataBase());

            //progressDialog = FindViewById<ProgressBar>(Resource.Id.progressDialog);
            //EditTextSearch = FindViewById<EditText>(Resource.Id.editTextSearch);
            //recyclerViewSearchResults = FindViewById<RecyclerView>(Resource.Id.recyclerViewSearchResults);
            //EditTextSearch.TextChanged += InputSearchOnTextChanged;

            this.RunOnUiThread(async () =>
            {
                await GetPeopleAsync();
            });
        }

        public async Task GetPeopleAsync()
        {
            try
            {
                PeopleResponse _PeopleResponse = await _PeopleModel.GetPeople();

                if (_PeopleResponse != null && _PeopleResponse.People != null && _PeopleResponse.People.Any())
                {
                    people = _PeopleResponse.People;
                    DrawPeople();
                }

                progressDialog.Visibility = ViewStates.Gone;
                content.Visibility = ViewStates.Visible;
            }
            catch (Exception exeption)
            {
                Console.Write($"GetPeopleAsync: {exeption}");
            }
        }

        public void DrawPeople()
        {
            LinearLayoutManager linerLayoutManager = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);
            recyclerViewSearchResults.HasFixedSize = false;
            recyclerViewSearchResults.SetLayoutManager(linerLayoutManager);
            _PeopleAdapter = new PeopleAdapter(people, this, this);
            recyclerViewSearchResults.SetAdapter(_PeopleAdapter);
        }

        public void OnItemSelected(People person, int action)
        {
            Intent intent;


            switch (action)
            {
                case (int)NavigationAction.ShowPeople:
                    intent = new Intent(this, typeof(PostActivity));
                    intent.PutExtra("person", JsonConvert.SerializeObject(person));
                    StartActivity(intent);
                    break;
                case (int)NavigationAction.ShowBooks:
                    intent = new Intent(this, typeof(BookActivity));
                    StartActivity(intent);
                    break;
                default:
                   
                    break;
            }
        }

        [InjectOnTextChanged(Resource.Id.editTextSearch)]
        private void InputSearchOnTextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (people != null && people.Any())
            {
                string filter = EditTextSearch.Text.Trim();

                IList<People> newListPerson = new List<People>();

                if (filter != null)
                {
                    foreach (People person in people)
                    {
                        if (person.Name.ToUpper().Contains(filter.ToUpper()))
                        {
                            newListPerson.Add(person);
                        }
                    }
                }

                if (newListPerson == null || !newListPerson.Any())
                {
                    newListPerson.Clear();
                }

                _PeopleAdapter.UpdateList(newListPerson);
            }
        }
    }
}

