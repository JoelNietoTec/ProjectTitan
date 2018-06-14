namespace TitanWebAPI.Models.Financial
{
    using System.ComponentModel.DataAnnotations;

    public partial class AccountType
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string EnglishName { get; set; }
    }
}
