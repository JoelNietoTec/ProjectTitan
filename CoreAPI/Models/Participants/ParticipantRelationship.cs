namespace CoreAPI.Models.Participants
{
    using Microsoft.EntityFrameworkCore.Infrastructure;
    public partial class ParticipantRelationship
    {
        private ParticipantRelationship(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
        private ILazyLoader LazyLoader { get; set; }

        public int Id { get; set; }
        public int? ParticipantId { get; set; }
        public int? RelatedParticipantId { get; set; }
        public int? RelationshipTypeId { get; set; }

        private Participant _participant;
        private Participant _relatedParticipant;
        private RelationshipType _type;

        public Participant Participant
        {
            get => LazyLoader?.Load(this, ref _participant);
            set => _participant = value;
        }

        public Participant RelatedParticipant
        {
            get => LazyLoader?.Load(this, ref _relatedParticipant);
            set => _relatedParticipant = value;
        }

        public RelationshipType Type
        {
            get => LazyLoader?.Load(this, ref _type);
            set => _type = value;
        }
    }
}
