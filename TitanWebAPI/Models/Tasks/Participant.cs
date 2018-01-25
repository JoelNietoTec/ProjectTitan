namespace TitanWebAPI.Models.Tasks
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Participant
    {

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
    }
}