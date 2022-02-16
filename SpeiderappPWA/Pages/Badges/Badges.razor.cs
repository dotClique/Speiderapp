using System;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SpeiderappPWA.Pages.Badges
{
    public partial class Badges : ComponentBase
    {
        [Inject]
        private HttpClient Http {get; set; }
        private Models.Badge[] badges;

        protected override async Task OnInitializedAsync()
        {
            badges = await Http.GetFromJsonAsync<Models.Badge[]>("sample-data/badges.json");
            if (badges is null) return;
            foreach (var badge in badges)
            {
                Console.WriteLine(badge.ToString());
            }
        }

        private string collapsed = "collapsed";
        private string gridSelected = "selected";
        private string listSelected = "";
        private string list = "";
    }
}
