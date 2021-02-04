using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DemoNewsApp
{
    public static class DatabaseHelper
    {
        public static async Task<ObservableCollection<User>> GetAllUsersAsync()
        {
            return new ObservableCollection<User>(await App.Database.GetUsersAsync());
        }

        public static async Task<int> SaveUserAsync(User user)
        {
            return await App.Database.SaveUserAsync(user);
        }
    }
}
