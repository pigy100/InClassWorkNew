namespace InClassWorkNew.Views;

public partial class SignUpView : ContentPage
{
	public SignUpView()
	{
	
			InitializeComponent();
			BindingContext = new ViewModels.SignUpViewModel();
	}
}