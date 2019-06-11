package md5a400e215935e8be435de314bdbadb9d0;


public class PeopleViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("TestPeople.Android.ViewHolders.PeopleViewHolder, TestPeople", PeopleViewHolder.class, __md_methods);
	}


	public PeopleViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == PeopleViewHolder.class)
			mono.android.TypeManager.Activate ("TestPeople.Android.ViewHolders.PeopleViewHolder, TestPeople", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
