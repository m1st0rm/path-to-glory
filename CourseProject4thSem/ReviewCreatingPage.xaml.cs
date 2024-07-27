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
            MarkLabel.Text = "������� ������: 1 ����";
        }
        else if (newStep == 2) 
        {
            MarkLabel.Text = "������� ������: 2 �����";
        }
        else if (newStep == 3)
        {
            MarkLabel.Text = "������� ������: 3 �����";
        }
        else if (newStep == 4)
        {
            MarkLabel.Text = "������� ������: 4 �����";
        }
        else if (newStep == 5)
        {
            MarkLabel.Text = "������� ������: 5 ������";
        }
    }

    private void SubmitButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TextEditor.Text))
        {
            DisplayAlert("������ ����������� ������", "��������� ��������� ���� ������", "OK");
            return;
        }
        else
        {
            int Mark = (int)Math.Round(MarkSlider.Value);
            string Text = TextEditor.Text;
            bool result = dBService.AddReview(CurrentUser.UserID, CurrentUser.UserName, CurrentUser.UserSurname, Mark, Text);
            if (!result)
            {
                DisplayAlert("������ ����������� ������", "�������������� ������", "OK");
            }
            else
            {
                DisplayAlert("����� ������� ���������", "����� ����� �������� � ��������� ����� ���������", "OK");
            }
        }
    }

    private void ExitButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}