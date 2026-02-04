using InClassWorkNew.Helper;
using InClassWorkNew.Service;

using InClassWorkNew.ViewModels;
using System.Windows.Input;


namespace InClassWorkNew.ViewModels
{
    public partial class SignInWorkoutViewModel : ViewModelBase
    {
        #region DataMembers
        DBMokup _db;
        private string _userName;
        private string _password;
        private string _loginMessage;
        private bool _signInMessageVisible;
        private Color _signInMessageColor;
        private bool _isPassword = true;
        private string _passwordText = FontHelper.OPEN_EYE_ICON;
        private readonly INavigation? _navigationPage;
        #endregion
        #region SetGet
        public string LoginMessage
        {
            get => _loginMessage;
            set
            {
                if (_loginMessage != value)
                {
                    _loginMessage = value;
                    OnPropertyChanged();
                }
            }
        }
        public string PasswordText
        {
            get => _passwordText;
            set
            {
                if (_passwordText != value)
                {
                    _passwordText = value;
                    OnPropertyChanged();
                }
            }
        }
        public Color SignInMessageColor
        {
            get => _signInMessageColor;
            set
            {
                if (value != _signInMessageColor)
                {
                    _signInMessageColor = value;
                    OnPropertyChanged();
                }

            }
        }

        public bool SignInMessageVisible
        {
            get => _signInMessageVisible;
            set
            {

                if (_signInMessageVisible != value)
                {
                    _signInMessageVisible = value;
                    OnPropertyChanged();
                }

            }
        }
        public bool IsPassword
        {
            get => _isPassword;
            set
            {

                if (_isPassword != value)
                {
                    _isPassword = value;
                    OnPropertyChanged();
                }

            }
        }
        public string UserName
        {
            get { return _userName; }
            set
            {

                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged();
                    (SignInCommand as Command).ChangeCanExecute();
                }
            }

        }
        public string UserPassword
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                    (SignInCommand as Command).ChangeCanExecute();
                }
            }

        }
        #endregion
        #region Commands
        public ICommand ShowPasswordCommand { get; }
        public ICommand SignInCommand { get; }
        public ICommand NavigateToSignUpCommand { get; }
        #endregion
        public SignInWorkoutViewModel(INavigation? navigationPage)
        {
            _db = new DBMokup();
            ShowPasswordCommand = new Command(TogglePassordButton);
            SignInCommand = new Command(SignIn, CanSignIn);
            
            NavigateToSignUpCommand = new Command(async () =>
            {
                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(new Views.SignUpView());
                }
            });
            _navigationPage = navigationPage;
        }
        private bool CanSignIn()
        {
            return !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword));
        }
        private void SignIn()
        {
            SignInMessageVisible = true;
            if (_db.isExist(UserName, UserPassword))
            {
                Application.Current!.Windows[0].Page = new AppShell();
                //Navigate to MainPage
            }
            else
            {
                LoginMessage = AppMessages.loginErrorMessage;
                SignInMessageColor = Colors.Red;
            }
           
        }

        private void TogglePassordButton()
        {
            IsPassword = !IsPassword;
            if (IsPassword)
                PasswordText = FontHelper.OPEN_EYE_ICON;
            else
                PasswordText = FontHelper.CLOSED_EYE_ICON;
        }
    }
}
