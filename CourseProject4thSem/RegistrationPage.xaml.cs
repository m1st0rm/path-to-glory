using CourseProject4thSem.Services;
using CourseProject4thSem.Entities;

namespace CourseProject4thSem;

public partial class RegistrationPage : ContentPage
{
    DBService dbService;
    public RegistrationPage(DBService _dbService)
	{
		InitializeComponent();
        this.dbService = _dbService;
        NameEntry.Text = string.Empty;
        SurnameEntry.Text = string.Empty;
        PatronymicEntry.Text = string.Empty;
        LoginEntry.Text = string.Empty;
        PasswordEntry.Text = string.Empty;
        PasswordConfirmEntry.Text = string.Empty;
    }

    private void SingInButton_Clicked(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }

    private void RegistryButton_Clicked(object sender, EventArgs e)
    {
        if(string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(SurnameEntry.Text) || string.IsNullOrWhiteSpace(PatronymicEntry.Text) || string.IsNullOrWhiteSpace(LoginEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text) || string.IsNullOrWhiteSpace(PasswordConfirmEntry.Text))
        {
            DisplayAlert("Ошибка регистрации", "Заполните все поля", "OK");
        }
        else if(PasswordEntry.Text != PasswordConfirmEntry.Text)
        {
            DisplayAlert("Ошибка регистрации", "Пароли различаются", "OK");
            PasswordEntry.Text = string.Empty;
            PasswordConfirmEntry.Text = string.Empty;
        }
        else if(!dbService.RegisterUser(NameEntry.Text, SurnameEntry.Text, PatronymicEntry.Text, LoginEntry.Text, PasswordEntry.Text)) 
        {
            DisplayAlert("Ошибка регистрации", "Учётная запись с таким логином уже существует", "OK");
            LoginEntry.Text = string.Empty;
            PasswordEntry.Text = string.Empty;
            PasswordConfirmEntry.Text = string.Empty;
        }
        else
        {
            DisplayAlert("Уведомление о регистрации", "Регистрация выполнена успешно\nВы будете перенаправлены на окно входа", "OK");
            Navigation.PopModalAsync();
        }
    }
}