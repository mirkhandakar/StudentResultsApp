using System.ComponentModel.DataAnnotations;

namespace StudentResultsApp.Models
{
    public enum Status
    {
        NeedsImprovement,
        Good,
        Excellent
    }

    public class StudentResult
    {
        public int Id { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string CourseTitle { get; set; }

        [Range(0, 100)]
        public int TotalMarks { get; set; }

        public Status Status { get; set; }
    }
}
