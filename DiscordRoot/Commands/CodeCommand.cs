using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace DiscordRoot.Commands
{
    class CodeCommand : DiscordCommand
    {
        public CodeCommand(BotClient bc) : base(bc)
        {
        }

        public override Func<CommandEventArgs, Task> DoFunc()
        {
            //return async e =>
            //{
            //    if (e.Args[0] == "")
            //    {
                    
                    
            //    }
            //}

            return null;
        }

        public override void Init(CommandGroupBuilder cgb)
        {
            cgb.CreateCommand("!code")
                .Description("Turns your code snippet into a textblock")
                .Parameter("code")
                .Do(DoFunc());
        }
    }
}
