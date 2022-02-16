using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace SpeiderappPWA.Pages.Badge
{
    public partial class Badge : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        private HttpClient Http {get; set; }
        private Models.Badge _thisBadge;

        protected override async Task OnInitializedAsync()
        {
            var badges = await Http.GetFromJsonAsync<Models.Badge[]>("sample-data/badges.json");

            if (badges == null) return; // TODO: Handle this error
            _thisBadge = badges.ToList().Find(badge => badge.Id == Id);
        }
    }
}
