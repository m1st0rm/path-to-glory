using CourseProject4thSem.Entities;
using CourseProject4thSem.Services;
namespace CourseProject4thSem;

public partial class StatisticsPage : ContentPage
{
	User CurrentUser { get; set; }
	DBService dBService { get; set; }
	public StatisticsPage(User curr_user, DBService _dbService)
	{
		InitializeComponent();
		CurrentUser = curr_user;
		dBService = _dbService;
		LoadStats();
	}
	private void LoadStats()
	{
		int testsPassed = dBService.GetUserTestPassed(CurrentUser.UserID);
        int correctAnswers = dBService.GetUserCorrectAnswers(CurrentUser.UserID);
        int incorrectAnswers = dBService.GetUserIncorrectAnswers(CurrentUser.UserID);
		int userWarnings = dBService.GetUserWarnings(CurrentUser.UserID);
        if (testsPassed == 0)
		{
            CorrectAnswersPecentage_Label.Text ="Процент правильных ответов на вопросы: "+"0%";
		}
		else
		{
			double CorrectAnswersPercentage = ((double)correctAnswers / (double)(correctAnswers + incorrectAnswers))*100;
			CorrectAnswersPecentage_Label.Text = "Процент правильных ответов на вопросы: " + CorrectAnswersPercentage.ToString("F2") + "%";
		}
        TestsPassed_Label.Text ="Всего пройдено тестов: " + testsPassed.ToString();
        CorrectAnswers_Label.Text ="Всего правильных ответов: " + correctAnswers.ToString();
        IncorrectAnswers_Label.Text ="Всего неправильных ответов: " + incorrectAnswers.ToString();
		Warnings_Label.Text ="Текущее количество предупреждений учётной записи: " + userWarnings.ToString();
    }
    private void ExitButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}