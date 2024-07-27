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
            CorrectAnswersPecentage_Label.Text ="������� ���������� ������� �� �������: "+"0%";
		}
		else
		{
			double CorrectAnswersPercentage = ((double)correctAnswers / (double)(correctAnswers + incorrectAnswers))*100;
			CorrectAnswersPecentage_Label.Text = "������� ���������� ������� �� �������: " + CorrectAnswersPercentage.ToString("F2") + "%";
		}
        TestsPassed_Label.Text ="����� �������� ������: " + testsPassed.ToString();
        CorrectAnswers_Label.Text ="����� ���������� �������: " + correctAnswers.ToString();
        IncorrectAnswers_Label.Text ="����� ������������ �������: " + incorrectAnswers.ToString();
		Warnings_Label.Text ="������� ���������� �������������� ������� ������: " + userWarnings.ToString();
    }
    private void ExitButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}