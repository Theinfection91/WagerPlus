using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.Data.DataModels
{
    public class PermissionsConfigFile
    {
        public bool CanAnyoneCreatePools { get; set; } = false;
        public List<ulong> CertifiedBookies { get; set; } = [];
        public List<ulong> DeputyAdmins { get; set; } = [];
        public PermissionsConfigFile() { }
    }
}
