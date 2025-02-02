﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.DataModels;

namespace WagerPlus.Data.Handlers
{
    public class PermissionsConfigHandler : DataHandler<PermissionsConfigFile>
    {
        public PermissionsConfigHandler() : base("permissions_config.json", "Configs")
        {

        }
    }
}
