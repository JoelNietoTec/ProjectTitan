namespace WebAPI.Models.Participants
{
    public partial class Param
    {
        public int Id { get; set; }
        public int ParamMatrixId { get; set; }
        public int ParamCategoryId { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string Description { get; set; }
        public int ParamTableId { get; set; }
        public decimal? Weighting { get; set; }
        public virtual ParamMatrix Matrix { get; set; }
        public virtual ParamTable Table { get; set; }
    }
}
