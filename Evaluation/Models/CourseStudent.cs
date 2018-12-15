namespace Evaluation.Models
{
    public class CourseStudent
    {

        public int sId { get; set; }
        public Student Student { get; set; }

        public int cId { get; set; }
        public Course Course { get; set; }
    }

}