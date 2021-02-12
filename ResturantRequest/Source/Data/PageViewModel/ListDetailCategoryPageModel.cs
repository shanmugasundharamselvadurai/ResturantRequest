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
    public class ListDetailCategoryPageModel:BasePageModel
    {
        public SQLiteConnection conn;
        string selectedItem;
        public ListDetailCategoryPageModel(ResturantCategory resturant)
        {
            selectedItem = resturant.Category;
            _saveProducts = new ObservableCollection<SaveProduct>();
            _selectedCategory= new ObservableCollection<SelectedCategoryProducted>();

            conn = DependencyService.Get<Isqlite>().GetConnection();
            listOfProductCall();
          }

        private void listOfProductCall()
        {
            var details = (from x in conn.Table<SaveProduct>() select x) . ToList();

            var getData = details
               .Where(x => x.Category != null)
               .Where(x => x.Category.Equals(selectedItem))
               .Select(x => x.ProductName).ToList();
     
            foreach (var listofProduct in getData)
            {
                _selectedCategory.Add(new SelectedCategoryProducted
                {
                    ProductName = listofProduct
                });
            }
        }

        public Command backbuttonAction => new Command(async () => {

            await Application.Current.MainPage.Navigation.PopModalAsync();
        });


        private ObservableCollection<SaveProduct> _saveProducts;
        public ObservableCollection<SaveProduct> SaveProducts
        {
            get { return _saveProducts; }
            set { _saveProducts = value; OnPropertyChanged("SaveProducts"); }
        }


        private ObservableCollection<SelectedCategoryProducted> _selectedCategory;
        public ObservableCollection<SelectedCategoryProducted> SelectedCategory
        {
            get { return _selectedCategory; }
            set { _selectedCategory = value; OnPropertyChanged("SelectedCategory"); }
        }

    }
}
