package crc64c4109e38bafbaf7d;


public class ExtendedShadowView
	extends com.telerik.android.primitives.widget.shadow.RadShadowView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_shouldDrawTextShadow:(Landroid/view/View;)Z:GetShouldDrawTextShadow_Landroid_view_View_Handler\n" +
			"";
		mono.android.Runtime.register ("Telerik.XamarinForms.PrimitivesRenderer.Android.ExtendedShadowView, Telerik.XamarinForms.Primitives", ExtendedShadowView.class, __md_methods);
	}


	public ExtendedShadowView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ExtendedShadowView.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.PrimitivesRenderer.Android.ExtendedShadowView, Telerik.XamarinForms.Primitives", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public ExtendedShadowView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ExtendedShadowView.class)
			mono.android.TypeManager.Activate ("Telerik.XamarinForms.PrimitivesRenderer.Android.ExtendedShadowView, Telerik.XamarinForms.Primitives", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public boolean shouldDrawTextShadow (android.view.View p0)
	{
		return n_shouldDrawTextShadow (p0);
	}

	private native boolean n_shouldDrawTextShadow (android.view.View p0);

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
