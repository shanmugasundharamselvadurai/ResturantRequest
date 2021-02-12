using System;
using System.Collections.ObjectModel;
using Rg.Plugins.Popup.Services;
using Source.Data.Models;
using Source.Data.PageViewModel.Base;
using Xamarin.Forms;

namespace Source.Data.PageViewModel
{
    public class CategoryAddViewModel : BasePageModel
    {
        public CategoryAddViewModel()
        {
        }

        public Command AddCommand => new Command(async () => {

            MessagingCenter.Send<CategoryAddViewModel,string>(this, "selectedValue" , categoryText);
            await PopupNavigation.Instance.PopAsync();
        });

        private string _categoryText;
        public string categoryText
        {
            get { return _categoryText; }
            set
            {
                _categoryText = value;
                OnPropertyChanged("categoryText");
            }
        }
    }
}

