using System;
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
        private HttpClient Http { get; set; }

        private Models.Badge _thisBadge = new("Title", null, "Description", DateTime.Now);

        protected override async Task OnInitializedAsync()
        {
            var badges = await Http.GetFromJsonAsync<Models.Badge[]>("sample-data/badges.json");

            if (badges == null) return;
            _thisBadge = badges.ToList().Find(badge => badge.RequirementID == Id);
        }
    }
}
