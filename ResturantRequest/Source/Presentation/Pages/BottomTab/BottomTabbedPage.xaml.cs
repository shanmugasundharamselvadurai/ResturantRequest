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

            this.CurrentPageChanged += PageChanged;

            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Android>().SetIsSwipePagingEnabled(false);
        }

        void PageChanged(object sender, EventArgs args)
        {
            var tabbedPage = (BottomTabbedPage)sender;
            Title = tabbedPage.CurrentPage.Title;

            if (Title.ToLower().Equals("product"))
            {
                MessagingCenter.Send<BottomTabbedPage>(this, "product");

            
            }
            else if (Title.ToLower().Equals("category"))
            {
                MessagingCenter.Send<BottomTabbedPage>(this, "category");
            }
  
        }

    }
}
