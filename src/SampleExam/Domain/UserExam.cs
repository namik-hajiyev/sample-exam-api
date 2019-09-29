using System;

namespace SampleExam.Domain
{
    public class UserExam
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int UserId { get; set; }
        public DateTime StartedtedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Exam Exam { get; set; }
        public User User { get; set; }
    }
}