
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
        // Optionally, you can call a method to load data when the page appears
        if (BindingContext is UsersListViewModel viewModel)
        {

            viewModel.GetUsersCommand?.Execute(null);

        
        }

    }
}