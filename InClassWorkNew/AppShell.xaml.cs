
using InClassWorkNew.Views;

namespace InClassWorkNew
{
    public partial class AppShell : Shell
    {
        

        public AppShell()
        {
            InitializeComponent();
            this.BindingContext=new ViewModels.AppShellViewModel();

            Routing.RegisterRoute(nameof(MainPageView), typeof(MainPageView));
            Routing.RegisterRoute(nameof(AdminPageView), typeof(AdminPageView));
        }
    }
}
