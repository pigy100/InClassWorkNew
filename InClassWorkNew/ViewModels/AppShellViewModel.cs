using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using InClassWorkNew.Models;
using InClassWorkNew.Views;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;

namespace InClassWorkNew.ViewModels
{
    public partial class AppShellViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isAdminVisible;
       

        public AppShellViewModel()
        {
            var app = App.Current as App;
            if (app?.CurrentUser?.IsAdmin == true)
            {
                IsAdminVisible = true;
            }
        }
        [RelayCommand]
        private void SignOut()
        {
            (App.Current as App)!.CurrentUser = null;
            Application.Current.Windows[0].Page = new NavigationPage(new SignInWorkout());
        }
        [RelayCommand]
        private void NavigateToAdminPage()
        {
            Shell.Current.GoToAsync(nameof(AdminPageView));
        }
    }
}
