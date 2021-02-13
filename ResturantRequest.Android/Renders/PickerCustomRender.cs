using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Source.Presentation.CustomRenders;
using MLM.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content.Res;
using Android.OS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(PickerCustomRender))]
namespace MLM.Droid.Renders
{
	[Preserve(AllMembers = true)]
	public class PickerCustomRender : PickerRenderer
	{
		CustomPicker element;
		public PickerCustomRender(Context context) : base(context)
		{

		}
		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);
			if (Control == null || e.NewElement == null) return;
			//for example ,change the line to red:
			if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
				Control.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
			else
				Control.Background.SetColorFilter(Android.Graphics.Color.Red, PorterDuff.Mode.SrcAtop);
		}
	}
}

