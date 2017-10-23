namespace TitanWebAPI.Models.Participants
{
    public partial class ParticipantParam
    {
        public int ID { get; set; }

        public int ParticipantID { get; set; }

        public int ParamMatrixID { get; set; }

        public int ParamCategoryID { get; set; }

        public int ParamID { get; set; }

        public virtual Param Param { get; set; }

        public int? ParamValueID { get; set; }

        public virtual ParamValue ParamValue { get; set; }

        public int? ParamSubValueID { get; set; }

        public virtual ParamSubValue ParamSubValue { get; set; }

        public decimal? Score { get; set; }
    }
}