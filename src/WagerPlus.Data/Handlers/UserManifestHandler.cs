using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.DataModels;

namespace WagerPlus.Data.Handlers
{
    public class UserManifestHandler : DataHandler<UserManifest>
    {
        public UserManifestHandler() : base("user_manifest.json", "Databases") { }
    }
}
