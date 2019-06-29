namespace Evaluation.ViewModels
{
    public class StudGrades
    {
        public string ApplicationUserId { get; set; }
        public bool IsSolved { get; set; }
        public decimal? Grade { get; set; }
        public int? Group { get; set; }
        public string studExamId { get; set; }
    }
}
