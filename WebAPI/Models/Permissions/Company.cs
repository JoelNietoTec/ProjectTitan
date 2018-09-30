namespace WebAPI.Models.Permissions
{
    public partial class Company
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int CompanyTypeId { get; set; }
        public virtual CompanyType Type { get; set; }
        public virtual Account Account { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public int IndustryId { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
    }
}