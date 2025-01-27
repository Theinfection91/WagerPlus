using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.DataInterfaces;

namespace WagerPlus.Data.DataModels
{
    public class UserManifest
    {
        public List<IUserSavable> Users { get; set; } = [];
        public UserManifest() { }
    }
}
