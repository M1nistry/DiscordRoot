using System.Linq;
using System.Threading.Tasks;
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows;
using Discord;

namespace DiscordRoot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public DiscordClient DiscordClient { get; set; }

        private static MainWindow _main;
        public MainWindow()
        {
            InitializeComponent();
            _main = this;
        }

        public static MainWindow GetSingleton()
        {
            return _main;
        }
    }
}
