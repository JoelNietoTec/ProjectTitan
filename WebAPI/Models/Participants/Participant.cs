using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace WebAPI.Models.Participants
{
    public partial class Participant
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
        public DateTime? CreateDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? PurposeId { get; set; }
        public bool? Pep { get; set; }
        public bool? MatrixReady { get; set; }
        public int CountryId { get; set; }
        public bool? Status { get; set; }
        public string Rate
        {
            get
            {
                if (Score == null)
                {
                    return "Incompleto";
                }
                else if (Score < 3)
                {
                    return "Bajo";
                }
                else if (Score < 6)
                {
                    return "Medio";
                }
                else
                {
                    return "Alto";
                }
            }

        }
        public string FullName
        {
            get
            {
                if (ParticipantTypeId == 1)
                    return ThirdName + " " + FourthName + ", " + FirstName + " " + SecondName;
                else
                    return FirstName;
            }
        }
        public string ShortName
        {
            get
            {
                if (ParticipantTypeId == 1)
                    return FirstName + " " + ThirdName;
                else
                    return SecondName;
            }
        }
        public virtual Gender Gender { get; set; }
        public virtual Country Country { get; set; }
        public virtual ParticipantType Type { get; set; }
        public virtual User CreatedUser { get; set; }      

    }
}