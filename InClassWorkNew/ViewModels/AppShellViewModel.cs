using CommunityToolkit.Mvvm.ComponentModel;
using System;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InClassWorkNew.Views;

namespace InClassWorkNew.ViewModels
{
    public partial class AppShellViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isAdminVisible;
        public AppShellViewModel()
        {
            if ((App.Current as App)!.CurrentUser.IsAdmin)
            {
                IsAdminVisible = true;
            }
        }

        [RelayCommand]
        public async void SignOut()
        {
            (App.Current as App)!.CurrentUser = null;
            Application.Current.Windows[0].Page = new SignInWorkout();

        }
    }
}
