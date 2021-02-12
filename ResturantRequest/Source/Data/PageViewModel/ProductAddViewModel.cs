using System;
using System.Collections.ObjectModel;
using System.Linq;
using Rg.Plugins.Popup.Services;
using Source.Data.Interface;
using Source.Data.Models;
using Source.Data.PageViewModel.Base;
using SQLite;
using Xamarin.Forms;

namespace Source.Data.PageViewModel
{
    public class ProductAddViewModel: BasePageModel
    {
        public SQLiteConnection conn;
        SaveProduct resturant;
        public ProductAddViewModel()
        {
            _saveProducts = new ObservableCollection<SaveProduct>();
            _listofCategory = new ObservableCollection<ResturantCategory>();
            conn = DependencyService.Get<Isqlite>().GetConnection();
            conn.CreateTable<SaveProduct>();


            var categoryDetails = (from x in conn.Table<ResturantCategory>() select x).ToList();

            if (categoryDetails != null && categoryDetails.Count != 0)
            {
                //IsVibleCategoryStackLayout = false;
                //IsVibleListviewCategoryStackLayout = true;

                foreach (var value in categoryDetails.OrderByDescending(o => o.ID))
                {
                    ListofCategory.Add(new ResturantCategory
                    {
                        Category = value.Category,
                    });
                }
            }
        }

        public Command SaveProductCommand => new Command(() => {

            resturant = new SaveProduct();
            resturant.ProductName = NameText;
            resturant.Description = DescriptionText;
            resturant.Image = "plate2";
            resturant.Category = categorySelectedValue;
            resturant.price = PriceText;
            int x = 0;
            try
            {
                x = conn.Insert(resturant);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (x == 1)
            {
                MessagingCenter.Send<ProductAddViewModel>(this, "SavedValue");
                PopupNavigation.Instance.PopAsync();
                //Success
            }
            else
            {
                //Error
            }
        });


        public Command DismissCommand => new Command(() =>
        {
            PopupNavigation.Instance.PopAsync();
        });

        private ObservableCollection<SaveProduct> _saveProducts;
        public ObservableCollection<SaveProduct> SaveProducts
        {
            get { return _saveProducts; }
            set { _saveProducts = value; OnPropertyChanged("SaveProducts"); }
        }

        private ObservableCollection<ResturantCategory> _listofCategory;
        public ObservableCollection<ResturantCategory> ListofCategory
        {
            get { return _listofCategory; }
            set { _listofCategory = value;
                OnPropertyChanged("ListofCategory"); }
        }

        private string _NameText;
        public string NameText
        {
            get { return _NameText; }
            set { _NameText = value; OnPropertyChanged("NameText"); }
        }

        private string _DescriptionText;
        public string DescriptionText
        {
            get { return _DescriptionText; }
            set { _DescriptionText = value; OnPropertyChanged("DescriptionText"); }
        }

        private string _categorySelectedValue;
        public string categorySelectedValue 
        {
            get { return _categorySelectedValue; }
            set { _categorySelectedValue = value; OnPropertyChanged("categorySelectedValue"); }
        }

        private ResturantCategory _selectedItem;
        public  ResturantCategory SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value;
                selectedCatagoryValue();
                _selectedItem = null;
                OnPropertyChanged("SelectedItem"); }
        }

        private void selectedCatagoryValue()
        {
            categorySelectedValue = SelectedItem.Category;
        }
        private string _PriceText;
        public string PriceText
        {
            get { return _PriceText; }
            set { _PriceText = value; OnPropertyChanged("PriceText"); }
        }
    }
}
