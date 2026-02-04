namespace InClassWorkNew.Views;

public partial class AdminPageView : ContentPage
{
	public AdminPageView()
	{
		InitializeComponent();
		BindingContext=new ViewModels.AdminPageViewModel();

	}
}