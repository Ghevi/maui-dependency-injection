using MauiApp2.Services;
using System.Collections.ObjectModel;

namespace MauiApp2;

public partial class MainPage : ContentPage
{
	private readonly MyService _myService;

	public MainPage(MyService myService, IServiceProvider serviceProvider, IServiceScopeFactory scopeFactory)
	{
		_myService = myService;
		var sameService = serviceProvider.GetRequiredService<MyService>();

		using(var scope = scopeFactory.CreateScope())
		{
			var sameServiceAgain = scope.ServiceProvider.GetRequiredService<MyService>();
		}
		
		BindingContext = this;
		InitializeComponent();
	}

	private async void OnGetNamesClicked(object sender, EventArgs e)
	{
		Names.Clear();
		var names = await _myService.GetNames();
		foreach (var name in names)
		{
			Names.Add(name);
			await Task.Delay(1000);
		}
	}

	public ObservableCollection<String> Names { get; } = new();
}

