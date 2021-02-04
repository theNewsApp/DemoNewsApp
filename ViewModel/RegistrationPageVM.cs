using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoNewsApp
{
    public class RegistrationPageVM:BaseVM
    {
        private INavigation _navigation;
        public RegistrationPageVM(INavigation _navigation)
        {
            this._navigation = _navigation;
        }

      

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChange("Name");
                OnPropertyChange("CanSave");
            }
        }

        private string _designation;

        public string Designation
        {
            get { return _designation; }
            set { _designation = value; OnPropertyChange("Designation"); OnPropertyChange("CanSave"); }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChange("Email"); OnPropertyChange("CanSave"); }
        }

        private string _mobile;

        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; OnPropertyChange("Mobile"); OnPropertyChange("CanSave"); }
        }


        public ICommand CancelCommand => new Command(CancelCommandImpl);

        private void CancelCommandImpl(object obj)
        {
            _navigation.PopAsync();
        }

        public ICommand SaveCommand => new Command(SaveCommandImpl, CanSaveExecute);

        public bool CanSave
        {
            get
            {
                return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Designation) && 
                    !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Mobile);
            }
        }
        private bool CanSaveExecute(object arg)
        {
            return CanSave;
        }

        private async void SaveCommandImpl(object obj)
        {
            User user = new User { Name = this.Name, Designation = this.Designation, Email = this.Email, Mobile = this.Mobile };
            int count=await DatabaseHelper.SaveUserAsync(user);
            if (count > 0)
                await _navigation.PopAsync();
            
        }
    }
}
