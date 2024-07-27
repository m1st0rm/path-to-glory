using CourseProject4thSem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject4thSem.Services
{
    public interface IDBService
    {
        public User LoginUser(string Login, string Password);
        public bool LoginUserCheck(string Login, string Password);
        public bool RegisterUser(string Name, string Surname, string Patronymic, string Login, string Password);
        public List<Review> GetReviewsConfirmed();
        public List<Review> GetReviewsUnconfirmed();
        public bool AddReview (int AuthorID, string AuthorName, string AuthorSurname, int Rating, string Text);
        public bool RemoveReview (int ID);
        public bool ConfirmReview(int ID);
        public List<User> GetUsersUnbanned();
        public List<User> GetUsersBanned();
        public int GiveWarningToUser(int ID);
        public int TakeOffWarningFromUser(int ID);
        public int GiveBanToUser(int ID);
        public int TakeOffBanFromUser(int ID);
        public int GetUserTestPassed(int ID);
        public int GetUserCorrectAnswers(int ID);
        public int GetUserIncorrectAnswers(int ID);
        public bool UpdateUserStats(int ID, int TestsPassed, int CorrectAnswers, int IncorrectAnswers);
        public int GetUserWarnings (int ID);
    }
}
