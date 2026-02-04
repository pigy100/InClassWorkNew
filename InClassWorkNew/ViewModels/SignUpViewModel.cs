using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InClassWorkNew.Helper;
using InClassWorkNew.Models;
using InClassWorkNew.Service;
using InClassWorkNew.ViewModels;
using InClassWorkNew.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace InClassWorkNew.ViewModels
{
    public partial class SignUpViewModel : ObservableValidator
    {
        [ObservableProperty] AppUser _newUser;
        [ObservableProperty] DBMokup _dbmokup;

        private string? _firstName;
        private string? _lastName;
         private string? _userEmail;
        private string? _userPassword;
        private string? _userBDay;
        private string? _userMobile;
        [ObservableProperty] private bool _isPasswordNotVisible;
        [ObservableProperty] private string? _passwordIconCode = FontHelper.CLOSED_EYE_ICON;

        public string? FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command).ChangeCanExecute();
                }
            }
        }
        public string? LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command).ChangeCanExecute();
                }
            }
        }
        [EmailAddress(ErrorMessage = "Email@field.com")]
        public string? UserEmail
        {
            get => _userEmail;
            set
            {
                if (_userEmail != value)
                {
                    _userEmail = value;
                    OnPropertyChanged();
                    ValidateProperty(_userEmail, nameof(UserEmail));
                    (SignUpCommand as Command).ChangeCanExecute();
                }
            }
        }
        public string? UserPassword
        {
            get => _userPassword;
            set
            {
                if (_userPassword != value)
                {
                    _userPassword = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command).ChangeCanExecute();
                }
            }
        }
        public string? UserBDay
        {
            get => _userBDay;
            set
            {
                if (value != _userBDay)
                {
                    _userBDay = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command).ChangeCanExecute();
                }
            }
        }
        public string? UserMobile
        {
            get => _userMobile;
            set
            {
                if (value != _userMobile)
                {
                    _userMobile = value;
                    OnPropertyChanged();
                    (SignUpCommand as Command).ChangeCanExecute();
                }
            }
        }
        public ICommand SignUpCommand { get; }


        public SignUpViewModel()
        {
            _dbmokup = new DBMokup();
            IsPasswordNotVisible = true;
            PasswordIconCode = FontHelper.CLOSED_EYE_ICON;
            SignUpCommand = new Command(SignUp, ValidateData);

        }
        [RelayCommand]
        private void TogglePasswordButton()
        {
            IsPasswordNotVisible = !IsPasswordNotVisible;
            if (IsPasswordNotVisible)
                PasswordIconCode = FontHelper.CLOSED_EYE_ICON;
            else
                PasswordIconCode = FontHelper.OPEN_EYE_ICON;

        }
        private bool ValidateData()
        {
            var fnameOK = !string.IsNullOrEmpty(FirstName);
            var lnameOK = !string.IsNullOrEmpty(LastName);
            // re-validate the Email property (ensures DataAnnotation checks are applied)
            ValidateProperty(UserEmail, nameof(UserEmail));
            // check if the email property has any errors (INotifyDataErrorInfo.GetErrors)
            var emailErrors = (this as INotifyDataErrorInfo).GetErrors(nameof(UserEmail)) as IEnumerable;
            var emailOK = string.IsNullOrEmpty(UserEmail) == false && (emailErrors == null || !emailErrors.Cast<object>().Any());

            var passOK = string.IsNullOrEmpty(UserPassword) ? false :
            UserPassword.Length > 5;
            var mobileOK = string.IsNullOrEmpty(UserMobile) ? false :
            UserMobile.Length == 10;
            return fnameOK && lnameOK && emailOK && passOK && mobileOK;
        }
        
        private async void SignUp()
        {
            NewUser = new AppUser
            {
                FirstName = FirstName,
                LastName = LastName,
                UserEmail = UserEmail,
                UserPassword = UserPassword,
                UserBDay = UserBDay,
                UserMobile = UserMobile
            };
            Dbmokup.AddUser(NewUser);
            await Toast.Make($"New user Email: {NewUser.UserEmail}", ToastDuration.Short, 14).Show();

        }
    }



    
}
