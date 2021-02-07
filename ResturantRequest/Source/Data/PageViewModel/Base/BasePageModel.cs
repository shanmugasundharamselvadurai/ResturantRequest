using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Source.Data.PageViewModel.Base
{
    public abstract class BasePageModel : INotifyPropertyChanged
    {
        public BasePageModel()
        {

        }

        bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// This OnPropertyChanged method will be raised whenever a property from the View will be changed.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task OnAppearing()
        {
            return Task.FromResult<object>(null);
        }

        public virtual Task OnDisappearing()
        {
            return Task.FromResult<object>(null);
        }

        public virtual Task OnResume()
        {
            return Task.FromResult<object>(null);
        }
    }
}