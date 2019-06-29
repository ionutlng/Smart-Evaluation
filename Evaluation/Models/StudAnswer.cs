using System.ComponentModel.DataAnnotations;

namespace Evaluation.Models
{
    public partial class StudAnswer
    {
        [Key]
        public string AnswerId { get; set; }
        public string Answer { get; set; }
        public string ExamId { get; set; }
        public int QuestionId { get; set; }


        public virtual Question Question { get; set; }
    }
}
