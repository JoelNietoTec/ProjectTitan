namespace API.Models.Participants
{
    public class PendingDocument
    {
        public int ID { get; set; }

        public int ParticipantID { get; set; }

        public string Name { get; set; }

        public string EnglishName { get; set; }

        public int Uploaded { get; set; }
    }
}
