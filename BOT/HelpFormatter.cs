using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.CommandsNext.Entities;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOT
{
    class HelpFormatter : DefaultHelpFormatter
    {
        public HelpFormatter(CommandContext context) : base(context) { }

        public override CommandHelpMessage Build()
        {
            EmbedBuilder.Color = DiscordColor.HotPink;
            return base.Build();
        }
    }
}
