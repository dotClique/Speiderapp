using System;
using Microsoft.AspNetCore.Components;

namespace SpeiderappPWA.Pages.Badges.Components
{
    public partial class Badge : ComponentBase
    {
        [Parameter]
        public string name { get; set; } = "";

        [Parameter]
        public long id { get; set; } = 0;


        [Parameter]
        public string description { get; set; } = "";

        [Parameter]
        public string image { get; set; } = "";

        [Parameter]
        public string list { get; set; } = "";

        [Parameter]
        public string logo { get; set; } = "";


        [Parameter]
        public bool complete { get; set; } = false;


        private double RightBorderY(double deg)
        {
            if (deg >= 0.5)
            {
                return 75.0;
            }
            return Math.Sin(-deg * Math.PI * 2 + Math.PI) * 75 + 75;
        }
        private double RightBorderX(double deg)
        {
            if (deg >= 0.5)
            {
                return 150;
            }
            return Math.Cos(-deg * Math.PI * 2 + Math.PI) * 75 + 75;
        }
        private double LeftBorderY(double deg)
        {
            if (deg <= 0.5)
            {
                return 150.0;
            }
            return Math.Sin(-deg * Math.PI * 2 + Math.PI) * 75 + 75;
        }
        private double LeftBorderX(double deg)
        {
            if (deg <= 0.5)
            {
                return 0;
            }
            return Math.Cos(-deg * Math.PI * 2 + Math.PI) * 75 + 75;
        }
    }
}
