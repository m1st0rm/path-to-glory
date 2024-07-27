using CourseProject4thSem.Entities;
using CourseProject4thSem.Services;

namespace CourseProject4thSem;

public partial class TestPage : ContentPage
{

	public List<Question> CurrentTest { get; set; }
	public int CurrentCorrectAnswer { get; set; }
	public int CorrectAnswers = 0;
	public int IncorrectAnswers = 0;
	public int CurrentQuestionIndex = 0;
    public User CurrentUser { get; set; }
    public DBService dBService { get; set; }
    public TestPage(List<Question> Test,User curr_user,DBService _dBService)
    {
        InitializeComponent();
        CurrentTest = Test;
        QuestionLabel.Text = CurrentTest[CurrentQuestionIndex].QuestionText;
        S1Label.Text += CurrentTest[CurrentQuestionIndex].Statement1;
        S2Label.Text += CurrentTest[CurrentQuestionIndex].Statement2;
        S3Label.Text += CurrentTest[CurrentQuestionIndex].Statement3;
        S4Label.Text += CurrentTest[CurrentQuestionIndex].Statement4;
        CurrentCorrectAnswer = CurrentTest[CurrentQuestionIndex].CoorrectStatementNumber;
        AnswerEntry.Text = string.Empty;
        CurrentUser = curr_user;
        dBService = _dBService;
    }

    private void SubmitButton_Clicked(object sender, EventArgs e)
    {
		if (CurrentQuestionIndex < CurrentTest.Count-1)
		{
			if (string.IsNullOrWhiteSpace(AnswerEntry.Text))
			{
				DisplayAlert("Ошибка", "Заполните поле ответа", "OK");
			}
			else if (Convert.ToInt32((AnswerEntry.Text)) == CurrentCorrectAnswer)
			{
				DisplayAlert("Верно!", "Правильный ответ : \n" + CurrentTest[CurrentQuestionIndex].CorrectStatement, "OK");
				CurrentQuestionIndex++;
				CorrectAnswers++;
                QuestionLabel.Text = CurrentTest[CurrentQuestionIndex].QuestionText;
                S1Label.Text = "1. " + CurrentTest[CurrentQuestionIndex].Statement1;
                S2Label.Text = "2. " + CurrentTest[CurrentQuestionIndex].Statement2;
                S3Label.Text  ="3. " + CurrentTest[CurrentQuestionIndex].Statement3;
                S4Label.Text = "4. " + CurrentTest[CurrentQuestionIndex].Statement4;
                CurrentCorrectAnswer = CurrentTest[CurrentQuestionIndex].CoorrectStatementNumber;
                AnswerEntry.Text = string.Empty;
				return;
            }
			else
			{
                DisplayAlert("Неверно!", "Правильный ответ : \n" + CurrentTest[CurrentQuestionIndex].CorrectStatement, "OK");
                CurrentQuestionIndex++;
                IncorrectAnswers++;
                QuestionLabel.Text = CurrentTest[CurrentQuestionIndex].QuestionText;
                S1Label.Text = "1. " + CurrentTest[CurrentQuestionIndex].Statement1;
                S2Label.Text = "2. " + CurrentTest[CurrentQuestionIndex].Statement2;
                S3Label.Text = "3. " + CurrentTest[CurrentQuestionIndex].Statement3;
                S4Label.Text = "4. " + CurrentTest[CurrentQuestionIndex].Statement4;
                CurrentCorrectAnswer = CurrentTest[CurrentQuestionIndex].CoorrectStatementNumber;
                AnswerEntry.Text = string.Empty;
                return;
            }
		}
		else
		{
            if (string.IsNullOrWhiteSpace(AnswerEntry.Text))
            {
                DisplayAlert("Ошибка", "Заполните поле ответа", "OK");
            }
            else if (Convert.ToInt32((AnswerEntry.Text)) == CurrentCorrectAnswer)
            {
                CorrectAnswers++;
                DisplayAlert("Верно!", "Правильный ответ : \n" + CurrentTest[CurrentQuestionIndex].CorrectStatement + "\nВаша оценка : " + CorrectAnswers.ToString() + '/' + (CorrectAnswers+IncorrectAnswers).ToString(), "OK");
            }
            else
            {
                IncorrectAnswers++;
                DisplayAlert("Неверно!", "Правильный ответ : \n" + CurrentTest[CurrentQuestionIndex].CorrectStatement + "\nВаша оценка : " + CorrectAnswers.ToString() + '/' + (CorrectAnswers + IncorrectAnswers).ToString(), "OK");
                
            }
            dBService.UpdateUserStats(CurrentUser.UserID, 1, CorrectAnswers, IncorrectAnswers);
            Navigation.PopModalAsync();
        }

    }

    private void AnswerEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.NewTextValue))
        {
            if (!uint.TryParse(e.NewTextValue, out _))
            {
                ((Entry)sender).Text = e.OldTextValue;
            }
            else if(uint.TryParse(e.NewTextValue,out _) && (Convert.ToUInt32(e.NewTextValue) < 1 || Convert.ToUInt32(e.NewTextValue) > 4))
            {
                ((Entry)sender).Text = e.OldTextValue;
            }
        }
    }
}