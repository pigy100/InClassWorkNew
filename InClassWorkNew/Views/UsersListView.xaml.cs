
using InClassWorkNew.ViewModels;
namespace InClassWorkNew.Views;

public partial class UsersListView : ContentPage
{
	public UsersListView()
	{
		InitializeComponent();
		BindingContext=new InClassWorkNew.ViewModels.UsersListViewModel();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as UsersListViewModel)!.OnAppearing();
        
    }
}