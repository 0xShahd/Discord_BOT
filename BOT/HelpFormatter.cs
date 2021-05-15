using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.CommandsNext.Entities;
using DSharpPlus.Entities;
using System.Collections.Generic;
using System.Text;

namespace BOT
{
    class HelpFormatter : DefaultHelpFormatter
    {
        protected DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
        protected StringBuilder strb = new StringBuilder();
        public HelpFormatter(CommandContext context) : base(context) { }
        public override CommandHelpMessage Build()
        {        
            EmbedBuilder.Color = DiscordColor.HotPink;
            EmbedBuilder.Url = "";
            EmbedBuilder.Title = "Help مساعدة";        
            return base.Build();
        }
        public override BaseHelpFormatter WithCommand(Command command)
        {
            embed.AddField(command.Name, command.Description);            
            strb.AppendLine($"{command.Name} - {command.Description}");

            return this;
        }

        public override BaseHelpFormatter WithSubcommands(IEnumerable<Command> commands)
        {
            foreach (var commad in commands)
            {
                embed.AddField(commad.Name, commad.Description);            
                strb.AppendLine($"{commad.Name} - {commad.Description}");
            }

            return this;
        }
    }
}
