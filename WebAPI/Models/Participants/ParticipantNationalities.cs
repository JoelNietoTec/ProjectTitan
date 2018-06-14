using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class ParticipantNationalities
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public int CountryId { get; set; }
    }
}
