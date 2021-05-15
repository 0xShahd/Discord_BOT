using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;

namespace Commands_Library
{
    public class FunCommands : BaseCommandModule
    {
        public InteractivityExtension interactivity { get; private set; }

        [Command("ping")]
        [Description("ping pong")]
        public async Task Greet(CommandContext context)
        {
            await context.RespondAsync($"pong :ping_pong:");
        }
        [Command("random"), Aliases("rnd")]
        [Description("maybe later")]
        public async Task Random(CommandContext context, int min, int max)
        {
            Random random = new Random();
            await context.RespondAsync($"  {random.Next(min, max)}  :game_die:");
        }
        [Command("saysomething"), Aliases("ss")]
        [Description("maybe later")]
        public async Task SaySomthing(CommandContext context)
        {
            string[] words = ConvertText(@"D:\Discord_BOT\Discord_BOT\BOT\Text.txt");
            Random random = new Random();
            await context.RespondAsync($"{words[random.Next(0, words.Length)]}");
        }
        [Command("BMI")]
        [Description("maybe later")]
        public async Task BMI(CommandContext context, float height, float weight)
        {
            var BMI = weight / (height * height);
            if (BMI >= 25f)
            {
                await context.RespondAsync($"{BMI:F2} is **overwight**.");
            }
            else if (BMI < 25 && BMI > 18.5f)
            {
                await context.RespondAsync($"{BMI:F2} is **normal**.");
            }
            else if (BMI <= 18.5f)
            {
                await context.RespondAsync($"{BMI:F2} is **underweight**.");
            }
            else
            {
                await context.RespondAsync("Wrong values.");
            }
        }

        [Command("role")]
        [Description("maybe later")]
        public async Task GiveRole(CommandContext context)
        {
            var JoinEmbed = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Rose,
                Description = "",
                Title = ""
            };
            var message = context.Channel.SendMessageAsync(embed: JoinEmbed);
            var result = message.Result;

            var heart = DiscordEmoji.FromName(context.Client, ":heart:");

            await result.CreateReactionAsync(heart);
            var interactivity = context.Client.GetInteractivity();

            var RoleResult = await interactivity.WaitForReactionAsync(x => x.Message.Author.Id == context.Member.Id && x.User == context.User);
            if(RoleResult.Result.Emoji == heart)
            {
                await context.Member.GrantRoleAsync(context.Guild.GetRole(840608029703012392));
            }
            await result.DeleteAsync();
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