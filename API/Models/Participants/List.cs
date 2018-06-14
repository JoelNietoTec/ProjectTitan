namespace TitanWebAPI.Models.Participants
{
    using System.ComponentModel.DataAnnotations;

    public partial class List
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
