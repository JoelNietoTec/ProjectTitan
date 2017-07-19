﻿namespace TitanWebAPI.Models.Participants
{
    using System.ComponentModel.DataAnnotations;

    public partial class ParticipantType
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string EnglishName { get; set; }
    }
}