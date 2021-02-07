using Source.Data.PageViewModel;
using Xamarin.Forms;

namespace Source.Presentation.Pages
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();

            DashboardPageModel Dash = new DashboardPageModel();
            BindingContext = Dash;
            //await App.Database.GetPeopleAsync();
            // 
        }
    }
}
