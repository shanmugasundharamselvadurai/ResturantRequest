using System;
using System.Collections.Generic;
using Source.Data.Models;
using Source.Data.PageViewModel;
using Xamarin.Forms;

namespace Source.Presentation.Pages.Category
{
    public partial class ListDetailCategoryPage : ContentPage
    {
        public ListDetailCategoryPage(ResturantCategory resturant)
        {
            InitializeComponent();

            ListDetailCategoryPageModel listDetail = new ListDetailCategoryPageModel(resturant);
            BindingContext = listDetail;
        }
    }
}
