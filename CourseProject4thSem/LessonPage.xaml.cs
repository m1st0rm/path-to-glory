using CourseProject4thSem.Services;
using CourseProject4thSem.Entities;

namespace CourseProject4thSem;

public partial class LessonPage : ContentPage
{

	public Lesson CurrentLesson;
	public LessonPage(Lesson lesson)
	{
		InitializeComponent();
		CurrentLesson = lesson;
		LessonArticleLabel.Text = CurrentLesson.LessonArticle.Text;
		LessonImage.Source = CurrentLesson.LessonArticle.ImagePath;
	}

    private void ExitButton_Clicked(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }
}