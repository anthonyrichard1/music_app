namespace MusicApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = (App.Current as App).Manager;
	}
}

