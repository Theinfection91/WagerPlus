﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.DataModels;

namespace WagerPlus.Data.Handlers
{
    public class DiscordCredentialHandler : DataHandler<DiscordCredentialFile>
    {
        public DiscordCredentialHandler() : base("discord_credentials.json", "Discord Credentials") { }
    }
}
