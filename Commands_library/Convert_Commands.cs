using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Commands_Library
{
    public class ConvertCommands : BaseCommandModule
    {
        [Command("binary")]
        [Description("Convert the txet to binary.")]
        public async Task ToBinary(CommandContext context, [RemainingText] string value)
        {
            StringBuilder strb = new StringBuilder();
            if (value != null)
            {              
                foreach (char letter in value)
                {
                    int Counter = 0;
                    if (Counter % 2 == 0) strb.Append(" ");
                    int i = Convert.ToInt32(letter);
                    strb = strb.Append(Convert.ToString(i, 2));
                    Counter++;
                }
                await context.RespondAsync($"`{ strb }`");
            }
            else
            {
                await context.RespondAsync("You forgot to enter the value");
            }
        }

        [Command("hex")]
        [Description("Convert the txet to hexadicimal.")]
        public async Task Hex(CommandContext context, [RemainingText] string value)
        {
            StringBuilder strb = new StringBuilder();
            if (value != null)
            {
                foreach (char letter in value)
                {
                    int Counter = 0;
                    if (Counter % 2 == 0) strb.Append(" ");
                    int i = Convert.ToInt32(letter);
                    strb = strb.Append($"{i:X}");
                    Counter++;
                }
                await context.RespondAsync($"`{ strb }`");
            }
            else
            {
                await context.RespondAsync("You forgot to enter the value");
            }    
        }

        [Command("octal")]
        [Description("Convert the txet to Octal.")]
        public async Task Octal(CommandContext context, [RemainingText] string value)
        {
            StringBuilder strb = new StringBuilder();
            if (value != null)
            {
                foreach (char letter in value)
                {
                    int i = Convert.ToInt32(letter);
                    strb = strb.Append(Convert.ToString(i, 8)); 
                }
                await context.RespondAsync($"`{ strb }`");
            }
            else
            {
                await context.RespondAsync("You forgot to enter the value");
            } 
        }
    }
}