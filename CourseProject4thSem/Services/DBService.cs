using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject4thSem.Entities;
using SQLite;

namespace CourseProject4thSem.Services
{
    public class DBService : IDBService
    {
        public const string DatabaseFilename = "CourseProject4thSem.db";
        string DBPath = Path.Combine("C:\\Users\\Professional\\Desktop\\CourseProject4thSem\\CourseProject4thSem\\Data", DatabaseFilename);
        SQLiteConnection DB;

        public DBService()
        {
            DB = new SQLiteConnection(DBPath);
            DB.CreateTable<User>();
        }

        public bool RegisterUser(string Name, string Surname, string Patronymic, string Login, string Password)
        {
            List<User> Matches =  DB.Table<User>().Where(x => x.UserLogin == Login).ToList();
            if (Matches.Count == 0)
            {
                DB.Insert(new User { UserName = Name, UserSurname = Surname, UserPatronymic = Patronymic, UserLogin = Login, UserPassword = Password, UserWarnings = 0, UserCorrectAnswers = 0, UserIncorrectAnswers = 0, UserTestsPassed = 0});
                return true;
            }
            else
            {
                return false;
            }
        }

        public User LoginUser(string Login, string Password)
        {
            List<User> Matches = DB.Table<User>().Where(x => x.UserLogin == Login ).Where(x=>x.UserPassword==Password).ToList();
            if(Matches.Count == 0) { return  null; }
            else
            {
                return Matches[0];
            }
        }
        public bool LoginUserCheck(string Login, string Password)
        {
            List<User> Matches = DB.Table<User>().Where(x => x.UserLogin == Login).Where(x => x.UserPassword == Password).ToList();
            if (Matches.Count == 0) { return false; }
            else
            {
                return true;
            }
        }
        public List<Review> GetReviewsConfirmed()
        {
            List<Review> Matches = DB.Table<Review>().Where(x => x.ReviewStatus == 1).ToList();
            if (Matches.Count == 0)
            {
                return null;
            }
            return Matches;
        }
        public List<Review> GetReviewsUnconfirmed()
        {
            List<Review> Matches = DB.Table<Review>().Where(x => x.ReviewStatus == 0).ToList();
            if (Matches.Count == 0)
            {
                return null;
            }
            return Matches;
        }
        public bool AddReview(int AuthorID, string AuthorName, string AuthorSurname, int Rating, string Text)
        {
            int rowsAffected = DB.Insert(new Review { ReviewAuthorID = AuthorID, ReviewAuthorName = AuthorName, ReviewAuthorSurname = AuthorSurname, ReviewRating = Rating, ReviewText = Text, ReviewStatus = 0 });
            return Convert.ToBoolean(rowsAffected);
        }
        public bool RemoveReview(int ID)
        {
            int rowsAffected = DB.Delete<Review>(ID);
            return Convert.ToBoolean(rowsAffected);
        }
        public bool ConfirmReview(int ID)
        {
            List<Review> Matches = DB.Table<Review>().Where(x => x.ReviewID == ID).ToList();
            if (Matches.Count == 0 || Matches.Count > 1)
            {
                return false;
            }
            else
            {
                Review reviewToChange = Matches[0];
                reviewToChange.ReviewStatus = 1;
                int rowsAffected = DB.Update(reviewToChange);
                return Convert.ToBoolean(rowsAffected);
            }
        }
        public List<User> GetUsersUnbanned()
        {
            List<User> Matches = DB.Table<User>().Where(x=>x.UserWarnings < 3).ToList();
            if (Matches.Count == 0)
            {
                return null;
            }
            return Matches;
        }
        public List<User> GetUsersBanned()
        {
            List<User> Matches = DB.Table<User>().Where(x=>x.UserWarnings == 3).ToList();
            if (Matches.Count == 0)
            {
                return null;
            }
            return Matches;
        }
        public int GiveWarningToUser(int ID)
        {
            List<User> Matches = DB.Table<User>().Where(x=>x.UserID == ID).ToList();
            if (Matches.Count == 0 || Matches.Count > 1)
            {
                return 1;
            }
            User userToChange = Matches[0];
            if (userToChange.UserWarnings == 3)
            {
                return 2;
            }
            userToChange.UserWarnings = userToChange.UserWarnings + 1;
            int rowsAffected = DB.Update(userToChange);
            if (rowsAffected == 0)
            {
                return 1;
            }
            else 
            {
                return 3;
            }
        }
        public int TakeOffWarningFromUser(int ID)
        {
            List<User> Matches = DB.Table<User>().Where(x => x.UserID == ID).ToList();
            if (Matches.Count == 0 || Matches.Count > 1)
            {
                return 1;
            }
            User userToChange = Matches[0];
            if (userToChange.UserWarnings == 0)
            {
                return 2;
            }
            userToChange.UserWarnings = userToChange.UserWarnings - 1;
            int rowsAffected = DB.Update(userToChange);
            if (rowsAffected == 0)
            {
                return 1;
            }
            else
            {
                return 3;
            }
        }
        public int GiveBanToUser(int ID)
        {
            List<User> Matches = DB.Table<User>().Where(x => x.UserID == ID).ToList();
            if (Matches.Count == 0 || Matches.Count > 1)
            {
                return 1;
            }
            User userToChange = Matches[0];
            if (userToChange.UserWarnings == 3)
            {
                return 2;
            }
            userToChange.UserWarnings = 3;
            int rowsAffected = DB.Update(userToChange);
            if (rowsAffected == 0)
            {
                return 1;
            }
            else
            {
                return 3;
            }
        }
        public int TakeOffBanFromUser(int ID) 
        {
            List<User> Matches = DB.Table<User>().Where(x => x.UserID == ID).ToList();
            if (Matches.Count == 0 || Matches.Count > 1)
            {
                return 1;
            }
            User userToChange = Matches[0];
            if (userToChange.UserWarnings < 3)
            {
                return 2;
            }
            userToChange.UserWarnings = 0;
            int rowsAffected = DB.Update(userToChange);
            if (rowsAffected == 0)
            {
                return 1;
            }
            else
            {
                return 3;
            }
        }
        public int GetUserTestPassed(int ID)
        {
            List<User> Matches = DB.Table<User>().Where(x=>x.UserID == ID).ToList();
            if (Matches.Count == 0 || Matches.Count > 1)
            {
                return -1;
            }
            else
            {
                return Matches[0].UserTestsPassed;
            }
        }
        public int GetUserCorrectAnswers(int ID)
        {
            List<User> Matches = DB.Table<User>().Where(x => x.UserID == ID).ToList();
            if (Matches.Count == 0 || Matches.Count > 1)
            {
                return -1;
            }
            else
            {
                return Matches[0].UserCorrectAnswers;
            }
        }
        public int GetUserIncorrectAnswers(int ID)
        {
            List<User> Matches = DB.Table<User>().Where(x => x.UserID == ID).ToList();
            if (Matches.Count == 0 || Matches.Count > 1)
            {
                return -1;
            }
            else
            {
                return Matches[0].UserIncorrectAnswers;
            }
        }
        public bool UpdateUserStats(int ID, int TestsPassed, int CorrectAnswers, int IncorrectAnswers)
        {
            List<User> Matches = DB.Table<User>().Where(x => x.UserID == ID).ToList();
            if (Matches.Count == 0 || Matches.Count > 1)
            {
                return false;
            }
            User userToChange = Matches[0];
            userToChange.UserTestsPassed = userToChange.UserTestsPassed + TestsPassed;
            userToChange.UserCorrectAnswers = userToChange.UserCorrectAnswers + CorrectAnswers;
            userToChange.UserIncorrectAnswers = userToChange.UserIncorrectAnswers + IncorrectAnswers;
            int rowsAffected = DB.Update(userToChange);
            return Convert.ToBoolean(rowsAffected);
        }
        public int GetUserWarnings(int ID)
        {
            List<User> Matches = DB.Table<User>().Where(x => x.UserID == ID).ToList();
            if (Matches.Count == 0 || Matches.Count > 1)
            {
                return -1;
            }
            else
            {
                return Matches[0].UserWarnings;
            }
        }
    }
}
