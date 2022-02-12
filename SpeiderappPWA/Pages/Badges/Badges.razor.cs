using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace SpeiderappPWA.Pages.Badges
{
    public partial class Badges : ComponentBase
    {
        [Inject]
        private HttpClient Http { get; set; }
        private Models.Badge[] _badges;

        protected override async Task OnInitializedAsync()
        {
            _badges = await Http.GetFromJsonAsync<Models.Badge[]>("sample-data/badges.json");
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

        private string _collapsed = "collapsed";
        private string _gridSelected = "selected";
        private string _listSelected = "";
        private string _list = "";
        private void ToggleFilter()
        {
            if (_collapsed == "")
            {
                _collapsed = "collapsed";
            }
            else
            {
                _collapsed = "";
            }
        }

        private void ListView()
        {
            _list = "list";
            _gridSelected = "";
            _listSelected = "selected";
        }

        private void GridView()
        {
            _list = "";
            _gridSelected = "selected";
            _listSelected = "";
        }
    }
}
