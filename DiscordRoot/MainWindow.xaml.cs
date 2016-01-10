using System.Collections.Generic;
using FirstFloor.ModernUI.Windows.Controls;
using Discord;

namespace DiscordRoot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public List<BotClient> DiscordClients { get; set; } 

        private static MainWindow _main;
        public MainWindow()
        {
            InitializeComponent();
            _main = this;
            DiscordClients = new List<BotClient>();
        }

        public static MainWindow GetSingleton()
        {
            return _main;
        }
    }
}
