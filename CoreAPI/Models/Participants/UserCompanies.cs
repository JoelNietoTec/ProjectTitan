using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Participants
{
    public partial class UserCompanies
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public int? UserId { get; set; }
    }
}
