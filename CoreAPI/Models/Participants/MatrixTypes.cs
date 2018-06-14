using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class MatrixTypes
    {
        public MatrixTypes()
        {
            ParamMatrices = new HashSet<ParamMatrix>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }

        public ICollection<ParamMatrix> ParamMatrices { get; set; }
    }
}
