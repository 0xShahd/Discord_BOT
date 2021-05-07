using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Commands_Library
{
    public class FunCommands : BaseCommandModule
    {
        [Command("ping")]
        [Description("ping pong")]
        public async Task Greet(CommandContext context)
        {
            await context.RespondAsync($"pong :ping_pong:");
        }
        [Command("random"), Aliases("rnd")]
        public async Task Random(CommandContext context, int min, int max)
        {
            Random random = new Random();
            await context.RespondAsync($"  {random.Next(min, max)}  :game_die:");
        }
        [Command("saysomething"), Aliases("ss")]
        public async Task SaySomthing(CommandContext context)
        {
            string[] words = ConvertText(@"D:\Discord_BOT\Discord_BOT\BOT\Text.txt");
            Random random = new Random();
            await context.RespondAsync($"{words[random.Next(0, words.Length)]}");
        }
        [Command("reaction"), Aliases("react")]
        public async Task Join(CommandContext context)
        {
            var JoinEmbed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Rose,
                Description = "Which of the following emoji represents your feeling.",
                Title = "How do you feel?"
            };
            var ReactionMessage = context.Channel.SendMessageAsync(embed: JoinEmbed);
            var result = ReactionMessage.Result;

            var heart = DiscordEmoji.FromName(context.Client, ":heart:");
            var joy = DiscordEmoji.FromName(context.Client, ":joy:");
            var cry = DiscordEmoji.FromName(context.Client, ":cry:");
            var anger = DiscordEmoji.FromName(context.Client, ":anger:");

            await result.CreateReactionAsync(heart);
            await result.CreateReactionAsync(joy);
            await result.CreateReactionAsync(anger);
            await result.CreateReactionAsync(cry);

        }
        string[] ConvertText(string path)
        {
            string str = string.Empty;
            using (var filestream = File.OpenRead(path))
            {
                using (var streamreader = new StreamReader(filestream, new UTF8Encoding(true)))
                {
                    str = streamreader.ReadToEnd();
                }
            }
            string[] sentences = str.Split('-');
            return sentences;
        }
    }
}