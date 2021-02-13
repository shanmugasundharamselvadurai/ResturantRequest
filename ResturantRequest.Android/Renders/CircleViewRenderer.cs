using System;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Source.Presentation.CustomRenders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CircleView), typeof(MLM.Droid.Renders.CircleViewRenderer))]
namespace MLM.Droid.Renders
{
    [Preserve(AllMembers = true)]
    public class CircleViewRenderer: BoxRenderer
    {
        private float _cornerRadius;
        private RectF _bounds;
        private Path _path;

        public CircleViewRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            if (Element == null)
            {
                return;
            }
            var element = (CircleView)Element;
            _cornerRadius = TypedValue.ApplyDimension(ComplexUnitType.Dip, (float)element.CornerRadius, Context.Resources.DisplayMetrics);
        }
        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);
            if (w != oldw && h != oldh)
            {
                _bounds = new RectF(0, 0, w, h);
            }
            _path = new Path();
            _path.Reset();
            _path.AddRoundRect(_bounds, _cornerRadius, _cornerRadius, Path.Direction.Cw);
            _path.Close();
        }
        public override void Draw(Canvas canvas)
        {
            canvas.Save();
            if(_path != null)
            {
              canvas.ClipPath(_path);
            }
            base.Draw(canvas);
            canvas.Restore();
        }
    }
}
