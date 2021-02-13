using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Text;
using Android.Views;
using Source.Presentation.CustomRenders;
using MLM.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Renders;
[assembly: ExportRenderer(typeof(CustomEntry), typeof(EntryCustomEntry))]
namespace MLM.Droid
{
    [Preserve(AllMembers = true)]
    public class EntryCustomEntry: EntryRenderer
    {

        #region Private fields and properties

        private BorderRenderer _renderer;
        private const GravityFlags DefaultGravity = GravityFlags.CenterVertical;

        #endregion

        CustomEntry element;
        public EntryCustomEntry(Context context) : base(context)
        {
             AutoPackage = false;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || e.NewElement == null)
                return;

            element = (CustomEntry)this.Element;

            var editText = this.Control;

            var entryEx = Element as CustomEntry;
            UpdateBackground(entryEx);
            UpdatePadding(entryEx);
            UpdateTextAlighnment(entryEx);

            //if (!string.IsNullOrEmpty(element.Image))
            //{
            //    //switch (element.ImageAlignment)
            //    //{
            //    //    case ImageAlignment.Left:
            //    //        editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.Image), null, null, null);
            //    //        break;
            //    //    case ImageAlignment.Right:
            //    //        editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.Image), null);
            //    //        break;
            //    //}
            //    //  UpdateBorders();

            //}

            //editText.CompoundDrawablePadding = 25;
            //editText.Gravity = GravityFlags.CenterVertical;
            //editText.SetPadding(10, 10, 10, 10);

            //editText.Background = new ColorDrawable(Android.Graphics.Color.Transparent);


            // editText.Background.SetColorFilter(element.LineColor.ToAndroid(), Android.Graphics.Color.White);
            // editText.Background =  Android.App.Application.Context.GetColor(Resource.Color.ripple_material_light);

        }
        //private BitmapDrawable GetDrawable(string imageEntryImage)
        //{
        //    int resID = Resources.GetIdentifier(imageEntryImage, "drawable", this.Context.PackageName);
        //    var drawable = ContextCompat.GetDrawable(this.Context, resID);
        //    var bitmap = ((BitmapDrawable)drawable).Bitmap;
        //    return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, element.ImageWidth * 2, element.ImageHeight * 2, true));
        //}

        //protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);

        //    if (Control == null) return;

        ////    this.Control.SetRawInputType(InputTypes.ClassText);
        //    //GradientDrawable gd = new GradientDrawable();

        //    //gd.SetColor(global::Android.Graphics.Color.Transparent);
        //    //this.Control.SetBackgroundDrawable(gd);
        //    //this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
        //    //Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.White));
        //    //if (e.PropertyName == CustomEntry.IsBorderErrorVisibleProperty.PropertyName)
        //    //    UpdateBorders();
        //}



        #region Utility methods

        private void UpdateBackground(CustomEntry entryEx)
        {
            if (_renderer != null)
            {
                _renderer.Dispose();
                _renderer = null;
            }
            _renderer = new BorderRenderer();

            Control.Background = _renderer.GetBorderBackground(entryEx.BorderColor, entryEx.BackgroundColor, entryEx.BorderWidth, entryEx.BorderRadius);
        }

        private void UpdatePadding(CustomEntry entryEx)
        {
            Control.SetPadding((int)Forms.Context.ToPixels(entryEx.LeftPadding), 0,
                (int)Forms.Context.ToPixels(entryEx.RightPadding), 0);
        }

        private void UpdateTextAlighnment(CustomEntry entryEx)
        {
            var gravity = DefaultGravity;
            switch (entryEx.HorizontalTextAlignment)
            {
                case Xamarin.Forms.TextAlignment.Start:
                    gravity |= GravityFlags.Start;
                    break;
                case Xamarin.Forms.TextAlignment.Center:
                    gravity |= GravityFlags.CenterHorizontal;
                    break;
                case Xamarin.Forms.TextAlignment.End:
                    gravity |= GravityFlags.End;
                    break;
            }
            Control.Gravity = gravity;
        }

        #endregion
    }

    //void UpdateBorders()
    //{
    //    GradientDrawable shape = new GradientDrawable();
    //    shape.SetShape(ShapeType.Rectangle);
    //    shape.SetCornerRadius(0);

    //    if (((CustomEntry)this.Element).IsBorderErrorVisible)
    //    {
    //        shape.SetStroke(3, ((CustomEntry)this.Element).BorderErrorColor.ToAndroid());
    //    }
    //    else
    //    {
    //        shape.SetStroke(3, Android.Graphics.Color.LightGray);
    //        this.Control.SetBackground(shape);
    //    }

    //    this.Control.SetBackground(shape);
    //}
}

