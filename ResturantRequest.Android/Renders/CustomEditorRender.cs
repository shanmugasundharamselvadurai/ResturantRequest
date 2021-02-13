using System;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Source.Presentation.CustomRenders;
using MLM.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRender))]
namespace MLM.Droid.Renders
{
    public class CustomEditorRender:EditorRenderer
    {
        CustomEditor element;
        public CustomEditorRender(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            element = (CustomEditor)this.Element;
            var editerText = this.Control;
            Control.TextAlignment = Android.Views.TextAlignment.TextStart;
           // Control.Background = Android.App.Application.Context.GetDrawable(Resource.Drawable.roundedSearchButton);
            Control.Gravity = GravityFlags.Start;
            Control.SetPadding(10, 10, 10, 10);
            Control.Background.SetColorFilter(element.BackgroundColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
        }
    }
}
