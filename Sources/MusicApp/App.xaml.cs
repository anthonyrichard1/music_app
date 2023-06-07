using App.Model;
using App.Stub;

namespace MusicApp;

public partial class App : Application
{
	public Manager Manager { get; set; }

	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
		Manager = new(new Stub());
    }
}
