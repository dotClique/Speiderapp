using System;
using Microsoft.AspNetCore.Components;

namespace SpeiderappPWA.Pages.Badges.Components
{
    public partial class Badge : ComponentBase
    {
        [Parameter]
        public string Name { get; set; } = "";

        [Parameter]
        public long ID { get; set; } = 0;


        [Parameter]
        public string Description { get; set; } = "";

        [Parameter]
        public string Image { get; set; } = "";

        [Parameter]
        public string List { get; set; } = "";

        [Parameter]
        public string Logo { get; set; } = "";


        [Parameter]
        public bool Complete { get; set; } = false;


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
