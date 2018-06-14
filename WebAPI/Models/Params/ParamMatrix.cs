using System;
using System.Collections.Generic;

namespace WebAPI.Models.Params
{
    public partial class ParamMatrix
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModificateDate { get; set; }
        public int MatrixTypeId { get; set; }

        public virtual MatrixType Type { get; set; }
    }
}
