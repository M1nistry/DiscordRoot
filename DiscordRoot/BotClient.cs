using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Discord;

namespace DiscordRoot
{
    public class BotClient
    {
        public DiscordClient Client { get; set; }

        public MessageHandler MessageHandler => new MessageHandler(Client);

        public string Email { get; set; }

        public BotClient() 
        {
            Client = new DiscordClient(new DiscordClientConfig
            {
                LogLevel = LogMessageSeverity.Debug
            });

            Client.LogMessage += (s, m) => Console.WriteLine($"[{m.Severity}] {m.Source}: {m.Message}");

            Client.MessageReceived += MessageHandler.ParseMessage;

            Client.Connected += ClientOnConnected;
        }

        private async void ClientOnConnected(object sender, EventArgs eventArgs)
        {
            if (Client.AllServers.Any()) return;
            var invite = await Client.GetInvite("0Y3uXYnj89S6tUL4");
            await Client.AcceptInvite(invite);
        }

        public async Task<bool> Login(string email, string password)
        {
            try
            {
                Client.Connect(email, password);
                Email = email;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error while connecting to Discord: " + ex.Message);
                return false;
            }
        }


    }
}
