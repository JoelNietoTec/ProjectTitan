namespace WebAPI.Models.Permissions
{
    public partial class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
    }
}