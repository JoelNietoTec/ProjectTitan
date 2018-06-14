using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class ParticipantContacts
    {
        public int Id { get; set; }
        public int Correlative { get; set; }
        public int ParticipantId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
    }
}
