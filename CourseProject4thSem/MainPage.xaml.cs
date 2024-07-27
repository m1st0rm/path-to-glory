using CourseProject4thSem.Services;
using CourseProject4thSem.Entities;

namespace CourseProject4thSem;

public partial class MainPage : ContentPage
{
	public User CurrentUser { get; set; }
    public DBService dBService { get; set; }
    public Initializer initializer;
	public List<Course> Courses { get; set; }
	public Course ChosenCourse { get; set; }
	public MainPage(User _user, DBService _dbService)
	{
        InitializeComponent();
		this.CurrentUser = _user;
        this.dBService = _dbService;
		this.initializer = new Initializer();
		Courses = initializer.GetCourses();
		HelloLabel.Text += CurrentUser.UserName + ' ' + CurrentUser.UserPatronymic;
		EnterCourseButton.IsEnabled = false;
		BindingContext = this;
    }

    private void CoursePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
		if (CoursePicker.SelectedIndex != -1)
		{
			ChosenCourse = CoursePicker.SelectedItem as Course;
			CourseInfoLabel.Text = ChosenCourse.CourseDescription;
            EnterCourseButton.IsEnabled = true;
        }
    }

    private void ExitButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
    private void EnterCourseButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new CoursePage(CurrentUser,ChosenCourse, dBService));
    }

    private void CreateReviewButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new ReviewCreatingPage(CurrentUser, dBService));
    }

    private void StatsButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new StatisticsPage(CurrentUser, dBService));
    }
}