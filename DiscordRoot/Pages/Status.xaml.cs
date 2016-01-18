using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using FirstFloor.ModernUI.Presentation;

namespace DiscordRoot.Pages
{
    /// <summary>
    /// Interaction logic for Status.xaml
    /// </summary>
    public partial class Status : UserControl
    {
        private static Status _status;
        private readonly MainWindow _main;

        public Status()
        {
            InitializeComponent();
            _status = this;
            _main = MainWindow.GetSingleton();
            Loaded += OnLoaded;

            // add group command
            //ButtonAdd.Command = new RelayCommand(AddConnection);

            // add link to selected group command
            this.ButtonAdd.Command = new RelayCommand(AddConnection, o => this.MenuConnections != null);

            //// remove selected group command
            //this.RemoveGroup.Command = new RelayCommand(o => {
            //    this.Menu.LinkGroups.Remove(this.Menu.SelectedLinkGroup);
            //}, o => this.Menu.SelectedLinkGroup != null);

            //// remove selected linkcommand
            //this.RemoveLink.Command = new RelayCommand(o => {
            //    this.Menu.SelectedLinkGroup.Links.Remove(this.Menu.SelectedLink);
            //}, o => this.Menu.SelectedLinkGroup != null && this.Menu.SelectedLink != null);

            // log SourceChanged events
            MenuConnections.SelectedSourceChanged += (o, e) => {
                Debug.WriteLine("SelectedSourceChanged: {0}", e.Source);
            };
        }

        public static Status StatusInstance()
        {
            return _status;
        }

        void AddConnection(object o)
        {
            var newConnection = new Dialogs.NewConnection();
            newConnection.ShowDialog();

            if (newConnection.DialogResult == false) return;
            var newPage = new LinkGroup
            {
                DisplayName = newConnection.ConnectionClient.Email,
                GroupKey = "serverEmail"
            };
            MenuConnections.LinkGroups.Add(newPage);
            newPage.Links.Add(new Link
            {
                DisplayName = "Status",
                Source = new Uri(@"/Pages/Home.xaml", UriKind.Relative)
            });
            foreach (var server in newConnection.ConnectionClient.Client.AllServers)
            {
                newPage.Links.Add(new Link
                {
                    DisplayName = server.Name,
                    //Source = new Uri(@"/Pages/ServerStatus.xaml", UriKind.Relative)
                });
            }
            MenuConnections.SelectedLink = newPage.Links[0];
            _main.DiscordClients.Add(newConnection.ConnectionClient);
        }

        void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (_main.DiscordClients.Count == 0)
            {
                //var newConnection = new Dialogs.NewConnection();
                //newConnection.ShowDialog();
            }
        }
    }
}
