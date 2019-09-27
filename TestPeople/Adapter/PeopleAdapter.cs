using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using TestPeople.ViewHolders;
using TestPeople.Interfaces;
using TestPeople.Logic.Business.Dtos;

namespace TestPeople.Adapters
{
    public class PeopleAdapter : RecyclerView.Adapter
    {
        private IList<People> ListPeople { get; set; }
        private Context Context { get; set; }
        private IPeople PeopleInterface { get; set; }
        private PeopleViewHolder PeopleViewHolder { get; set; }
        private int LayoutHeight { get; set; }

        public PeopleAdapter(IList<People> ListPeople, Context Context, IPeople PeopleInterface)
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
            People _Person = ListPeople[position];
            PeopleViewHolder.TvName.Text = _Person.Name;
            PeopleViewHolder.TvPhone.Text = _Person.Phone;
            PeopleViewHolder.TvEmail.Text = _Person.Email;
        }

        public override int ItemCount
        {
            get { return ListPeople != null ? ListPeople.Count() : 0; }
        }

        public void UpdateList(IList<People> NewListPeople)
        {
            ListPeople = new List<People>();
            ListPeople = NewListPeople;
            NotifyDataSetChanged();
        }
    }
}