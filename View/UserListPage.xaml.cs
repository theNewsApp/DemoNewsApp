using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoNewsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserListPage : ContentPage
    {
        private UserListPageVM _userListPageVM;
        public UserListPage()
        {
            InitializeComponent();
            _userListPageVM = new UserListPageVM(this.Navigation);
            this.BindingContext = _userListPageVM;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _userListPageVM.InitializeUserList();
        }
    }
}