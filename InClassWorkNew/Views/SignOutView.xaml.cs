using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using InClassWorkNew.Models;
using InClassWorkNew.Views;
using System.Threading.Tasks;

namespace InClassWorkNew.Views
{
    public partial class SignOutView : ContentPage
    {

        public SignOutView()
        {

            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            (App.Current as App)!.CurrentUser = null;
            Application.Current.Windows[0].Page = new NavigationPage(new SignInWorkout());
        }
    }
}