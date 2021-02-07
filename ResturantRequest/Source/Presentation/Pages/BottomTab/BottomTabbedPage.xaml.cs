using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source.Presentation.CommonView;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Source.Presentation.Pages.BottomTab
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomTabbedPage : Xamarin.Forms.TabbedPage
    {
        public BottomTabbedPage()
        {
            InitializeComponent();

            CustomNavigationPage.SetHasBackButton(this, false);
            CustomNavigationPage.SetHasNavigationBar(this, true);
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Android>().SetIsSwipePagingEnabled(false);
        }
    }
}
