using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoNewsApp
{
    public class UserListPageVM:BaseVM
    {
        public UserListPageVM(INavigation navigation)
        {
            this._navigation = navigation;
            InitializeUserList();
        }

        private INavigation _navigation;
        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set 
            { 
                _users = value;
                OnPropertyChange("Users");
            }
        }

        public ICommand AddUserCommand => new Command(AddUserCommandImpl);

        private async void AddUserCommandImpl(object obj)
        {
            await _navigation.PushAsync(new RegistrationPage());
        }

        public async void InitializeUserList()
        {
            this.Users = await DatabaseHelper.GetAllUsersAsync();
        }


    }
}
