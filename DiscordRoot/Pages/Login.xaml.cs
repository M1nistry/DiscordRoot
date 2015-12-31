using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Schema;
using Discord;
using DiscordRoot.Pages;
using FirstFloor.ModernUI.Windows.Controls;

namespace DiscordRoot.Dialogs
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        MainWindow _main = MainWindow.GetSingleton();


        public Login()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            ButtonLogin.IsEnabled = false;
            try
            {
                _main.DiscordClient = new DiscordClient(new DiscordClientConfig
                {
                    LogLevel = LogMessageSeverity.Info
                });
                
                _main.DiscordClient.LogMessage += (s, m) => Console.WriteLine($"[{m.Severity}] {m.Source}: {m.Message}");
               
                _main.DiscordClient.MessageReceived += MessageHandler.ParseMessage;

                _main.DiscordClient.UserJoined += (s, u) =>
                {
                    Console.WriteLine($"[{u.Server.Name}] - {u.User.Name}");
                };

                _main.DiscordClient.Connected += (s, obj) =>
                {
                    if (!_main.DiscordClient.AllServers.Any())
                        JoinServers();

                };

                _main.DiscordClient.Connect(TextBoxEmail.Text, TextBoxPassword.Password);
            }
            catch (Exception ex)
            {
                ButtonLogin.IsEnabled = true;
                MessageBox.Show(ex.Message);
            }
        }

        private async void JoinServers()
        {
            var invite = await _main.DiscordClient.GetInvite("0Y3uXYnj89S6tUL4");
            await _main.DiscordClient.AcceptInvite(invite);
        }
    }
}
