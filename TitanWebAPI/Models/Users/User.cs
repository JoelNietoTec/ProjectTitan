﻿namespace TitanWebAPI.Models.Users
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public int ID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [JsonIgnore]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public int Active { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastChangePassword { get; set; }
    }
}