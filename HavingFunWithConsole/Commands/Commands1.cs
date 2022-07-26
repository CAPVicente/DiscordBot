using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;

namespace HavingFunWithConsole.Commands
{
    public class Commands1 : BaseCommandModule
    {
        // [RequiresRoles(RoleCheckMode.All, "rol")]

        [Command("alive")]
        [Description("Mandará un mensaje para saber si está en línea.")]
        public async Task Active(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Estoy vivo (unfortunately) :D").ConfigureAwait(false);
        }

        [Command("ping")]
        [Description("Simplemente es el típico comando que ponen en los bots de Discord.")]
        public async Task Pong(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("No, cállate").ConfigureAwait(false);
        }

        [Command("response")]
        [Description("Repite tu mensaje.")]
        public async Task Response(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();

            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(message.Result.Content);
        } 
    }
}
