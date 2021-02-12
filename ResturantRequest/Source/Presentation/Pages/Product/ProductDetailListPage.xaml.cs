using System;
using System.Collections.Generic;
using Source.Data.Models;
using Source.Data.PageViewModel;
using Xamarin.Forms;

namespace Source.Presentation.Pages.Product
{
    public partial class ProductDetailListPage : ContentPage
    {
        public ProductDetailListPage(SaveProduct selectedValues)
        {
            InitializeComponent();
            ProductDetailListPageModel productDetail = new ProductDetailListPageModel(selectedValues);
            BindingContext = productDetail;
        }

        public Command AddCategoryCommands => new Command(async () => {
           // await PopupNavigation.Instance.PushAsync(new CategoryAddView());
        });
    }
}
