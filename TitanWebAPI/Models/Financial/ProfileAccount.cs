namespace TitanWebAPI.Models.Financial
{
    using System.ComponentModel.DataAnnotations;

    public partial class ProfileAccount
    {
        public int ID { get; set; }

        public int ParticipantProfileID { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        public int? AccountTypeID { get; set; }
    }
}
