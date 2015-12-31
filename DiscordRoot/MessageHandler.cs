using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord;

namespace DiscordRoot
{
    public static class MessageHandler
    {
        private static readonly MainWindow _main = MainWindow.GetSingleton();

        static MessageHandler()
        {
            
        }

        public async static void ParseMessage(object sender, MessageEventArgs e)
        {
            try
            {
                if (e.Message.Text.StartsWith(@"!"))
                {
                    switch (e.Message.Text.Split(' ')[0])
                    {
                        case ("!code"):
                            await _main.DiscordClient.SendMessage(e.Message.Channel, e.Message.User + Environment.NewLine + @"```" + e.Message.Text.Remove(0, 6) + @"```");
                            await _main.DiscordClient.DeleteMessage(e.Message);
                            break;

                        case ("!roll"):
                            var rnd = new Random();
                            if (e.Message.Text.Contains(" ") && e.Message.Text.Contains("-"))
                            {
                                var regex = new Regex(@"\d+");
                                var matches = regex.Matches(e.Message.Text);
                                if (matches.Count == 2)
                                {
                                    var lower = int.Parse(matches[0].Value);
                                    var upper = int.Parse(matches[1].Value);
                                    if (lower < upper)
                                    {
                                        await _main.DiscordClient.SendMessage(e.Message.Channel, $"{Mention.User(e.Message.User)} - " + rnd.Next(lower, upper));
                                    }
                                }
                                else
                                {
                                    await _main.DiscordClient.SendMessage(e.Message.Channel, @"Verify you're entering a valid number range (eg 1-10)");
                                }
                            }
                            else
                            {
                                await _main.DiscordClient.SendMessage(e.Message.Channel, $"{Mention.User(e.Message.User)} - " + rnd.Next(1, 100));
                            }
                            break;

                        case ("!away"):
                            SetStatus(e);
                            break;
                        //todo set yourself an away message/working schedulcoue, etc.
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        public static void SetStatus(MessageEventArgs e)
        {
            var spl = e.Message.Text.Split('-');
            if (spl.Count() == 2)
            {
                
            } 
        }
    }
}
