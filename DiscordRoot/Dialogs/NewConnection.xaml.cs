using System;
using System.Threading;
using System.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows.Controls;
using System.Windows.Input;

namespace DiscordRoot.Dialogs
{
    /// <summary>
    /// Interaction logic for NewConnection.xaml
    /// </summary>
    public partial class NewConnection : ModernDialog
    {
        public BotClient ConnectionClient
        {
            get { return _newClient; }
            set { value = _newClient; }
        }

        private BotClient _newClient;
        public NewConnection()
        {
            InitializeComponent();
            
            Buttons = new Button[] { this.ButtonLogin, this.ButtonCancel };
            Loaded += delegate
            {
                if (ComboBoxEmail.Text.Length <= 0) Keyboard.Focus(ComboBoxEmail);
                else Keyboard.Focus(TextBoxPassword);
            };
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxEmail.Text.Contains("@") && TextBoxPassword.Password.Length > 0)
            {
                PanelLoginProgress.Visibility = Visibility.Visible;
                _newClient = new BotClient();
                LabelStatus.Content = "Logging in...";

                _newClient.Client.Connected += NewClient_Connected;
                _newClient.Login(ComboBoxEmail.Text, TextBoxPassword.Password);

            }
        }

        private void NewClient_Connected(object sender, EventArgs e)
        {
            Dispatcher.Invoke((() =>
            {
                LabelStatus.Content = "Success!";
                ProgressBarConnection.IsIndeterminate = false;
                DialogResult = true;
                Close();
            }));
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
