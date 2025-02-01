using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using Discord.WebSocket;
using WagerPlus.Core.Enums.PoolEnums;
using WagerPlus.Core.Models.Pools;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.PoolCommands
{
    public class OpenPoolLogic : Logic
    {
        private PoolManager _poolManager;
        public OpenPoolLogic(PoolManager poolManager) : base("Open Pool")
        {
            _poolManager = poolManager;
        }

        public string OpenPoolProcess(SocketInteractionContext context, string poolIdOne, string poolIdTwo)
        {
            // Check if given Id's match exactly
            if (poolIdOne.Equals(poolIdTwo))
            {
                // Check if given Id is in database
                if (_poolManager.IsPoolIdInDatabase(poolIdOne))
                {
                    // Grab pool
                    Pool? pool = _poolManager.GetPoolById(poolIdOne);

                    // TODO: Check if invoker is owner of pool (or admin)
                    if (context.User is not SocketGuildUser guildUser)
                    {
                        return "This command must be used in a guild.";
                    }
                    bool IsAdmin = guildUser.GuildPermissions.Administrator;
                    if (_poolManager.IsUserPoolOwner(context.User.Id, pool) || IsAdmin)
                    {
                        // Check if targets were set
                        if (_poolManager.IsBothTargetsSetInPool(pool))
                        {
                            // Check if targets are locked so odds are set
                            if (_poolManager.IsTargetsLocked(pool))
                            {
                                // Check current status
                                if (!_poolManager.IsPoolOpen(pool))
                                {
                                    // Change status
                                    _poolManager.SetPoolStatus(pool, PoolStatus.Open);

                                    _poolManager.SaveAndReloadBettingPoolsDatabase();

                                    return $"{pool.Name} is now {pool.Status} for wagers!";
                                }
                                return $"The pool is already open.";
                            }
                            return $"Choices have not been generated for {pool.Name}";
                        }
                        return $"Both targets have not been set in {pool.Name}";
                    }
                    return $"You are not the owner of {pool.Name}, nor do you have admin permissions... {pool.OwnerDisplayName} is the owner.";
                }
                return $"Given pool ID not found in Database: {poolIdOne}";
            }
            return $"The ID's entered did not match. Make sure the P is capital as well. You entered: '{poolIdOne}' - '{poolIdTwo}'";
        }
    }
}
