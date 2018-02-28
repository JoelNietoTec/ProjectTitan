namespace TitanWebAPI.Models.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Participant
    {
        public Participant()
        {
            Tasks = new HashSet<Task>();
        }

        public int ID { get; set; }

        [StringLength(200)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string SecondName { get; set; }

        [StringLength(100)]
        public string ThirdName { get; set; }

        [StringLength(100)]
        public string FourthName { get; set; }

        public int ParticipantTypeID { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreatedBy { get; set; }

        public decimal? Score { get; set; }

        public string FullName
        {
            get
            {
                if (ParticipantTypeID == 1)
                    return ThirdName + " " + FourthName + ", " + FirstName + " " + SecondName;
                else
                    return FirstName;
            }
        }

        public string ShortName
        {
            get
            {
                if (ParticipantTypeID == 1)
                    return FirstName + " " + ThirdName;
                else
                    return SecondName;
            }
        }

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

        public virtual ICollection<Task> Tasks { get; set; }
    }
}