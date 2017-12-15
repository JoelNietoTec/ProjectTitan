﻿namespace TitanWebAPI.Models.Participants
{
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string EnglishName { get; set; }

        [StringLength(10)]
        public string Abbreviation { get; set; }

        [StringLength(10)]
        public string Code { get; set; }
    }
}