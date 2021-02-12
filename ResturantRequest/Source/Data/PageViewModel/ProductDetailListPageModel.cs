using System;
using System.Collections.ObjectModel;
using System.Linq;
using Source.Data.Interface;
using Source.Data.Models;
using Source.Data.PageViewModel.Base;
using SQLite;
using Xamarin.Forms;

namespace Source.Data.PageViewModel
{
    public class ProductDetailListPageModel: BasePageModel
    {
        SaveProduct resturant;
        public SQLiteConnection conn;

        public ProductDetailListPageModel(SaveProduct selectedValues)
        {
            // saved Values
            NameText = selectedValues.ProductName;
            DescriptionText = selectedValues.Description;
            PriceText = selectedValues.price;
            categorySelectedValue = selectedValues.Category;
            selectedID = selectedValues.ID;

            _saveProducts = new ObservableCollection<SaveProduct>();
            _listofCategory = new ObservableCollection<ResturantCategory>();
            conn = DependencyService.Get<Isqlite>().GetConnection();
            conn.CreateTable<SaveProduct>();
          
            var categoryDetails = (from x in conn.Table<ResturantCategory>() select x).ToList();
            if (categoryDetails != null && categoryDetails.Count != 0)
            {
                foreach (var value in categoryDetails.OrderByDescending(o => o.ID))
                {
                    ListofCategory.Add(new ResturantCategory
                    {
                        Category = value.Category,
                    });
                }
            }
            else
            {

            }
        }

        public Command UpdateProductCommand => new Command(async () => {
            // update 
            resturant = new SaveProduct();
            resturant.ID = selectedID;
            resturant.ProductName = NameText;
            resturant.Description = DescriptionText;
            resturant.Image = "plate2";
            resturant.Category = categorySelectedValue;
            resturant.price = PriceText;
            int xd = 0;
            try
            {
                xd = conn.Update(resturant);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (xd == 1)
            {
                MessagingCenter.Send<ProductDetailListPageModel>(this, "update");
                await Application.Current.MainPage.Navigation.PopModalAsync();
                //Success
            }
            else
            {
                //Error
            }
        });

        public Command DismissCommand => new Command(async () => {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        });
        

        private ObservableCollection<ResturantCategory> _listofCategory;
        public ObservableCollection<ResturantCategory> ListofCategory
        {
            get { return _listofCategory; }
            set
            {
                _listofCategory = value;
                OnPropertyChanged("ListofCategory");
            }
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

        private string _PriceText;
        public string PriceText
        {
            get { return _PriceText; }
            set { _PriceText = value; OnPropertyChanged("PriceText"); }
        }

        private string _categorySelectedValue;
        public string categorySelectedValue
        {
            get { return _categorySelectedValue; }
            set { _categorySelectedValue = value; OnPropertyChanged("categorySelectedValue"); }
        }

        private int _selectedID;
        public int selectedID
        {
            get { return _selectedID; }
            set { _selectedID = value; OnPropertyChanged("selectedID"); }
        }

        private void selectedCatagoryValue()
        {
            categorySelectedValue = SelectedItem.Category;
        }

        private ResturantCategory _selectedItem;
        public ResturantCategory SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                selectedCatagoryValue();
                _selectedItem = null;
                OnPropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<SaveProduct> _saveProducts;
        public ObservableCollection<SaveProduct> SaveProducts
        {
            get { return _saveProducts; }
            set { _saveProducts = value; OnPropertyChanged("SaveProducts"); }
        }
    }
}
