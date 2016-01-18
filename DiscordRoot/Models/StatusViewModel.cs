using System;
using System.Windows.Threading;

namespace DiscordRoot.Models
{
    class StatusViewModel : BindableBase
    {
        
        private readonly DateTime _launchTime;
        private TimeSpan _uptime => DateTime.Now - _launchTime;

        private static readonly DispatcherTimer Timer;

        static StatusViewModel()
        {
            Timer = new DispatcherTimer
            {
                Interval = new TimeSpan(1000),
                IsEnabled = true
            };
        }

        public StatusViewModel()
        {
            _launchTime = DateTime.Now;
            Timer.Tick += (s, e) => OnPropertyChanged("Uptime");
        }

        public TimeSpan Uptime
        {
            get
            {
                Console.WriteLine(_uptime);
                return _uptime;
            }
            set
            {
                if ((DateTime.Now - _launchTime) == value) return;
                Uptime = DateTime.Now - _launchTime;
                OnPropertyChanged();
            }
        } 

        public string Error => null;

    }
}
