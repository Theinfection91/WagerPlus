using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.DataModels;

namespace WagerPlus.Data.Handlers
{
    public class UserProfileHandler : DataHandler<UserProfileList>
    {
        public UserProfileHandler() : base("user_manifest.json", "Databases") { }
    }
}
