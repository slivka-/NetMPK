﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetMPK
{
    public class User
    {
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int UserStatus { get; set; }
        public int VerificationCode { get; set; }
    }
}