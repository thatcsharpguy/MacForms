using System.Net.Http;
using Xamarin.Forms;

namespace MacForms
{
	public partial class MacFormsPage : ContentPage
	{
		public MacFormsPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			HttpClient c = new HttpClient();
			var p = await c.GetStringAsync("http://api.open-notify.org/astros.json");
			Text.Text = p;
		}
	}
}
