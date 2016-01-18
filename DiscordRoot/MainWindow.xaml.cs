using System;
using System.Collections.Generic;
using System.Windows;
using FirstFloor.ModernUI.Windows.Controls;

namespace DiscordRoot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public List<BotClient> DiscordClients { get; set; }
        public int ClientCount => DiscordClients.Count;

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

        private void MainWindow_OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown(0);
        }
    }
}
