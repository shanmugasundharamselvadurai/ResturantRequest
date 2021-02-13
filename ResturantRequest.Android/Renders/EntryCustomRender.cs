using Android.Content;
using Android.Graphics.Drawables;
using Source.Presentation.CustomRenders;
using MLM.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryRender), typeof(EntryCustomRender))]

namespace MLM.Droid.Renders
{
    public class EntryCustomRender: EntryRenderer
    {
        public EntryCustomRender(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
           
        }
    }
}
