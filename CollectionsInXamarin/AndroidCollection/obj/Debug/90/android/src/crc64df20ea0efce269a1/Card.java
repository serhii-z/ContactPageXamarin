package crc64df20ea0efce269a1;


public class Card
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("AndroidCollection.Card, AndroidCollection", Card.class, __md_methods);
	}


	public Card (android.view.View p0)
	{
		super (p0);
		if (getClass () == Card.class)
			mono.android.TypeManager.Activate ("AndroidCollection.Card, AndroidCollection", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
