namespace InClassWorkNew.Views;

public partial class AccountPageView : ContentPage
{
	public AccountPageView()
	{
		InitializeComponent();
		BindingContext=new ViewModels.AccountPageViewModel();
	}
}