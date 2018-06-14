using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace CoreAPI.Models.Assignments
{
    public partial class Assignment
    {
        private Assignment(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader;

        public int Id { get; set; }
        public int AssignmentTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreateUserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int? AssignedUserId { get; set; }
        public int? ParticipantId { get; set; }
        public int? ProgressId { get; set; }

        private AssignmentType _type;
        private User _createUser;
        private User _assignedUser;
        private Participant _participant;
        private Progress _progress;

        public AssignmentType Type
        {
            get => LazyLoader?.Load(this, ref _type);
            set => _type = value;
        }

        public User CreateUser
        {
            get => LazyLoader?.Load(this, ref _createUser);
            set => _createUser = value;
        }

        public User AssignedUser
        {
            get => LazyLoader?.Load(this, ref _assignedUser);
            set => _assignedUser = value;
        }

        public Participant Participant
        {
            get => LazyLoader?.Load(this, ref _participant);
            set => _participant = value;
        }

        public Progress Progress
        {
            get => LazyLoader?.Load(this, ref _progress);
            set => _progress = value;
        }

    }
}
