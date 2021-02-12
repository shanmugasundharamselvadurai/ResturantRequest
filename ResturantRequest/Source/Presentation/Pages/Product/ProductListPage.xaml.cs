using System;
using System.Collections.Generic;
using Source.Data.PageViewModel;
using Xamarin.Forms;

namespace Source.Presentation.Pages.Product
{
    public partial class ProductListPage : ContentPage
    {
        public ProductListPage()
        {
            InitializeComponent();
            ProductListPageModel productList = new ProductListPageModel();
            BindingContext = productList;
        }

    }
}
