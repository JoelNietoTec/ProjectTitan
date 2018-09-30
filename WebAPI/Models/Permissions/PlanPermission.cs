namespace WebAPI.Models.Permissions
{
    public partial class PlanPermission
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int ModuleId { get; set; }
        public bool ReadPermission { get; set; }
        public bool WritePermission { get; set; }
        public bool Admin { get; set; }
        public bool Active { get; set; }
    }
}