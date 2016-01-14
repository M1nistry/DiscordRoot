using System.ComponentModel;
using FirstFloor.ModernUI.Presentation;

namespace DiscordRoot.Views
{
    class LoginViewModel : NotifyPropertyChanged, IDataErrorInfo
    {
        private string _email = Properties.Settings.Default.AccountEmail;
        private string _password;

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email == value) return;
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password == value) return;
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Email")
                {
                    return string.IsNullOrEmpty(_email) ? "Required value" : null;
                }
                if (columnName == "Password")
                {
                    return string.IsNullOrEmpty(_password) ? "Required value" : null;
                }
                return null;
            }
        }
    }
}
