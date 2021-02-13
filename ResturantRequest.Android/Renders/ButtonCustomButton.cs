using Android.Content;
using Android.Runtime;
using Source.Presentation.CustomRenders;
using MLM.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton), typeof(ButtonCustomButton))]
namespace MLM.Droid.Renders
{
    [Preserve(AllMembers = true)]
    public class ButtonCustomButton : ButtonRenderer
    {
        public ButtonCustomButton(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
               // Control.Background = Android.App.Application.Context.GetDrawable(Resource.Drawable);
                Control.SetPadding(10, 10, 10, 10);
            }

        }
    }
}
