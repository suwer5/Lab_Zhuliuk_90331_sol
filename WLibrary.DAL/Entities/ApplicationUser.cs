﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WLibrary.DAL.Entities
{
    public class ApplicationUser: IdentityUser

    {
        public byte[] AvatarImage { get; set; }
    }
}
