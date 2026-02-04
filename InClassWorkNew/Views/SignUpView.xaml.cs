namespace InClassWorkNew.Views;

public partial class SignUpView : ContentPage
{
	public SignUpView()
	{
		try
		{
			InitializeComponent();
			BindingContext = new ViewModels.SignUpViewModel();
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine($"SignUpView init error: {ex}");
			Content = new Label
			{
				Text = $"Startup error: {ex.GetType().Name}: {ex.Message}",
				TextColor = Colors.Red,
				Margin = new Thickness(20)
			};
		}
	}
}