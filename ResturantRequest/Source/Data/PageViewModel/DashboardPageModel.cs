using System;
using System.Collections.ObjectModel;
using Source.Data.Models;
using Source.Data.PageViewModel.Base;

namespace Source.Data.PageViewModel
{
    public class DashboardPageModel:BasePageModel
    {
        public DashboardPageModel()
        {
            _listofproducts = new ObservableCollection<ResturantModel>();

            if (_listofproducts != null && _listofproducts.Count>0)
            {

            }
            else
            {
                _listofproducts.Add(new ResturantModel { ProductName = "Hello", Type = "png" });
                _listofproducts.Add(new ResturantModel { ProductName = "Hello", Type = "png" });
                _listofproducts.Add(new ResturantModel { ProductName = "Hello", Type = "png" });
                _listofproducts.Add(new ResturantModel { ProductName = "Hello", Type = "png" });
            }
        }

        private ObservableCollection<ResturantModel> _listofproducts;
        public ObservableCollection<ResturantModel> ListofProducts
        {
            get { return _listofproducts; }
            set { _listofproducts = value; OnPropertyChanged("ListofProducts"); }
        }
    }
}
