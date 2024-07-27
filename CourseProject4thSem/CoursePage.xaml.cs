using CourseProject4thSem.Services;
using CourseProject4thSem.Entities;

namespace CourseProject4thSem;

public partial class CoursePage : ContentPage
{
	public User CurrentUser { get; set; }
	public DBService dBService { get; set; }
	public Course CurrentCourse { get; set; }
	public List<Question> CurrentTest { get; set; }
	public List<Lesson> Lessons { get; set; }
	public Lesson ChosenLesson { get; set; }
	Initializer initializer { get; set; }

	public CoursePage(User user, Course course, DBService _dBService)
	{
        InitializeComponent();
		initializer = new Initializer();
		this.CurrentUser = user;
		this.CurrentCourse = course;
		CourseNameLabel.Text = CurrentCourse.CourseName;
		CourseDescriptionLabel.Text = CurrentCourse.CourseDescription;
		Lessons = initializer.GetLessonsByCourse(CurrentCourse.CourseID);
		EnterLessonButton.IsEnabled = false;
		EnterTestButton.IsEnabled = false;
		BindingContext = this;
		dBService = _dBService;
	}

    private void LessonPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (LessonPicker.SelectedIndex != -1)
        {
            ChosenLesson = LessonPicker.SelectedItem as Lesson;
            EnterLessonButton.IsEnabled = true;
			EnterTestButton.IsEnabled = true;
			CurrentTest = initializer.GetTestByCourseAndLesson(CurrentCourse.CourseID, ChosenLesson.LessonID);
        }
    }

    private void EnterLessonButton_Clicked(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new LessonPage(ChosenLesson));
    }

    private void EnterTestButton_Clicked(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new TestPage(CurrentTest, CurrentUser, dBService));
    }

    private void ExitButton_Clicked(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }
}