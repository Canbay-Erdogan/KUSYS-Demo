﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KusysDemo.Entities
{
    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
