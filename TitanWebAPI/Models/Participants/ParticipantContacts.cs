namespace TitanWebAPI.Models.Participants
{
    using System.ComponentModel.DataAnnotations;

    public partial class ParticipantContacts
    {
        public int ID { get; set; }

        public int ParticipantID { get; set; }

        public int Correlative { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string MobilePhone { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }


    }
}