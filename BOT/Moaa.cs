using DSharpPlus;
using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using Commands_Library;
using Moaa;

namespace BOT
{
    class Moaa
    {
        public static async Task RunMainAsync()
        {
            var json_config = JSON.Config();

            var Client = new DiscordClient(new DiscordConfiguration
            {
                Token = json_config.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true
            });
            var Commands = Client.UseCommandsNext(new CommandsNextConfiguration
            {
                CaseSensitive = false,
                DmHelp = true,
                EnableMentionPrefix = true,
                StringPrefixes = new string[] { json_config.Prefix },
            });

            Commands.RegisterCommands<ConvertCommands>();
            Commands.RegisterCommands<FunCommands>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

    }
}