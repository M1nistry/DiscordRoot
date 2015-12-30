using System.Linq;
using System.Threading.Tasks;
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows;

namespace DiscordRoot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public Discord.DiscordClient DiscordClient { get; set; }
        public Task ClientThread { get; set; }

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
