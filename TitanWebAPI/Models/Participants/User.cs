namespace TitanWebAPI.Models.Participants
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class User
    {
        public int ID { get; set; }
        
        public string Email { get; set; }

        public string UserName { get; set; }
    }
}