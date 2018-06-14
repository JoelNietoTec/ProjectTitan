using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Assignments
{
    public partial class Participant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public int ParticipantTypeId { get; set; }
        public decimal? Score { get; set; }
        public DateTime? CreateDate { get; set; }

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
    }
}
