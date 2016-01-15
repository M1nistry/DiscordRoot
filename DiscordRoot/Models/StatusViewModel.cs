using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands.Permissions.Visibility;

namespace DiscordRoot.Models
{
    class StatusViewModel : INotifyPropertyChanged
    {
        
        private readonly DateTime _launchTime;

        public event PropertyChangedEventHandler PropertyChanged;

        public StatusViewModel()
        {
            _launchTime = DateTime.Now;
        }

        public TimeSpan Uptime => DateTime.Now - _launchTime;

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Email")
                {
                    return string.IsNullOrEmpty("") ? "Required value" : null;
                }
                return null;
            }
        }
    }
}
