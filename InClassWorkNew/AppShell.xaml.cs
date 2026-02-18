
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
            Routing.RegisterRoute(nameof(SignOutView), typeof(SignOutView));
            Routing.RegisterRoute(nameof(UsersListView), typeof(UsersListView));
        }
    }
}
