namespace WebAPI.Models.Users
{
    public partial class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public bool Admin { get; set; }
    }
}