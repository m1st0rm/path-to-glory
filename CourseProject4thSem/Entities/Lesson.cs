using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject4thSem.Entities
{
    public class Lesson
    {
        public int LessonID { get; set; }
        public int CourseID { get; set; }
        public Article LessonArticle { get; set; }
        public string LessonName { get; set;}
    }
}
