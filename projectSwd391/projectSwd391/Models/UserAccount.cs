using System;
using System.Collections.Generic;

namespace projectSwd391.Models
{
    public partial class UserAccount
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHashAlgorithm { get; set; }
        public string Email { get; set; }
        public bool? DelFlg { get; set; }
        public long? Ver { get; set; }
        public int InsId { get; set; }
        public DateTime InsDateTime { get; set; }
        public int? UpdId { get; set; }
        public DateTime? UpdDateTime { get; set; }

        public virtual UserProfile IdNavigation { get; set; }
        public virtual UserRole Role { get; set; }
    }
}
