using InClassWorkNew.Models;
using InClassWorkNew.Views;

namespace InClassWorkNew
{
    public partial class App : Application
    {
        public AppUser? CurrentUser { get; set; }
        public App()
        {
            InitializeComponent();
            CurrentUser = new AppUser();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //NavigationPage navigationPage = new NavigationPage(new SignInWorkout());
            NavigationPage navigationPage = new NavigationPage(new UsersListView());
            return new Window(navigationPage);

        }

    }
}