using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject4thSem.Entities
{
    public class Article
    {
        public int ArticleID { get; set; }
        public int LessonID { get; set; }
        public int CourseID { get; set; }
        public string Text { get; set;}
        public string ImagePath { get; set; }
    }
}
