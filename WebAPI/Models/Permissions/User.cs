using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Permissions
{
    [Table("UsersInfo")]
    public partial class User
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Active { get; set; }
        public DateTime? CreateDate { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
