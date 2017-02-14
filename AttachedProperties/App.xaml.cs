using Xamarin.Forms;

namespace AttachedProperties
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//MainPage = new NavigationPage(new AttachedPropertiesPage());
			MainPage = new NavigationPage(new LabelShadowPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
