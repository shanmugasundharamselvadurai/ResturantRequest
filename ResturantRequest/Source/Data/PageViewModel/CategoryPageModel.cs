using System;
using System.Collections.ObjectModel;
using System.Linq;
using Rg.Plugins.Popup.Services;
using Source.Data.Interface;
using Source.Data.Models;
using Source.Data.PageViewModel.Base;
using Source.Presentation.CommonView;
using Source.Presentation.Pages.BottomTab;
using Source.Presentation.Pages.Category;
using SQLite;
using Xamarin.Forms;

namespace Source.Data.PageViewModel
{
    public class CategoryPageModel:BasePageModel
    {
        public SQLiteConnection conn;
        ResturantCategory resturant;
        public string selectedDropDownValue;
        string totalCountValue;
        public CategoryPageModel()
        {
            _listofCategory = new ObservableCollection<ResturantCategory>();
            conn = DependencyService.Get<Isqlite>().GetConnection();
            conn.CreateTable<ResturantCategory>();


            MessagingCenter.Subscribe<BottomTabbedPage>(this, "category", (sender) =>
            {
                Callrefresh();
            });

            //selectedofProduct
            _saveProducts = new ObservableCollection<SaveProduct>();
            callCategory();
            Callrefresh();
        }

        private void callCategory()
        {
            MessagingCenter.Subscribe<CategoryAddViewModel,string>(this, "selectedValue", (sender,arg) =>
            {
                selectedDropDownValue = arg;
                if (!string.IsNullOrEmpty(selectedDropDownValue))
                {
                    resturant = new ResturantCategory();
                    resturant.Category = selectedDropDownValue;
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
                        // success message
      
                    }
                    else
                    {
                        //Error message
                    }
         
                }
                else
                {

                }
                Callrefresh();
            });
        }

        private void Callrefresh()
        {
            _listofCategory.Clear();

            var categoryDetails = (from x in conn.Table<ResturantCategory>() select x).Distinct().ToList();

            if (categoryDetails != null && categoryDetails.Count != 0)
            {
                IsVibleCategoryStackLayout = false;
                IsVibleListviewCategoryStackLayout = true;
                var details = (from x in conn.Table<SaveProduct>() select x).Distinct().ToList();
                foreach (var value in categoryDetails.OrderByDescending(o => o.ID).Distinct())
                {
                 var getData = details
                .Where(x => x.Category != null)
                .Where(x => x.Category.Equals(value.Category))
                .Select(x => x.ProductName).ToList();

                 if(getData.Count != 0)
                 {
                     totalCountValue = "Product " + getData.Count.ToString();
                 }
                 else
                 {
                        totalCountValue = "";
                 }

                _listofCategory.Add(new ResturantCategory
                 {
                   Category = value.Category,
                   ID = value.ID,
                   TotalCount =  totalCountValue.ToString(),
                });
               }
              }
            else
            {
                IsVibleListviewCategoryStackLayout = false;
                IsVibleCategoryStackLayout = true;
            }
      }

        private void SearchCommandExecute()
        {
            if (_listofCategory != null && _listofCategory.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(SearchText))
                {
                    var tempRecords = _listofCategory.Where(x => x.Category.ToLower().Contains(SearchText.ToLower()));
                    ObservableCollection<ResturantCategory> searchList = new ObservableCollection<ResturantCategory>();
                    foreach (ResturantCategory item in tempRecords)
                    {
                        searchList.Add(item);
                    }
                    ListofCategory = searchList;
                }
                else
                {

                    Callrefresh();
                }
            }
            else
            {
                Callrefresh();
            }
        }

        public Command AddCategoryCommand => new Command(async () => {
             await PopupNavigation.Instance.PushAsync(new CategoryAddView());
        });

        public Command DelectCategorySelectedItemCommand => new Command<ResturantCategory>((ListofCategory) =>
        {
            var selecetDelectedItem = ListofCategory;
            if (string.IsNullOrEmpty(selecetDelectedItem.TotalCount))
            {
                // Remove
                _listofCategory.Remove(ListofCategory);
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
                    Application.Current.MainPage.DisplayAlert("Alert", "Category delected", "Ok");
                    //Success
                    Callrefresh();
                }
                else
                {
                   
                }
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Warning", "Please assign this product to another category before deleting.", "Ok");
                return;
            }
           });

        private ObservableCollection<ResturantCategory> _listofCategory;
        public ObservableCollection<ResturantCategory> ListofCategory
        {
            get { return _listofCategory; }
            set { _listofCategory = value; OnPropertyChanged("ListofCategory"); }
        }

        private ResturantCategory _selectedItem;
        public ResturantCategory selectedItem
        {
            get { return _selectedItem; }

            set {
                _selectedItem = value;
                if (!string.IsNullOrEmpty(_selectedItem.TotalCount))
                {
                    selectedItemValue();
                }
                else
                {
                    return;
                }
                _selectedItem = null;
                
                OnPropertyChanged("selectedItem");
            }
        }

        private void selectedItemValue()
        {
            var sel = selectedItem;
            Application.Current.MainPage.Navigation.PushModalAsync(new ListDetailCategoryPage(selectedItem));
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


        private ObservableCollection<SaveProduct> _saveProducts;
        public ObservableCollection<SaveProduct> SaveProducts
        {
            get { return _saveProducts; }
            set { _saveProducts = value; OnPropertyChanged("SaveProducts"); }
        }

        //search
        private string _searchText;
        public string SearchText {
            get { return _searchText; }
            set { _searchText = value; OnPropertyChanged("SearchText");
                SearchCommandExecute();
            } }
       
    }
}
