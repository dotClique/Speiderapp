using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SpeiderappPWA.Pages
{
    public partial class Badges : ComponentBase
    {
        [Inject]
        private HttpClient Http {get; set; }
        private Models.Badge[] badges;

        protected override async Task OnInitializedAsync()
        {
            badges = await Http.GetFromJsonAsync<Models.Badge[]>("sample-data/badges.json");
        }

        private string BadgeLogo(string img)
        {
            if (img != null)
            {
                return img;
            }
            else
            {
                return "https://via.placeholder.com/150";
            }
        }
    }
}
