using System;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Widget;
using Source.Presentation.CustomRenders;
using MLM.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRender))]
namespace MLM.Droid.Renders
{
    [Preserve(AllMembers = true)]
    public class CustomSearchBarRender:SearchBarRenderer
    {
        public CustomSearchBarRender(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.SearchBar> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                //var plateId = Resources.GetIdentifier("android:id/search_plate", null, null);
                //var plate = Control.FindViewById(plateId);
                //plate.SetBackgroundColor(Android.Graphics.Color.Transparent);
                //Control.SetPadding(10, 10, 10, 10);
                //Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
                //Control.Background = Android.App.Application.Context.GetDrawable(Resource.Drawable.roundedSearchButton);
                //Control.SetPadding(10, 10, 10, 10);

                //var color = global::Xamarin.Forms.Color.LightGray;
                var searchView = Control as SearchView;

                int searchPlateId = searchView.Context.Resources.GetIdentifier("android:id/search_plate", null, null);
                Android.Views.View searchPlateView = searchView.FindViewById(searchPlateId);
                searchView.SetPadding(10, 10, 10, 10);
                searchPlateView.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}
