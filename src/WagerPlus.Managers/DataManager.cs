using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using WagerPlus.Core.Models.Pools;
using WagerPlus.Data.DataModels;
using WagerPlus.Data.DataModels.MyTournament;
using WagerPlus.Data.Handlers;

namespace WagerPlus.Managers
{
    public class DataManager
    {
        #region Fields and Constructor
        public string Name { get; set; } = "DataManager";

        // Bank Vaults Data
        public BankVaults BankVaults { get; set; }
        private BankVaultsHandler _bankVaultsHandler;

        // Betting Pools Data
        public BettingPools BettingPoolsDatabase { get; set; }
        private BettingPoolsHandler _betttingPoolsHandler;

        // Currency Config
        public CurrencyConfigFile CurrencyConfigFile { get; set; }
        private readonly CurrencyConfigHandler _currencyConfigHandler;

        // Discord Config
        public DiscordCredentialFile DiscordConfigFile { get; set; }
        private readonly DiscordCredentialHandler _discordConfigHandler;

        // MyTournament Data
        public MyTournamentMatrix MyTournamentMatrix { get; set; }
        private readonly MyTournamentHandler _myTournamentHandler;

        // PayPal Config
        public PayPalConfigFile PayPalConfigFile { get; set; }
        private readonly PayPalConfigHandler _payPalConfigHandler;

        // Permissions Config
        public PermissionsConfigFile PermissionsConfigFile { get; set; }
        private PermissionsConfigHandler _permissionsConfigFileHandler;

        // User Profiles Data
        public UserProfileList UserProfileList { get; set; }
        private readonly UserProfileHandler _userProfileHandler;

        public DataManager(BankVaultsHandler bankVaultsHandler, BettingPoolsHandler bettingPoolsHandler, CurrencyConfigHandler currencyConfigHandler, DiscordCredentialHandler discordConfigHandler, MyTournamentHandler myTournamentHandler, PayPalConfigHandler payPalConfigHandler, PermissionsConfigHandler permissionsConfigHandler, UserProfileHandler userProfileHandler)
        {
            _bankVaultsHandler = bankVaultsHandler;
            LoadBankVaults();
            
            _betttingPoolsHandler = bettingPoolsHandler;
            LoadBettingPoolsDatabase();

            _currencyConfigHandler = currencyConfigHandler;
            LoadCurrencyConfigFile();

            _discordConfigHandler = discordConfigHandler;
            LoadDiscordConfigFile();

            _myTournamentHandler = myTournamentHandler;
            LoadMyTournamentMatrix();

            _payPalConfigHandler = payPalConfigHandler;
            LoadPayPalConfigFile();

            _permissionsConfigFileHandler = permissionsConfigHandler;
            LoadPermissionsConfigFile();

            _userProfileHandler = userProfileHandler;
            LoadUserProfileList();
        }
        #endregion

        #region Bank Vaults Data
        public void LoadBankVaults()
        {
            BankVaults = _bankVaultsHandler.Load();
        }

        public void SaveBankVaults(BankVaults bankVaults)
        {
            _bankVaultsHandler.Save(bankVaults);
        }
        #endregion

        #region Betting Pools Data
        public void LoadBettingPoolsDatabase()
        {
            BettingPoolsDatabase = _betttingPoolsHandler.Load();
        }

        public void SaveBettingPoolsDatabase(BettingPools bettingPools)
        {
            _betttingPoolsHandler.Save(bettingPools);
        }

        public void SaveAndReloadBettingPoolsDatabase()
        {
            SaveBettingPoolsDatabase(BettingPoolsDatabase);
            LoadBettingPoolsDatabase();
        }

        public void AddPoolToDatabase(Pool pool)
        {
            if (pool != null)
            {
                BettingPoolsDatabase.Pools.Add(pool);
                SaveAndReloadBettingPoolsDatabase();
            }
        }

        public void RemovePoolFromDatabase(string poolId)
        {
            if (poolId != null)
                for (int i = 0; i < BettingPoolsDatabase.Pools.Count; i++)
                    if (BettingPoolsDatabase.Pools[i].Id.Equals(poolId))
                    {
                        Pool poolToRemove = BettingPoolsDatabase.Pools[i];
                        BettingPoolsDatabase.Pools.Remove(poolToRemove);
                        SaveAndReloadBettingPoolsDatabase();
                    }
        }
        #endregion

        #region Currency Configuration
        public void LoadCurrencyConfigFile()
        {
            CurrencyConfigFile = _currencyConfigHandler.Load();
        }

        public void SaveCurrencyConfigFile(CurrencyConfigFile currencyConfigFile)
        {
            _currencyConfigHandler.Save(currencyConfigFile);
        }

        public void SaveAndReloadCurrencyConfigFile()
        {
            SaveCurrencyConfigFile(CurrencyConfigFile);
            LoadCurrencyConfigFile();
        }
        #endregion

        #region Discord Configuration
        public void LoadDiscordConfigFile()
        {
            DiscordConfigFile = _discordConfigHandler.Load();
        }

        public void SaveDiscordConfigFile()
        {
            _discordConfigHandler.Save(DiscordConfigFile);
        }

        public void SaveAndReloadDiscordConfigFile()
        {
            SaveDiscordConfigFile();
            LoadDiscordConfigFile();
        }
        #endregion

        #region MyTournament Data
        public void LoadMyTournamentMatrix()
        {
            MyTournamentMatrix = _myTournamentHandler.Load();
        }

        public void SaveMyTournamentMatrix()
        {
            _myTournamentHandler.Save(MyTournamentMatrix);
        }

        public void SaveAndReloadMyTournamentMatrix()
        {
            SaveMyTournamentMatrix();
            LoadMyTournamentMatrix();
        }
        #endregion

        #region PayPal Configuration
        public void LoadPayPalConfigFile()
        {
            PayPalConfigFile = _payPalConfigHandler.Load();
        }

        public void SavePayPalConfigFile()
        {
            _payPalConfigHandler.Save(PayPalConfigFile);
        }
        #endregion

        #region Permissions Configuration
        public void LoadPermissionsConfigFile()
        {
            PermissionsConfigFile = _permissionsConfigFileHandler.Load();
        }

        public void SavePermissionsConfigFile()
        {
            _permissionsConfigFileHandler.Save(PermissionsConfigFile);
        }

        public void SaveAndReloadPermissionsConfigFile()
        {
            SavePermissionsConfigFile();
            LoadPermissionsConfigFile();
        }
        #endregion

        #region User Profile List Data
        public void LoadUserProfileList()
        {
            UserProfileList = _userProfileHandler.Load();
        }

        public void SaveUserProfileList(UserProfileList userProfileList)
        {
            _userProfileHandler.Save(userProfileList);
        }

        public void SaveAndReloadUserProfileList()
        {
            SaveUserProfileList(UserProfileList);
            LoadUserProfileList();
        }
        #endregion
    }
}
