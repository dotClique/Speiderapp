// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace SpeiderappAPI.Models
{
    public class TaggedWith
    {
        public TaggedWith(long badgeId, long tagId)
        {
            BadgeId = badgeId;
            TagId = tagId;
        }

        public long BadgeId { get; set; }
        public long TagId { get; set; }
    }
}
