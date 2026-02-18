using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassWorkNew.ViewModels
{
    public partial class AdminPageViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task NavigateToUsersList()
        {
            await Shell.Current.GoToAsync(nameof(Views.UsersListView));
        }
    }
}
