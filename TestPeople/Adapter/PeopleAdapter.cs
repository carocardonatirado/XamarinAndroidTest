using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Entities.Business;
using System.Collections.Generic;
using System.Linq;
using TestPeople.Android.ViewHolders;
using TestPeople.Interfaces;

namespace TestPeople.Android.Adapters
{
    public class PeopleAdapter : RecyclerView.Adapter
    {
        private IList<Person> ListPeople { get; set; }
        private Context Context { get; set; }
        private IPeople PeopleInterface { get; set; }
        private PeopleViewHolder PeopleViewHolder { get; set; }
        private int LayoutHeight { get; set; }

        public PeopleAdapter(IList<Person> ListPeople, Context Context, IPeople PeopleInterface)
        {
            this.ListPeople = ListPeople;
            this.Context = Context;
            this.PeopleInterface = PeopleInterface;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.user_list_item, parent, false);
            PeopleViewHolder peopleViewHolder = new PeopleViewHolder(itemView, PeopleInterface, ListPeople);
            return peopleViewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PeopleViewHolder = holder as PeopleViewHolder;
            Person _Person = ListPeople[position];
            PeopleViewHolder.TvName.Text = _Person.Name;
            PeopleViewHolder.TvPhone.Text = _Person.Phone;
            PeopleViewHolder.TvEmail.Text = _Person.Email;
        }

        public override int ItemCount
        {
            get { return ListPeople != null ? ListPeople.Count() : 0; }
        }

        public void UpdateList(IList<Person> NewListPeople)
        {
            ListPeople = new List<Person>();
            ListPeople = NewListPeople;
            NotifyDataSetChanged();
        }
    }
}