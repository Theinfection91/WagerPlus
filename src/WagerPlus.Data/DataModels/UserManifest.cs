﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Models;

namespace WagerPlus.Data.DataModels
{
    public class UserManifest
    {
        public List<UserProfile> Users { get; set; } = [];
        public UserManifest() { }
    }
}
