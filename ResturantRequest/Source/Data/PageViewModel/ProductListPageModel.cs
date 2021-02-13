using System;
using System.Collections.ObjectModel;
using System.Linq;
using Rg.Plugins.Popup.Services;
using Source.Data.Interface;
using Source.Data.Models;
using Source.Data.PageViewModel.Base;
using Source.Presentation.CommonView;
using Source.Presentation.Pages.BottomTab;
using Source.Presentation.Pages.Product;
using SQLite;
using Xamarin.Forms;

namespace Source.Data.PageViewModel
{
    public class ProductListPageModel:BasePageModel
    {
        public SQLiteConnection conn;
        public ProductListPageModel()
        {
            _saveProducts = new ObservableCollection<SaveProduct>();
            conn = DependencyService.Get<Isqlite>().GetConnection();
            conn.CreateTable<SaveProduct>();
            refreshPage();
            callData();
        }

        private void refreshPage()
        {
            MessagingCenter.Subscribe<BottomTabbedPage>(this, "product", (sender) =>
            {
                callData();
            });
            MessagingCenter.Subscribe<ProductAddViewModel>(this, "SavedValue", (sender) =>
            {
                callData();
            });
            MessagingCenter.Subscribe<ProductDetailListPageModel>(this, "update", (sender) =>
            {
                callData();
            });
        }

        public Command AddCategoryCommand => new Command(async () => {
            await PopupNavigation.Instance.PushAsync(new ProductAddView());

        });

        public Command DelectSelectedItemCommand => new Command<SaveProduct>((SaveProducts) => {

            // Remove
            _saveProducts.Remove(SaveProducts);
            var selecetDelectedItem = SaveProducts;
            int xd = 0;
            try
            {
                xd = conn.Delete(selecetDelectedItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (xd == 1)
            {

                Application.Current.MainPage.DisplayAlert("Alert", "Product delected", "Ok");
                //Success
            }
            else
            {
                //Error
            }
            callData();
        });

        private void SearchCommandExecute()
        {
            if (_saveProducts != null && _saveProducts.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(SearchText))
                {
                    var tempRecords = _saveProducts.Where(x=>x.ProductName!=null).Where(x => x.ProductName.ToLower().Contains(SearchText.ToLower()));
                    ObservableCollection<SaveProduct> searchList = new ObservableCollection<SaveProduct>();
                    foreach (SaveProduct item in tempRecords)
                    {
                        searchList.Add(item);
                    }
                    SaveProducts = searchList;
                }
                else
                {

                    callData();
                }
            }
            else
            {
                callData();

            }
        }

        private void callData()
        {
            _saveProducts.Clear();
            var details = (from x in conn.Table<SaveProduct>() select x).ToList();
            if (details != null && details.Count != 0)
            {
                IsVibleCategoryStackLayout = false;
                IsVibleListviewCategoryStackLayout = true;

                foreach (var sValue in details.OrderByDescending(o => o.ID))
                {
                    _saveProducts.Add(new SaveProduct
                    {   ID = sValue.ID,
                        ProductName = sValue.ProductName,
                        Image = sValue.Image,
                        Description = sValue.Description,
                        price = "$ "+sValue.price,
                        Category = sValue.Category
                    });
                }
            }

            else
            {

                IsVibleListviewCategoryStackLayout = false;
                IsVibleCategoryStackLayout = true;
            }
        }

        private ObservableCollection<SaveProduct> _saveProducts;
        public ObservableCollection<SaveProduct> SaveProducts
        {
            get { return _saveProducts; }
            set { _saveProducts = value; OnPropertyChanged("SaveProducts"); }
        }

        private SaveProduct _selectedItem;
        public SaveProduct SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value;

                SelectableItemsDetail();
                _selectedItem = null;

                OnPropertyChanged("SelectedItem"); }
        }

        private void SelectableItemsDetail()
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new ProductDetailListPage( SelectedItem ));

        }

        private bool _IsVibleListviewCategoryStackLayout = false;
        public bool IsVibleListviewCategoryStackLayout
        {
            get { return _IsVibleListviewCategoryStackLayout; }
            set { _IsVibleListviewCategoryStackLayout = value; OnPropertyChanged("IsVibleListviewCategoryStackLayout"); }
        }

        private bool _IsVibleCategoryStackLayout = false;
        public bool IsVibleCategoryStackLayout
        {
            get { return _IsVibleCategoryStackLayout; }
            set { _IsVibleCategoryStackLayout = value; OnPropertyChanged("IsVibleCategoryStackLayout"); }
        }

        //search
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
                SearchCommandExecute();
            }
        }
    }
}
