using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CourseProject4thSem.Entities
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserSurname {get; set; }
        public string UserPatronymic { get; set; }
        public int UserWarnings { get; set; }
        public int UserTestsPassed { get; set; }
        public int UserCorrectAnswers { get; set; }
        public int UserIncorrectAnswers { get; set; }
        [Unique]
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
    }
}
