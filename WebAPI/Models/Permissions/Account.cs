using System;
using System.Collections.Generic;

namespace WebAPI.Models.Permissions
{
    public partial class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public DateTime? CreateDate { get; set; }
        public int PlanId { get; set; }
        public virtual Plan Plan { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<User> Users {get;set;}
    }
}