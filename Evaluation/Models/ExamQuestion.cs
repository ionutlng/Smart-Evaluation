namespace Evaluation.Models
{
    public class ExamQuestion
    {
        public int qId { get; set; }
        public Question Question { get; set; }

        public int eId { get; set; }
        public Exam Exam { get; set; }
    }
}