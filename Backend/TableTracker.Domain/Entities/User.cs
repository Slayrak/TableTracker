using System;
using System.Collections.Generic;
using System.Text;

namespace TableTracker.Domain.Entities
{
    public class User
    {
        public string FullName { get; set; }

        public string Avatar { get; set; }

        //public UserRole Role { get; set; }

        public string Email { get; set; }
    }
}
