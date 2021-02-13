using System;
using Android.Content;
using Android.Runtime;
using Source.Presentation.CustomRenders;
using MLM.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton1), typeof(CustomButtonRender1))]
namespace MLM.Droid.Renders
{
    [Preserve(AllMembers = true)]
    public class CustomButtonRender1 : ButtonRenderer
    {
        public CustomButtonRender1(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
               // Control.Background = Android.App.Application.Context.GetDrawable(Resource.Drawable.round_corner_button1);
                Control.SetPadding(10, 10, 10, 10);
            }
        }
    }
}
