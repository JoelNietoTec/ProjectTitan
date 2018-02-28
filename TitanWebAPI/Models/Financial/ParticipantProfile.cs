namespace TitanWebAPI.Models.Financial
{
    using System;
    using System.Collections.Generic;

    public partial class ParticipantProfile
    {
        public ParticipantProfile()
        {
            Accounts = new HashSet<ProfileAccount>();
        }

        public int ID { get; set; }

        public int ParticipantID { get; set; }

        public decimal? Total { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<ProfileAccount> Accounts { get; set; }
    }
}
