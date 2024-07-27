using CourseProject4thSem.Services;
using CourseProject4thSem.Entities;

namespace CourseProject4thSem;

public partial class ReviewCreatingPage : ContentPage
{
	public DBService dBService {  get; set; }
    public User CurrentUser { get; set; }
    public ReviewCreatingPage(User _user, DBService _dbService)
	{
        InitializeComponent();
        this.dBService = _dbService;
		this.CurrentUser = _user;
	}

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        var newStep = Math.Round(e.NewValue);
        ((Slider)sender).Value = newStep;
        if (newStep == 1)
        {
            MarkLabel.Text = "Текущая оценка: 1 Балл";
        }
        else if (newStep == 2) 
        {
            MarkLabel.Text = "Текущая оценка: 2 Балла";
        }
        else if (newStep == 3)
        {
            MarkLabel.Text = "Текущая оценка: 3 Балла";
        }
        else if (newStep == 4)
        {
            MarkLabel.Text = "Текущая оценка: 4 Балла";
        }
        else if (newStep == 5)
        {
            MarkLabel.Text = "Текущая оценка: 5 Баллов";
        }
    }

    private void SubmitButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TextEditor.Text))
        {
            DisplayAlert("Ошибка отправления отзыва", "Заполните текстовое поле отзыва", "OK");
            return;
        }
        else
        {
            int Mark = (int)Math.Round(MarkSlider.Value);
            string Text = TextEditor.Text;
            bool result = dBService.AddReview(CurrentUser.UserID, CurrentUser.UserName, CurrentUser.UserSurname, Mark, Text);
            if (!result)
            {
                DisplayAlert("Ошибка отправления отзыва", "Непредвиденная ошибка", "OK");
            }
            else
            {
                DisplayAlert("Отзыв успешно отправлен", "Отзыв будет доступен к прочтению после модерации", "OK");
            }
        }
    }

    private void ExitButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}