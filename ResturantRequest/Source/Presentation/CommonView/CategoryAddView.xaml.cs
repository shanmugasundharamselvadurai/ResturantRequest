using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Source.Data.PageViewModel;
using Xamarin.Forms;

namespace Source.Presentation.CommonView
{
    public partial class CategoryAddView : PopupPage
    {
        public CategoryAddView()
        {
            InitializeComponent();
            CategoryAddViewModel cateView = new CategoryAddViewModel();
            BindingContext = cateView;
        }

        void CustomPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
        }

        void PopupPage_BackgroundClicked(System.Object sender, System.EventArgs e)
        {
             PopupNavigation.Instance.PopAsync();
        }
    }
}
