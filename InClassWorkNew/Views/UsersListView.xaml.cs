namespace InClassWorkNew.Views;

public partial class UsersListView : ContentPage
{
	public UsersListView()
	{
		InitializeComponent();
		BindingContext=new InClassWorkNew.ViewModels.UsersListViewModel();
	}
}