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
        
        private string collapsed = "collapsed";
        private string gridSelected = "selected";
        private string listSelected = "";
        private string list = "";
        private void ToggleFilter()
        {
            if (collapsed == "")
            {
                collapsed = "collapsed";
            }
            else
            {
                collapsed = "";
            }
        }

        private void ListView()
        {
            list = "list";
            gridSelected = "";
            listSelected = "selected";
        }

        private void GridView()
        {
            list = "";
            gridSelected = "selected";
            listSelected = "";
        }
    }
}
