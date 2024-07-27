using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProject4thSem.Entities;
using CourseProject4thSem.Resources.Texts;

namespace CourseProject4thSem.Services
{
    public class Initializer
    {
        public Initializer() 
        {
            ArticlesInit();
            LessonsInit();
            QuestionsInit();
        }
        public List<Article> Articles = new List<Article>();
        public List<Lesson> Lessons = new List<Lesson>();
        public Course Bio = new Course { CourseID = 1, CourseName = Texts.BIO_TEXT_CN, CourseDescription = Texts.BIO_TEXT_CD };
        public List<Question> Questions = new List<Question>();
        
        private void ArticlesInit()
        {
            Articles.Add(new Article { ArticleID = 1, CourseID = 1, LessonID = 1, Text = Texts.BIO_TEXT_LT1, ImagePath = Texts.BIO_TEXT_L1IP }) ;
            Articles.Add(new Article { ArticleID = 2, CourseID = 1, LessonID = 2, Text = Texts.BIO_TEXT_LT2, ImagePath = Texts.BIO_TEXT_L2IP }) ;
            Articles.Add(new Article { ArticleID = 3, CourseID = 1, LessonID = 3, Text = Texts.BIO_TEXT_LT3, ImagePath = Texts.BIO_TEXT_L3IP }) ;
            Articles.Add(new Article { ArticleID = 4, CourseID = 1, LessonID = 4, Text = Texts.BIO_TEXT_LT4, ImagePath = Texts.BIO_TEXT_L4IP }) ;
            Articles.Add(new Article { ArticleID = 5, CourseID = 1, LessonID = 5, Text = Texts.BIO_TEXT_LT5, ImagePath = Texts.BIO_TEXT_L5IP }) ;
        }
        private void LessonsInit()
        {
            Lessons.Add(new Lesson { CourseID = 1, LessonID = 1, LessonName = Texts.BIO_TEXT_LN1, LessonArticle = Articles[0] });
            Lessons.Add(new Lesson { CourseID = 1, LessonID = 2, LessonName = Texts.BIO_TEXT_LN2, LessonArticle = Articles[1] });
            Lessons.Add(new Lesson { CourseID = 1, LessonID = 3, LessonName = Texts.BIO_TEXT_LN3, LessonArticle = Articles[2] });
            Lessons.Add(new Lesson { CourseID = 1, LessonID = 4, LessonName = Texts.BIO_TEXT_LN4, LessonArticle = Articles[3] });
            Lessons.Add(new Lesson { CourseID = 1, LessonID = 5, LessonName = Texts.BIO_TEXT_LN5, LessonArticle = Articles[4] });
        }
        private void QuestionsInit()
        {
            Questions.Add(new Question { CourseID = 1, LessonID = 1, QuestionID = 1, QuestionText = Texts.BIO_TEXT_L1_QT1, Statement1 = Texts.BIO_TEXT_L1_Q1S1, Statement2 = Texts.BIO_TEXT_L1_Q1S2, Statement3 = Texts.BIO_TEXT_L1_Q1S3, Statement4 = Texts.BIO_TEXT_L1_Q1S4, CorrectStatement = Texts.BIO_TEXT_L1_Q1СS, CoorrectStatementNumber = Texts.BIO_L1_Q1_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 1, QuestionID = 2, QuestionText = Texts.BIO_TEXT_L1_QT2, Statement1 = Texts.BIO_TEXT_L1_Q2S1, Statement2 = Texts.BIO_TEXT_L1_Q2S2, Statement3 = Texts.BIO_TEXT_L1_Q2S3, Statement4 = Texts.BIO_TEXT_L1_Q2S4, CorrectStatement = Texts.BIO_TEXT_L1_Q2СS, CoorrectStatementNumber = Texts.BIO_L1_Q2_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 1, QuestionID = 3, QuestionText = Texts.BIO_TEXT_L1_QT3, Statement1 = Texts.BIO_TEXT_L1_Q3S1, Statement2 = Texts.BIO_TEXT_L1_Q3S2, Statement3 = Texts.BIO_TEXT_L1_Q3S3, Statement4 = Texts.BIO_TEXT_L1_Q3S4, CorrectStatement = Texts.BIO_TEXT_L1_Q3СS, CoorrectStatementNumber = Texts.BIO_L1_Q3_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 1, QuestionID = 4, QuestionText = Texts.BIO_TEXT_L1_QT4, Statement1 = Texts.BIO_TEXT_L1_Q4S1, Statement2 = Texts.BIO_TEXT_L1_Q4S2, Statement3 = Texts.BIO_TEXT_L1_Q4S3, Statement4 = Texts.BIO_TEXT_L1_Q4S4, CorrectStatement = Texts.BIO_TEXT_L1_Q4СS, CoorrectStatementNumber = Texts.BIO_L1_Q4_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 1, QuestionID = 5, QuestionText = Texts.BIO_TEXT_L1_QT5, Statement1 = Texts.BIO_TEXT_L1_Q5S1, Statement2 = Texts.BIO_TEXT_L1_Q5S2, Statement3 = Texts.BIO_TEXT_L1_Q5S3, Statement4 = Texts.BIO_TEXT_L1_Q5S4, CorrectStatement = Texts.BIO_TEXT_L1_Q5СS, CoorrectStatementNumber = Texts.BIO_L1_Q5_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 2, QuestionID = 1, QuestionText = Texts.BIO_TEXT_L2_QT1, Statement1 = Texts.BIO_TEXT_L2_Q1S1, Statement2 = Texts.BIO_TEXT_L2_Q1S2, Statement3 = Texts.BIO_TEXT_L2_Q1S3, Statement4 = Texts.BIO_TEXT_L2_Q1S4, CorrectStatement = Texts.BIO_TEXT_L2_Q1СS, CoorrectStatementNumber = Texts.BIO_L2_Q1_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 2, QuestionID = 2, QuestionText = Texts.BIO_TEXT_L2_QT2, Statement1 = Texts.BIO_TEXT_L2_Q2S1, Statement2 = Texts.BIO_TEXT_L2_Q2S2, Statement3 = Texts.BIO_TEXT_L2_Q2S3, Statement4 = Texts.BIO_TEXT_L2_Q2S4, CorrectStatement = Texts.BIO_TEXT_L2_Q2СS, CoorrectStatementNumber = Texts.BIO_L2_Q2_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 2, QuestionID = 3, QuestionText = Texts.BIO_TEXT_L2_QT3, Statement1 = Texts.BIO_TEXT_L2_Q3S1, Statement2 = Texts.BIO_TEXT_L2_Q3S2, Statement3 = Texts.BIO_TEXT_L2_Q3S3, Statement4 = Texts.BIO_TEXT_L2_Q3S4, CorrectStatement = Texts.BIO_TEXT_L2_Q3СS, CoorrectStatementNumber = Texts.BIO_L2_Q3_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 2, QuestionID = 4, QuestionText = Texts.BIO_TEXT_L2_QT4, Statement1 = Texts.BIO_TEXT_L2_Q4S1, Statement2 = Texts.BIO_TEXT_L2_Q4S2, Statement3 = Texts.BIO_TEXT_L2_Q4S3, Statement4 = Texts.BIO_TEXT_L2_Q4S4, CorrectStatement = Texts.BIO_TEXT_L2_Q4СS, CoorrectStatementNumber = Texts.BIO_L2_Q4_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 2, QuestionID = 5, QuestionText = Texts.BIO_TEXT_L2_QT5, Statement1 = Texts.BIO_TEXT_L2_Q5S1, Statement2 = Texts.BIO_TEXT_L2_Q5S2, Statement3 = Texts.BIO_TEXT_L2_Q5S3, Statement4 = Texts.BIO_TEXT_L2_Q5S4, CorrectStatement = Texts.BIO_TEXT_L2_Q5СS, CoorrectStatementNumber = Texts.BIO_L2_Q5_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 3, QuestionID = 1, QuestionText = Texts.BIO_TEXT_L3_QT1, Statement1 = Texts.BIO_TEXT_L3_Q1S1, Statement2 = Texts.BIO_TEXT_L3_Q1S2, Statement3 = Texts.BIO_TEXT_L3_Q1S3, Statement4 = Texts.BIO_TEXT_L3_Q1S4, CorrectStatement = Texts.BIO_TEXT_L3_Q1СS, CoorrectStatementNumber = Texts.BIO_L3_Q1_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 3, QuestionID = 2, QuestionText = Texts.BIO_TEXT_L3_QT2, Statement1 = Texts.BIO_TEXT_L3_Q2S1, Statement2 = Texts.BIO_TEXT_L3_Q2S2, Statement3 = Texts.BIO_TEXT_L3_Q2S3, Statement4 = Texts.BIO_TEXT_L3_Q2S4, CorrectStatement = Texts.BIO_TEXT_L3_Q2СS, CoorrectStatementNumber = Texts.BIO_L3_Q2_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 3, QuestionID = 3, QuestionText = Texts.BIO_TEXT_L3_QT3, Statement1 = Texts.BIO_TEXT_L3_Q3S1, Statement2 = Texts.BIO_TEXT_L3_Q3S2, Statement3 = Texts.BIO_TEXT_L3_Q3S3, Statement4 = Texts.BIO_TEXT_L3_Q3S4, CorrectStatement = Texts.BIO_TEXT_L3_Q3СS, CoorrectStatementNumber = Texts.BIO_L3_Q3_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 3, QuestionID = 4, QuestionText = Texts.BIO_TEXT_L3_QT4, Statement1 = Texts.BIO_TEXT_L3_Q4S1, Statement2 = Texts.BIO_TEXT_L3_Q4S2, Statement3 = Texts.BIO_TEXT_L3_Q4S3, Statement4 = Texts.BIO_TEXT_L3_Q4S4, CorrectStatement = Texts.BIO_TEXT_L3_Q4СS, CoorrectStatementNumber = Texts.BIO_L3_Q4_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 3, QuestionID = 5, QuestionText = Texts.BIO_TEXT_L3_QT5, Statement1 = Texts.BIO_TEXT_L3_Q5S1, Statement2 = Texts.BIO_TEXT_L3_Q5S2, Statement3 = Texts.BIO_TEXT_L3_Q5S3, Statement4 = Texts.BIO_TEXT_L3_Q5S4, CorrectStatement = Texts.BIO_TEXT_L3_Q5СS, CoorrectStatementNumber = Texts.BIO_L3_Q5_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 4, QuestionID = 1, QuestionText = Texts.BIO_TEXT_L4_QT1, Statement1 = Texts.BIO_TEXT_L4_Q1S1, Statement2 = Texts.BIO_TEXT_L4_Q1S2, Statement3 = Texts.BIO_TEXT_L4_Q1S3, Statement4 = Texts.BIO_TEXT_L4_Q1S4, CorrectStatement = Texts.BIO_TEXT_L4_Q1СS, CoorrectStatementNumber = Texts.BIO_L4_Q1_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 4, QuestionID = 2, QuestionText = Texts.BIO_TEXT_L4_QT2, Statement1 = Texts.BIO_TEXT_L4_Q2S1, Statement2 = Texts.BIO_TEXT_L4_Q2S2, Statement3 = Texts.BIO_TEXT_L4_Q2S3, Statement4 = Texts.BIO_TEXT_L4_Q2S4, CorrectStatement = Texts.BIO_TEXT_L4_Q2СS, CoorrectStatementNumber = Texts.BIO_L4_Q2_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 4, QuestionID = 3, QuestionText = Texts.BIO_TEXT_L4_QT3, Statement1 = Texts.BIO_TEXT_L4_Q3S1, Statement2 = Texts.BIO_TEXT_L4_Q3S2, Statement3 = Texts.BIO_TEXT_L4_Q3S3, Statement4 = Texts.BIO_TEXT_L4_Q3S4, CorrectStatement = Texts.BIO_TEXT_L4_Q3СS, CoorrectStatementNumber = Texts.BIO_L4_Q3_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 4, QuestionID = 4, QuestionText = Texts.BIO_TEXT_L4_QT4, Statement1 = Texts.BIO_TEXT_L4_Q4S1, Statement2 = Texts.BIO_TEXT_L4_Q4S2, Statement3 = Texts.BIO_TEXT_L4_Q4S3, Statement4 = Texts.BIO_TEXT_L4_Q4S4, CorrectStatement = Texts.BIO_TEXT_L4_Q4СS, CoorrectStatementNumber = Texts.BIO_L4_Q4_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 4, QuestionID = 5, QuestionText = Texts.BIO_TEXT_L4_QT5, Statement1 = Texts.BIO_TEXT_L4_Q5S1, Statement2 = Texts.BIO_TEXT_L4_Q5S2, Statement3 = Texts.BIO_TEXT_L4_Q5S3, Statement4 = Texts.BIO_TEXT_L4_Q5S4, CorrectStatement = Texts.BIO_TEXT_L4_Q5СS, CoorrectStatementNumber = Texts.BIO_L4_Q5_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 5, QuestionID = 1, QuestionText = Texts.BIO_TEXT_L5_QT1, Statement1 = Texts.BIO_TEXT_L5_Q1S1, Statement2 = Texts.BIO_TEXT_L5_Q1S2, Statement3 = Texts.BIO_TEXT_L5_Q1S3, Statement4 = Texts.BIO_TEXT_L5_Q1S4, CorrectStatement = Texts.BIO_TEXT_L5_Q1СS, CoorrectStatementNumber = Texts.BIO_L5_Q1_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 5, QuestionID = 2, QuestionText = Texts.BIO_TEXT_L5_QT2, Statement1 = Texts.BIO_TEXT_L5_Q2S1, Statement2 = Texts.BIO_TEXT_L5_Q2S2, Statement3 = Texts.BIO_TEXT_L5_Q2S3, Statement4 = Texts.BIO_TEXT_L5_Q2S4, CorrectStatement = Texts.BIO_TEXT_L5_Q2СS, CoorrectStatementNumber = Texts.BIO_L5_Q2_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 5, QuestionID = 3, QuestionText = Texts.BIO_TEXT_L5_QT3, Statement1 = Texts.BIO_TEXT_L5_Q3S1, Statement2 = Texts.BIO_TEXT_L5_Q3S2, Statement3 = Texts.BIO_TEXT_L5_Q3S3, Statement4 = Texts.BIO_TEXT_L5_Q3S4, CorrectStatement = Texts.BIO_TEXT_L5_Q3СS, CoorrectStatementNumber = Texts.BIO_L5_Q3_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 5, QuestionID = 4, QuestionText = Texts.BIO_TEXT_L5_QT4, Statement1 = Texts.BIO_TEXT_L5_Q4S1, Statement2 = Texts.BIO_TEXT_L5_Q4S2, Statement3 = Texts.BIO_TEXT_L5_Q4S3, Statement4 = Texts.BIO_TEXT_L5_Q4S4, CorrectStatement = Texts.BIO_TEXT_L5_Q4СS, CoorrectStatementNumber = Texts.BIO_L5_Q4_CSN });
            Questions.Add(new Question { CourseID = 1, LessonID = 5, QuestionID = 5, QuestionText = Texts.BIO_TEXT_L5_QT5, Statement1 = Texts.BIO_TEXT_L5_Q5S1, Statement2 = Texts.BIO_TEXT_L5_Q5S2, Statement3 = Texts.BIO_TEXT_L5_Q5S3, Statement4 = Texts.BIO_TEXT_L5_Q5S4, CorrectStatement = Texts.BIO_TEXT_L5_Q5СS, CoorrectStatementNumber = Texts.BIO_L5_Q5_CSN });
        }

        public List<Course> GetCourses()
        {
            List<Course> list = new List<Course>();
            list.Add(Bio);
            return list;
        }
        public List<Lesson> GetLessonsByCourse(int courseID)
        {
            return Lessons.Where(x=>x.CourseID == courseID).ToList();
        }
        public List<Question> GetTestByCourseAndLesson(int courseID, int lessonID)
        {
            return Questions.Where(x=>x.CourseID==courseID).Where(x=>x.LessonID==lessonID).ToList();
        }
    }
}
