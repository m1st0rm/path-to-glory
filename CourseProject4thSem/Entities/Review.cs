using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CourseProject4thSem.Entities
{
    [Table("Reviews")]
    public class Review
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int ReviewID { get; set; }
        public int ReviewAuthorID { get; set; }
        public string ReviewAuthorName { get; set; }
        public string ReviewAuthorSurname { get; set; }
        public int ReviewRating { get; set; }
        public string ReviewText { get; set; }
        public int ReviewStatus { get; set; }
    }
}