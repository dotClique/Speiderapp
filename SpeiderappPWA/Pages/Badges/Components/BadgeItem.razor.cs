using System;
using Microsoft.AspNetCore.Components;

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

        public double RightBorderY(double deg)
        {
            if (deg > 0.5 || Double.IsNaN(deg))
            {
                return 75.0;
            }
            return Math.Sin(-deg * Math.PI * 2 + Math.PI) * 75 + 75;
        }
        public double RightBorderX(double deg)
        {
            if (deg > 0.5 || Double.IsNaN(deg))
            {
                return 150;
            }
            return Math.Cos(-deg * Math.PI * 2 + Math.PI) * 75 + 75;
        }
        public double LeftBorderY(double deg)
        {
            if (deg <= 0.5 || Double.IsNaN(deg))
            {
                return 150.0;
            }
            return Math.Sin(-deg * Math.PI * 2 + Math.PI) * 75 + 75;
        }
        public double LeftBorderX(double deg)
        {
            if (deg <= 0.5 || Double.IsNaN(deg))
            {
                return 0;
            }
            return Math.Cos(-deg * Math.PI * 2 + Math.PI) * 75 + 75;
        }
    }
}
