using System;
using System.Collections.Generic;

namespace WebAPI.Models.Assignments
{
    public partial class Participants
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public int GenderId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public int ParticipantTypeId { get; set; }
        public string Address { get; set; }
        public string WebSite { get; set; }
        public string LegalRepresentative { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public int? ParamMatrixId { get; set; }
        public decimal? Score { get; set; }
        public string Rate { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? PurposeId { get; set; }
        public bool? Pep { get; set; }
        public bool? MatrixReady { get; set; }
        public int CountryId { get; set; }
        public bool? Status { get; set; }

        public Users CreatedUser { get; set; }
    }
}
