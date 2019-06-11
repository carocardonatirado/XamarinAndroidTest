using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Widget;
using DataAgent.DataBase;
using DataAgent.Services;
using Entities.Business;
using Entities.Response;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TestPeople.Android.Adapters;
using TestPeople.Interfaces;
using TestPeople.Utilities;

namespace TestPeople
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]

    public class MainActivity : BaseActivity, IPeople
    {
        private EditText EditTextSearch;
        private RecyclerView recyclerViewSearchResults;
        private PeopleAdapter _PeopleAdapter;
        private PeopleModel _PeopleModel;
        private IList<Person> people;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            _PeopleModel = new PeopleModel(new PeopleService(DeviceManager.Instance), new DocumentsDataBase());
            EditTextSearch = FindViewById<EditText>(Resource.Id.editTextSearch);
            EditTextSearch.TextChanged += InputSearchOnTextChanged;
            recyclerViewSearchResults = FindViewById<RecyclerView>(Resource.Id.recyclerViewSearchResults);
            GetPeopleAsync();
        }

        public async void GetPeopleAsync()
        {
            try
            {
                ProgressDialog.Show();
                PeopleResponse _PeopleResponse = await _PeopleModel.GetPeople();

                if (_PeopleResponse != null && _PeopleResponse.People != null && _PeopleResponse.People.Any())
                {
                    people = _PeopleResponse.People;
                    DrawPeople();
                }

                ProgressDialog.Dismiss();
            }
            catch (Exception exeption)
            {
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

        public void OnItemSelected(Person person)
        {
            Intent intent = new Intent(this, typeof(PostActivity));
            intent.PutExtra("person", JsonConvert.SerializeObject(person));
            StartActivity(intent);
        }

        private void InputSearchOnTextChanged(object sender, TextChangedEventArgs args)
        {
            if (people != null && people.Any())
            {
                string filter = args.Text.ToString();

                IList<Person> newListPerson = new List<Person>();

                if (filter != null)
                {
                    foreach (Person person in people)
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

