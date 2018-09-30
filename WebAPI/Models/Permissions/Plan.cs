using System.Collections.Generic;

namespace WebAPI.Models.Permissions
{
    public partial class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string Description { get; set; }
        public decimal MonthlyFee { get; set; }
        public bool Active { get; set; }
        public int CompanyLimit { get; set; }
        public int UsersLimit { get; set; }
        public virtual ICollection<PlanPermission> Permissions {get; set;}
    }
}