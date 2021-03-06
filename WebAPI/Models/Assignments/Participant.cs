﻿using System;
using System.Collections.Generic;

namespace WebAPI.Models.Assignments
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
