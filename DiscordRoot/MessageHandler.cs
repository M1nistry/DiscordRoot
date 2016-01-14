using System;
using System.Linq;
using System.Text.RegularExpressions;
using Discord;
using Discord.Commands;

namespace DiscordRoot
{
    public class MessageHandler
    {
        private static readonly MainWindow _main = MainWindow.GetSingleton();
        private DiscordClient _client;

        public MessageHandler(DiscordClient client)
        {
            _client = client;
        }

        public async void ParseMessage(object sender, MessageEventArgs e)
        {
            try
            {
                if (e.Message.Text.StartsWith(@"!"))
                {
                    switch (e.Message.Text.Split(' ')[0])
                    {
                        case ("!code"):
                            await _client.SendMessage(e.Message.Channel, e.Message.User + Environment.NewLine + @"```" + e.Message.Text.Remove(0, 6) + @"```");
                            await _client.DeleteMessage(e.Message);
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
                                        await _client.SendMessage(e.Message.Channel, $"{Mention.User(e.Message.User)} " + rnd.Next(lower, upper));
                                    }
                                }
                                else
                                {
                                    await _client.SendMessage(e.Message.Channel, @"Verify you're entering a valid number range (eg 1-10)");
                                }
                            }
                            else
                            {
                                await _client.SendMessage(e.Message.Channel, $"{Mention.User(e.Message.User)} " + rnd.Next(1, 100));
                            }
                            break;

                        case ("!away"):
                            SetStatus(e);
                            break;
                        //todo set yourself an away message/working schedulcoue, etc.

                        case ("!flip"):
                            await _client.SendMessage(e.Message.Channel, new Random().Next(100) < 50 ? $"{Mention.User(e.Message.User)} Heads" : $"{Mention.User(e.Message.User)} Tails");
                            break;

                        case ("!choose"):
                            if (e.Message.Text.Contains(" "))
                            {
                                var choices = e.Message.Text.Split(' ');
                                await _client.SendMessage(e.Message.Channel, $"{Mention.User(e.Message.User)} " + choices[new Random().Next(1, choices.Length - 1)]);
                            }
                            else
                            {
                                await _client.SendMessage(e.Message.Channel, @"Invalid Syntax (eg. !choose one two three)");
                            }
                            break;
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        public void SetStatus(MessageEventArgs e)
        {
            var spl = e.Message.Text.Split('-');
            if (spl.Count() == 2)
            {
                
            } 
        }
    }
}
