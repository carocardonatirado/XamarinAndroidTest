package md571aaecef51ea3bd03a43b8d1b5c7534c;


public class PostActivity
	extends md571aaecef51ea3bd03a43b8d1b5c7534c.BaseActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("TestPeople.PostActivity, TestPeople", PostActivity.class, __md_methods);
	}


	public PostActivity ()
	{
		super ();
		if (getClass () == PostActivity.class)
			mono.android.TypeManager.Activate ("TestPeople.PostActivity, TestPeople", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
