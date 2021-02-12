using System;
using System.IO;
using Source.Presentation.CommonView;
using Source.Presentation.Pages.BottomTab;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResturantRequest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var page = new BottomTabbedPage();
            MainPage = new CustomNavigationPage(page)
            {
                BarTextColor = Color.FromHex("FFFFFF")
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
