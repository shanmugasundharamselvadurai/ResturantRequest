using System;
using System.Collections.Generic;
using Source.Data.PageViewModel;
using Xamarin.Forms;

namespace Source.Presentation.Pages.Category
{
    public partial class ListCategoryPage : ContentPage
    {
        public ListCategoryPage()
        {
            InitializeComponent();
            CategoryPageModel category = new CategoryPageModel();
            BindingContext = category;
    
        }
    }
}
