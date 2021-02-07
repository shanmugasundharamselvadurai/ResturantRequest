using System;
using Xamarin.Forms;

namespace Source.Presentation.CustomRenders
{
    public class CustomPicker: Picker
    {
		public static readonly BindableProperty ImageProperty =
			BindableProperty.Create(nameof(Image), typeof(string), typeof(CustomPicker), null);

		public static readonly BindableProperty ImageAlignmentProperty =
		 BindableProperty.Create(nameof(ImageAlignment), typeof(ImageAlignment), typeof(CustomPicker), ImageAlignment.Right);

		public static readonly BindableProperty ImageHeightProperty =
		 BindableProperty.Create(nameof(ImageHeight), typeof(int), typeof(CustomPicker), 35);

		public static readonly BindableProperty ImageWidthProperty =
			BindableProperty.Create(nameof(ImageWidth), typeof(int), typeof(CustomPicker), 35);

		public string Image
		{
			get { return (string)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value); }
		}
        public int ImageWidth
        {
            get { return (int)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        public int ImageHeight
        {
            get { return (int)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        public ImageAlignment ImageAlignment
        {
            get { return (ImageAlignment)GetValue(ImageAlignmentProperty); }
            set { SetValue(ImageAlignmentProperty, value); }
        }
    }
}
