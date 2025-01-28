using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.DataModels;
using WagerPlus.Data.Handlers;

namespace WagerPlus.Managers
{
    public class DataManager
    {
        #region Fields and Constructor
        // Discord Config JSON model and read/write Handler
        public DiscordConfigFile discordConfigFile {  get; set; }
        private readonly DiscordConfigHandler _discordConfigHandler;

        public DataManager(DiscordConfigHandler discordConfigHandler)
        {
            _discordConfigHandler = discordConfigHandler;
            LoadDiscordConfigFile();
        }
        #endregion

        #region Discord Configuration File Read/Write Methods
        public void LoadDiscordConfigFile()
        {
            discordConfigFile = _discordConfigHandler.Load();
        }

        public void SaveDiscordConfigFile(DiscordConfigFile discordConfigFile)
        {
            _discordConfigHandler.Save(discordConfigFile);
        }
        #endregion
    }
}
