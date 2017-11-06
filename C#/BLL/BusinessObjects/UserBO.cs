﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessObjects
{
    public class UserBO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsAdmin { get; set; }
    }
}