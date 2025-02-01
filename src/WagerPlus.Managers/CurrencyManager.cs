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
            return userProfile.Currency.GetTotalCurrency() >= wagerAmount;
        }

        public int GetUserBalance(UserProfile userProfile)
        {
            return userProfile.Currency.GetTotalCurrency();
        }

        public int GetWagerPayout(int wagerAmount, decimal wagerOdds)
        {
            return (int)(wagerAmount * wagerOdds);
        }

        public void AddAmountToUserCurrency(UserProfile userProfile, int amount)
        {
            userProfile.Currency.Add(amount);
        }

        public void SubtractAmountFromUserCurrency(UserProfile userProfile, int amount)
        {
            userProfile.Currency.Subtract(amount);
        }
    }
}
