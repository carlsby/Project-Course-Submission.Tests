using Project_Course_Submission.Models;
using Project_Course_Submission.Models.Entities;

namespace Project_Course_Submission.Tests.UnitTest
{
    internal class Review : ReviewModel
    {
        public int Id { get; set; }
        public DateTime CommentCreated { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}