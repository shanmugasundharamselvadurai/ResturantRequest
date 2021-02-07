using System;
using System.IO;
using Source.Data.Helper;
using Source.Presentation.CommonView;
using Source.Presentation.Pages.BottomTab;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResturantRequest
{
    public partial class App : Application
    {
        // sql
        static ResturantDatabase database;
        public static ResturantDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ResturantDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Resturant.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            var page = new BottomTabbedPage();
            CustomNavigationPage.SetHasBackButton(page, false);
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
