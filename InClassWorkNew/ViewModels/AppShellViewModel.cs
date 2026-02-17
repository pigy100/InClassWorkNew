using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using InClassWorkNew.Models;
using InClassWorkNew.Views;

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
    }
}
