using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiscordRoot.Pages
{
    /// <summary>
    /// Interaction logic for Status.xaml
    /// </summary>
    public partial class Status : UserControl
    {
        private static Status _status;

        public bool Connected
        {
            get { return TextBlockStatus.Text.Replace("Status: ", "") == "Connected"; }
            set { TextBlockStatus.Text = value ? "Status: Connected" : "Status: Disconnected"; }
        }

        public Status()
        {
            InitializeComponent();
            _status = this;
        }

        public static Status StatusInstance()
        {
            return _status;
        }
    }
}
