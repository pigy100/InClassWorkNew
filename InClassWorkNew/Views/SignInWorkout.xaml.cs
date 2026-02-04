using InClassWorkNew.Helper;
using InClassWorkNew.Service;
using Microsoft.Maui.Graphics;
using InClassWorkNew.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace InClassWorkNew.Views;

public partial class SignInWorkout : ContentPage
{
    public SignInWorkout()
    {
        InitializeComponent();
        BindingContext = new SignInWorkoutViewModel(this.Navigation);
    }
}
