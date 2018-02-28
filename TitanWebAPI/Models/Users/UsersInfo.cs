namespace TitanWebAPI.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UsersInfo")]
    public partial class UsersInfo
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int Active { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}