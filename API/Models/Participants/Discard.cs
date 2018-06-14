namespace TitanWebAPI.Models.Participants
{
    using System;

    public partial class Discard
    {
        public int ID { get; set; }

        public int? ListID { get; set; }

        public virtual List List { get; set; }

        public DateTime? Date { get; set; }
    }
}
