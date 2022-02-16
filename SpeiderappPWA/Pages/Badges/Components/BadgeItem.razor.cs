using Microsoft.AspNetCore.Components;
using System;

namespace SpeiderappPWA.Pages.Badges.Components
{
    /**
     * A single badge in the badges view.
     */
    public partial class BadgeItem : ComponentBase
    {
        [Parameter] public string name { get; set; } = "";

        [Parameter] public long id { get; set; } = 0;


        [Parameter] public string description { get; set; } = "";

        [Parameter] public string image { get; set; } = "";

        [Parameter] public string list { get; set; } = "";

        [Parameter] public string logo { get; set; } = "";


        [Parameter] public bool complete { get; set; } = false;

        protected override void OnInitialized()
        {
            Console.WriteLine($"{id}, {description}, {image}, {list}, {logo}, {complete}");
        }
    }
}
