using CourseProject4thSem.Services;
using CourseProject4thSem.Entities;

namespace CourseProject4thSem;

public partial class LoginPage : ContentPage
{
    DBService dbService;
    public LoginPage()
	{
		InitializeComponent();
        dbService = new DBService();
        LoginEntry.Text = string.Empty;
        PasswordEntry.Text = string.Empty;
    }

    private void LoginButton_Clicked(object sender, EventArgs e)
    {
        if(string.IsNullOrWhiteSpace(LoginEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            DisplayAlert("Ошибка авторизации", "Заполните все поля", "OK");
        }
        else if(!dbService.LoginUserCheck(LoginEntry.Text, PasswordEntry.Text))
        {
            LoginEntry.Text = String.Empty;
            PasswordEntry.Text = String.Empty;
            DisplayAlert("Ошибка авторизации", "Неверный логин или пароль", "OK");
            return;
        }
        else if(dbService.LoginUser(LoginEntry.Text, PasswordEntry.Text).UserWarnings == 3)
        {
            LoginEntry.Text = String.Empty;
            PasswordEntry.Text = String.Empty;
            DisplayAlert("Ошибка авторизации", "Данная учётная запись заблокирована за нарушение правил", "OK");
            return;
        }
        else
        {
            DisplayAlert("Уведомление о входе", "Вход выполнен успешно", "OK");
            Navigation.PushModalAsync(new MainPage(dbService.LoginUser(LoginEntry.Text, PasswordEntry.Text), dbService));
            return;
        }
    }

    private void SignUpButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new RegistrationPage(dbService));
    }

    private void ReviewsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new ReviewBrowserPage(dbService));
    }

    private void AdminButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(LoginEntry.Text) || string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            DisplayAlert("Ошибка авторизации", "Заполните все поля", "OK");
        }
        else if (LoginEntry.Text != "admin")
        {
            DisplayAlert("Ошибка авторизации", "Неверные данные учётной записи администратора", "OK");
            LoginEntry.Text = String.Empty;
            PasswordEntry.Text = String.Empty;
        }
        else if (!dbService.LoginUserCheck(LoginEntry.Text, PasswordEntry.Text))
        {
            LoginEntry.Text = String.Empty;
            PasswordEntry.Text = String.Empty;
            DisplayAlert("Ошибка авторизации", "Неверные данные учётной записи администратора", "OK");
            return;
        }
        else
        {
            DisplayAlert("Уведомление о входе", "Вход в учётную запись администратора выполнен успешно", "OK");
            Navigation.PushModalAsync(new AdminPage(dbService));
            return;
        }
    }
}

