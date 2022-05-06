package crc64487cbaa58c61bc25;


public class LegendRenderer
	extends crc644b19d71eeb53ff67.AndroidRendererBase_2
	implements
		mono.android.IGCUserPeer,
		com.telerik.android.common.CollectionChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_collectionChanged:(Lcom/telerik/android/common/CollectionChangedEvent;)V:GetCollectionChanged_Lcom_telerik_android_common_CollectionChangedEvent_Handler:Com.Telerik.Android.Common.ICollectionChangeListenerInvoker, Telerik.Xamarin.Android.Common\n" +
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.ChartRenderer.Android.LegendRenderer, Telerik.XamarinForms.Chart", LegendRenderer.class, __md_methods);
	}


	public LegendRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == LegendRenderer.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.ChartRenderer.Android.LegendRenderer, Telerik.XamarinForms.Chart", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public LegendRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == LegendRenderer.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.ChartRenderer.Android.LegendRenderer, Telerik.XamarinForms.Chart", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public LegendRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == LegendRenderer.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.ChartRenderer.Android.LegendRenderer, Telerik.XamarinForms.Chart", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void collectionChanged (com.telerik.android.common.CollectionChangedEvent p0)
	{
		n_collectionChanged (p0);
	}

	private native void n_collectionChanged (com.telerik.android.common.CollectionChangedEvent p0);

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
