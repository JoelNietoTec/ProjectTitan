namespace TitanWebAPI.Models.Tasks
{
    using System.ComponentModel.DataAnnotations;

    public partial class TaskStatu
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string EnglishName { get; set; }
    }
}
