using CommunityToolkit.Mvvm.ComponentModel;
using InClassWorkNew.Helper;
using InClassWorkNew.Models;
using InClassWorkNew.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassWorkNew.ViewModels
{
    public partial class UsersListViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<AppUser> _allUsers;
        [ObservableProperty]
        private string _usersFilterButtonText;
        [ObservableProperty]
        private bool _isBusy;

        public Command GetUsersCommand
        {
            get
            {
                return new Command(() =>
                {
                    // This command can be used to fetch all users from the database
                    // For example, it could be bound to a button to refresh the user list
                    _allUsers = new DBMokup().GetUsers();
                });
            }
        }
        public UsersListViewModel() 
        {
            UsersFilterButtonText = FontHelper.USERS_FILTER_ON;

        }

        internal void OnAppearing()
        {
            GetUsersCommand.Execute(null);
        }
    }
}
