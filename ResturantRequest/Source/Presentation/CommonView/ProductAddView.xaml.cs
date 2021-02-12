using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Source.Data.PageViewModel;
using Xamarin.Forms;

namespace Source.Presentation.CommonView
{
    public partial class ProductAddView : PopupPage
    {
        public ProductAddView()
        {
            InitializeComponent();
            ProductAddViewModel productModel = new ProductAddViewModel();
            BindingContext = productModel;
        }
    }
}
