﻿using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Discord.Commands;

namespace SysBot.ACNHOrders
{
    public class MapModule : ModuleBase<SocketCommandContext>
    {
        [Command("loadLayer")]
        [Summary("Changes the current refresher layer to a new .nhl field item layer")]
        [RequireQueueRole(nameof(Globals.Bot.Config.RoleUseBot))]
        public async Task SetFieldLayerAsync(string filename)
        {
                var bot = Globals.Bot;

                if (!bot.Config.AllowLayoutChange && !bot.Config.CanUseSudo(Context.User.Id) && Globals.Self.Owner != Context.User.Id)

                if (!bot.Config.AllowLayoutChange)
                    {
                        await ReplyAsync($"Layout change functionality is currently disabled.").ConfigureAwait(false);
                        return;
                    }

                if (!bot.Config.DodoModeConfig.LimitedDodoRestoreOnlyMode)
                    {
                        await ReplyAsync($"This command can only be used in dodo restore mode with refresh map set to true.").ConfigureAwait(false);
                        return;
                    }

                if (!filename.ToLower().EndsWith(".nhl"))
                        filename += ".nhl";
                    filename = Path.Combine(bot.Config.FieldLayerNHLDirectory, filename);
                    if (!File.Exists(filename))
                    {
                        await ReplyAsync($"File {filename} does not exist or does not have the correct .nhl extension.").ConfigureAwait(false);
                        return;
                    }

                var bytes = File.ReadAllBytes(filename);
                var req = new MapOverrideRequest(Context.User.Username, bytes);
                bot.MapOverrides.Enqueue(req);

                await ReplyAsync($"Map refresh layer set to: {Path.GetFileNameWithoutExtension(filename)}.").ConfigureAwait(false);
        }
    }
}
