using CourseProject4thSem.Services;
using CourseProject4thSem.Entities;
using System.Collections.ObjectModel;

namespace CourseProject4thSem;

public partial class AdminPage : ContentPage
{
    DBService dbService;
    public ObservableCollection<Review> UnconfirmedReviews { get; set; }
    public ObservableCollection<Review> ConfirmedReviews { get; set; }
    public ObservableCollection<User> UnbannedUsers { get; set; }
    public ObservableCollection<User> BannedUsers { get; set; }
    public AdminPage(DBService _dbService)
    {
        InitializeComponent();
        dbService = _dbService;
        if (dbService.GetReviewsUnconfirmed() == null)
        {
            UnconfirmedReviews = new ObservableCollection<Review>();
        }
        else
        {
            UnconfirmedReviews = new ObservableCollection<Review>(dbService.GetReviewsUnconfirmed());
        }
        if (dbService.GetReviewsConfirmed() == null) 
        {
            ConfirmedReviews = new ObservableCollection<Review>();
        }
        else
        {
            ConfirmedReviews = new ObservableCollection<Review>(dbService.GetReviewsConfirmed());
        }
        if (dbService.GetUsersUnbanned() == null) 
        {
            UnbannedUsers = new ObservableCollection<User>();
        }
        else
        {
            UnbannedUsers = new ObservableCollection<User>(dbService.GetUsersUnbanned());
        }
        if(dbService.GetUsersBanned() == null)
        {
            BannedUsers = new ObservableCollection<User>();
        }
        else
        {
            BannedUsers = new ObservableCollection<User>(dbService.GetUsersBanned());
        }
        UnconfirmedReviewsCollectionView.ItemsSource = UnconfirmedReviews;
        ConfirmedReviewsCollectionView.ItemsSource = ConfirmedReviews;
        UnbannedUsersCollectionView.ItemsSource = UnbannedUsers;
        BannedUsersCollectionView.ItemsSource = BannedUsers;
    }
    private void ExitButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
    private void ConfirmButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(UnconfirmedEntry.Text))
        {
            DisplayAlert("Ошибка публикации отзыва", "Введите ID отзыва", "OK");
            return;
        }
        List<Review> UnconfirmedReviewsList = dbService.GetReviewsUnconfirmed();
        if (UnconfirmedReviewsList == null)
        {
            DisplayAlert("Ошибка публикации отзыва", "Непроверенного отзыва с указанным ID не существует", "OK");
            return;
        }
        bool IsInList = UnconfirmedReviewsList.Any(r => r.ReviewID == Convert.ToInt32(UnconfirmedEntry.Text));
        if (!IsInList)
        {
            DisplayAlert("Ошибка публикации отзыва", "Непроверенного отзыва с указанным ID не существует", "OK");
        }
        else
        {
            bool result = dbService.ConfirmReview(Convert.ToInt32(UnconfirmedEntry.Text));
            if (!result)
            {
                DisplayAlert("Ошибка публикации отзыва", "Непредвиденная ошибка", "OK");
            }
            else
            {
                Review ReviewToConfirm = UnconfirmedReviews.FirstOrDefault(r => r.ReviewID == Convert.ToInt32(UnconfirmedEntry.Text));
                UnconfirmedReviews.Remove(ReviewToConfirm);
                ReviewToConfirm.ReviewStatus = 1;
                bool inserted = false;
                for (int i = 0; i < ConfirmedReviews.Count; i++)
                {
                    if (ConfirmedReviews[i].ReviewID > ReviewToConfirm.ReviewID)
                    {
                        ConfirmedReviews.Insert(i, ReviewToConfirm);
                        inserted = true;
                        break;
                    }
                }
                if (!inserted)
                {
                    ConfirmedReviews.Add(ReviewToConfirm);
                }
                DisplayAlert("Успех", "Указанный отзыв успешно опубликован", "OK");
            }
        }
    }

    private void DeleteUnconfirmedButton_Clicked(object sender, EventArgs e)
    {
        if(string.IsNullOrWhiteSpace(UnconfirmedEntry.Text))
        {
            DisplayAlert("Ошибка удаления отзыва", "Введите ID отзыва", "OK");
            return;
        }
        List<Review> UnconfirmedReviewsList = dbService.GetReviewsUnconfirmed();
        if (UnconfirmedReviewsList == null)
        {
            DisplayAlert("Ошибка удаления отзыва", "Непроверенного отзыва с указанным ID не существует", "OK");
            return;
        }
        bool IsInList = UnconfirmedReviewsList.Any(r => r.ReviewID == Convert.ToInt32(UnconfirmedEntry.Text));
        if (!IsInList)
        {
            DisplayAlert("Ошибка удаления отзыва", "Непроверенного отзыва с указанным ID не существует", "OK");
        }
        else
        {
            bool result = dbService.RemoveReview(Convert.ToInt32(UnconfirmedEntry.Text));
            if (!result)
            {
                DisplayAlert("Ошибка удаления отзыва", "Непредвиденная ошибка", "OK");
            }
            else
            {
                Review ReviewToDelete = UnconfirmedReviews.FirstOrDefault(r => r.ReviewID == Convert.ToInt32(UnconfirmedEntry.Text));
                UnconfirmedReviews.Remove(ReviewToDelete);
                DisplayAlert("Успех", "Указанный отзыв успешно удалён", "OK");
                
            }
        }
    }

    private void DeleteConfirmedButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(ConfirmedEntry.Text))
        {
            DisplayAlert("Ошибка удаления отзыва", "Введите ID отзыва", "OK");
            return;
        }
        List<Review> СonfirmedReviewsList = dbService.GetReviewsConfirmed();
        if (СonfirmedReviewsList == null)
        {
            DisplayAlert("Ошибка удаления отзыва", "Проверенного отзыва с указанным ID не существует", "OK");
            return;
        }
        bool IsInList = СonfirmedReviewsList.Any(r => r.ReviewID == Convert.ToInt32(ConfirmedEntry.Text));
        if (!IsInList)
        {
            DisplayAlert("Ошибка удаления отзыва", "Проверенного отзыва с указанным ID не существует", "OK");
        }
        else
        {
            bool result = dbService.RemoveReview(Convert.ToInt32(ConfirmedEntry.Text));
            if (!result)
            {
                DisplayAlert("Ошибка удаления отзыва", "Непредвиденная ошибка", "OK");
            }
            else
            {
                Review ReviewToDelete = ConfirmedReviews.FirstOrDefault(r => r.ReviewID == Convert.ToInt32(ConfirmedEntry.Text));
                ConfirmedReviews.Remove(ReviewToDelete);
                DisplayAlert("Успех", "Указанный отзыв успешно удалён", "OK");
            }
        }
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.NewTextValue))
        {
            if (!uint.TryParse(e.NewTextValue, out _))
            {
                ((Entry)sender).Text = e.OldTextValue;
            }
        }
    }

    private void WarnButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(UnbannedEntry.Text)) 
        {
            DisplayAlert("Ошибка выдачи предупреждения", "Введите ID пользователя", "OK");
            return;
        }
        List<User> UnbannedUsersList = dbService.GetUsersUnbanned();
        if (UnbannedUsersList == null)
        {
            DisplayAlert("Ошибка выдачи предупреждения", "Незаблокированного пользователя с таким ID не существует", "OK");
            return;
        }
        bool IsInList = UnbannedUsersList.Any(u=>u.UserID==Convert.ToInt32(UnbannedEntry.Text));
        if (!IsInList)
        {
            DisplayAlert("Ошибка выдачи предупреждения", "Незаблокированного пользователя с таким ID не существует", "OK");
            return;
        }
        else
        {
            int result = dbService.GiveWarningToUser(Convert.ToInt32(UnbannedEntry.Text));
            if (result == 1 || result == 2)
            {
                DisplayAlert("Ошибка выдачи предупреждения", "Непредвиденная ошибка", "OK");
                return;
            }
            else
            {
                User UserToChange = UnbannedUsers.FirstOrDefault(u => u.UserID == Convert.ToInt32(UnbannedEntry.Text));
                int WarningCounter = UserToChange.UserWarnings;
                if (WarningCounter == 2)
                {
                    UnbannedUsers.Remove(UserToChange);
                    UserToChange.UserWarnings = UserToChange.UserWarnings + 1;
                    bool inserted = false;
                    for (int i = 0; i < BannedUsers.Count; i++)
                    {
                        if (BannedUsers[i].UserID > UserToChange.UserID)
                        {
                            BannedUsers.Insert(i, UserToChange);
                            inserted = true;
                            break;
                        }
                    }
                    if (!inserted) 
                    {
                        BannedUsers.Add(UserToChange);
                    }
                    DisplayAlert("Успех", "Предупреждение успешно выдано указаному пользователю", "OK");
                }
                else
                {
                    UnbannedUsers.Remove(UserToChange);
                    UserToChange.UserWarnings = UserToChange.UserWarnings + 1;
                    bool inserted = false;
                    for (int i = 0; i < UnbannedUsers.Count; i++) 
                    {
                        if (UnbannedUsers[i].UserID > UserToChange.UserID)
                        {
                            UnbannedUsers.Insert(i, UserToChange);
                            inserted = true;
                            break;
                        }
                    }
                    if (!inserted)
                    {
                        UnbannedUsers.Add(UserToChange);
                    }
                    DisplayAlert("Успех", "Предупреждение успешно выдано указаному пользователю", "OK");
                }
            }
        }
    }
    private void UnwarnButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(UnbannedEntry.Text))
        {
            DisplayAlert("Ошибка снятия предупреждения", "Введите ID пользователя", "OK");
            return;
        }
        List<User> UnbannedUsersList = dbService.GetUsersUnbanned();
        if (UnbannedUsersList == null)
        {
            DisplayAlert("Ошибка снятия предупреждения", "Незаблокированного пользователя с таким ID не существует", "OK");
            return;
        }
        bool IsInList = UnbannedUsersList.Any(u => u.UserID == Convert.ToInt32(UnbannedEntry.Text));
        if (!IsInList)
        {
            DisplayAlert("Ошибка снятия предупреждения", "Незаблокированного пользователя с таким ID не существует", "OK");
            return;
        }
        else
        {
            int result = dbService.TakeOffWarningFromUser(Convert.ToInt32(UnbannedEntry.Text));
            if (result == 1)
            {
                DisplayAlert("Ошибка снятия предупреждения", "Непредвиденная ошибка", "OK");
                return;
            }
            else if (result == 2)
            {
                DisplayAlert("Ошибка снятия предупреждения", "Указанный пользователь не имеет предупреждений", "OK");
                return;
            }
            else
            {
                User UserToChange = UnbannedUsers.FirstOrDefault(u => u.UserID == Convert.ToInt32(UnbannedEntry.Text));
                UnbannedUsers.Remove(UserToChange);
                UserToChange.UserWarnings = UserToChange.UserWarnings - 1;
                bool inserted = false;
                for (int i = 0; i < UnbannedUsers.Count; i++)
                {
                    if (UnbannedUsers[i].UserID > UserToChange.UserID)
                    {
                        UnbannedUsers.Insert(i, UserToChange);
                        inserted = true;
                        break;
                    }
                }
                if (!inserted)
                {
                    UnbannedUsers.Add(UserToChange);
                }
                DisplayAlert("Успех", "Предупреждение успешно снято с указанного пользователя", "OK");
            }
        }
    }
    private void BanButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(UnbannedEntry.Text))
        {
            DisplayAlert("Ошибка выдачи блокировки", "Введите ID пользователя", "OK");
            return;
        }
        List<User> UnbannedUsersList = dbService.GetUsersUnbanned();
        if (UnbannedUsersList == null)
        {
            DisplayAlert("Ошибка выдачи блокировки", "Незаблокированного пользователя с таким ID не существует", "OK");
            return;
        }
        bool IsInList = UnbannedUsersList.Any(u => u.UserID == Convert.ToInt32(UnbannedEntry.Text));
        if (!IsInList)
        {
            DisplayAlert("Ошибка выдачи блокировки", "Незаблокированного пользователя с таким ID не существует", "OK");
            return;
        }
        else
        {
            int result = dbService.GiveBanToUser(Convert.ToInt32(UnbannedEntry.Text));
            if (result == 1 || result == 2)
            {
                DisplayAlert("Ошибка выдачи блокировки", "Непредвиденная ошибка", "OK");
                return;
            }
            else
            {
                User UserToChange = UnbannedUsers.FirstOrDefault(u => u.UserID == Convert.ToInt32(UnbannedEntry.Text));
                UnbannedUsers.Remove(UserToChange);
                UserToChange.UserWarnings = UserToChange.UserWarnings = 3;
                bool inserted = false;
                for (int i = 0; i < BannedUsers.Count; i++)
                {
                    if (BannedUsers[i].UserID > UserToChange.UserID)
                    {
                        BannedUsers.Insert(i, UserToChange);
                        inserted = true;
                        break;
                    }
                }
                if (!inserted)
                {
                    BannedUsers.Add(UserToChange);
                }
                DisplayAlert("Успех", "Блокировка успешна выдана указанному пользователю", "OK");
            }
        }
    }
    private void UnbanButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(BannedEntry.Text))
        {
            DisplayAlert("Ошибка снятия блокировки", "Введите ID пользователя", "OK");
            return;
        }
        List<User> BannedUsersList = dbService.GetUsersBanned();
        if (BannedUsersList == null)
        {
            DisplayAlert("Ошибка снятия блокировки", "Заблокированного пользователя с таким ID не существует", "OK");
            return;
        }
        bool IsInList = BannedUsersList.Any(u => u.UserID == Convert.ToInt32(BannedEntry.Text));
        if (!IsInList)
        {
            DisplayAlert("Ошибка снятия блокировки", "Заблокированного пользователя с таким ID не существует", "OK");
            return;
        }
        else
        {
            int result = dbService.TakeOffBanFromUser(Convert.ToInt32(BannedEntry.Text));
            if (result == 1 || result == 2)
            {
                DisplayAlert("Ошибка снятия блокировки", "Непредвиденная ошибка", "OK");
                return;
            }
            else
            {
                User UserToChange = BannedUsers.FirstOrDefault(u => u.UserID == Convert.ToInt32(BannedEntry.Text));
                BannedUsers.Remove(UserToChange);
                UserToChange.UserWarnings = UserToChange.UserWarnings = 0;
                bool inserted = false;
                for (int i = 0; i < UnbannedUsers.Count; i++)
                {
                    if (UnbannedUsers[i].UserID > UserToChange.UserID)
                    {
                        UnbannedUsers.Insert(i, UserToChange);
                        inserted = true;
                        break;
                    }
                }
                if (!inserted)
                {
                    UnbannedUsers.Add(UserToChange);
                }
                DisplayAlert("Успех", "Блокировка успешна снята с указанного пользователя", "OK");
            }
        }
    }
}