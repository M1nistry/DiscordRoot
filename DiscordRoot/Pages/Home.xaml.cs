using System;
using System.Windows;
using System.Windows.Controls;
using FirstFloor.ModernUI.Presentation;

namespace DiscordRoot.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        private static MainWindow _main;
        public Home()
        {
            InitializeComponent();
            _main = MainWindow.GetSingleton();
        }
    }
}
