using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject4thSem.Entities
{
    public class Question
    {
        public int CourseID { get; set; }
        public int LessonID { get; set; }
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public string Statement1 { get; set; }
        public string Statement2 { get; set; }
        public string Statement3 { get; set; }
        public string Statement4 { get; set; }
        public string CorrectStatement { get; set; }
        public int CoorrectStatementNumber { get; set; }
    }
}
