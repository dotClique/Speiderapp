// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace SpeiderappAPI.Models
{
    public class Category
    {
        public Category(long id, string title)
        {
            Id = id;
            Title = title;

        }

        public long Id { get; set; }
        public string Title { get; set; }
    }
}
