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
    public partial class RegistrationPage : ContentPage
    {
        private RegistrationPageVM _registrationPageVM;
        public RegistrationPage()
        {
            InitializeComponent();
            _registrationPageVM = new RegistrationPageVM(this.Navigation);
            this.BindingContext = _registrationPageVM;
        }
    }
}