using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MacForms
{
	public partial class MacFormsPage : ContentPage
	{
		HttpClient _client = new HttpClient();

		public MacFormsPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			var peopleInSpaceResponse = await _client.GetStringAsync("http://api.open-notify.org/astros.json");
			var peopleInSpace = JsonConvert.DeserializeObject<PeopleInSpaceResponse>(peopleInSpaceResponse);
			Text.Text = string.Join(", ", peopleInSpace.People.Select(p => $"{p.Name} ({p.Craft})"));


			var issLocationResponse = await _client.GetStringAsync("http://api.open-notify.org/iss-now.json");
			var issLocation = JsonConvert.DeserializeObject<IssPositionResponse>(issLocationResponse);
			Text.Text +="\n" +$"{issLocation.Timestamp} : {issLocation.IssPosition.Longitude} {issLocation.IssPosition.Latitude}";


			var mapUrl = $"https://maps.googleapis.com/maps/api/staticmap?center={issLocation.IssPosition.Latitude}" + 
				$",{issLocation.IssPosition.Longitude}&zoom=5&scale=false&size=600x300&maptype=roadmap&format=png&visual_refresh=true";

			IssLocationImage.Source = mapUrl;
		}
	}
}
