using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InClassWorkNew.Helper;
using InClassWorkNew.Models;
using InClassWorkNew.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassWorkNew.ViewModels
{
    public partial class UsersListViewModel : ObservableObject
    {
        private List<AppUser> _allUsers;

        public ObservableCollection<AppUser> AllUsers { get; set; }

        [ObservableProperty]
        private string _usersFilterButtonText;
        [ObservableProperty]
        private bool _isBusy;

        public Command? GetUsersCommand
        {
            get
            {
                return new Command(() =>
                {
                    // This command can be used to fetch all users from the database
                    // For example, it could be bound to a button to refresh the user list
                    _allUsers = new DBMokup().GetUsers();
                    AllUsers.Clear(); // Clear the existing collection
                    foreach (var user in _allUsers)
                    {
                        AllUsers.Add(user); // Add each user to the ObservableCollection
                    }
                });
            }
        }
        public Command? DeleteUserCommand { get;}

        [RelayCommand]
        private void NavigateToAccountPage()
        {
            Shell.Current.GoToAsync("AccountPageView");
        }

public UsersListViewModel() 
        {
            UsersFilterButtonText = FontHelper.USERS_FILTER_ON;
            AllUsers = new();
            DeleteUserCommand = new Command<AppUser>(DeleteUser);
        }
        private void DeleteUser(AppUser user) 
{
if (user != null)
{
// Remove the user from the ObservableCollection
AllUsers.Remove(user);
}
}
internal void OnAppearing()
        {
            GetUsersCommand.Execute(null);
        }
    }
}
