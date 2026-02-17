using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using InClassWorkNew.Models;
using InClassWorkNew.Views;

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
            var app = App.Current as App;
            if (app != null)
            {
                app.CurrentUser = new AppUser();
            }

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Application.Current!.Quit();
            });

        }
    }
}