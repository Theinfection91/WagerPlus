using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Models;

namespace WagerPlus.Managers
{
    public class CurrencyManager : DataDriven
    {
        public CurrencyManager(DataManager dataManager) : base("CurrencyManager", dataManager)
        {

        }

        public bool HasEnoughFunds(UserProfile userProfile, int wagerAmount)
        {
            return userProfile.MainCurrency.GetTotalCurrency() >= wagerAmount;
        }

        public int GetUserBalance(UserProfile userProfile)
        {
            return userProfile.MainCurrency.GetTotalCurrency();
        }

        public int GetWagerPayout(int wagerAmount, decimal wagerOdds)
        {
            return (int)(wagerAmount * wagerOdds);
        }

        public void AddAmountToUserMainCurrency(UserProfile userProfile, int amount)
        {
            userProfile.MainCurrency.Add(amount);
        }

        public void SubtractAmountFromUserMainCurrency(UserProfile userProfile, int amount)
        {
            userProfile.MainCurrency.Subtract(amount);
        }

        public void AddAmountToUserMiniGameCurrency(UserProfile userProfile, int amount)
        {
            userProfile.MiniGameCurrency.Add(amount);
        }

        public void SubtractAmountFromUserMiniGameCurrency(UserProfile userProfile, int amount)
        {
            userProfile.MiniGameCurrency.Add(amount);
        }
    }
}
