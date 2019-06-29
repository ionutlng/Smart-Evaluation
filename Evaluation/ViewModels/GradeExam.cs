namespace Evaluation.ViewModels
{
    public class GradeExam
    {
        public string QuestionText { get; set; }
        public string StudentAnswer { get; set; }
        public string CorrectAnswer { get; set; }

        public decimal? Grade { get; set; }
    }
}
