using CourseProject4thSem.Services;
using CourseProject4thSem.Entities;
using System.Collections.ObjectModel;

namespace CourseProject4thSem;

public partial class ReviewBrowserPage : ContentPage
{
    DBService dbService;
    public ObservableCollection<Review> Reviews { get; set; }
    public ReviewBrowserPage(DBService _dbService)
	{
		InitializeComponent();
        dbService = _dbService;
        if (dbService.GetReviewsConfirmed() == null)
        {
            Reviews = new ObservableCollection<Review>();
        }
        else
        {
            Reviews = new ObservableCollection<Review>(dbService.GetReviewsConfirmed());
        }
        ReviewsCollectionView.ItemsSource = Reviews;
    }

    private void ExitButton_Clicked(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }
}