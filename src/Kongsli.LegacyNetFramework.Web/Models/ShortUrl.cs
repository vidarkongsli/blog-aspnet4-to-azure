using System;

namespace Kongsli.LegacyNetFramework.Web.Models
{
    public class ShortUrl
    {
        public Uri Location { get; set; }

        public string ShortPath { get; set; }

        public bool IsEmpty { get; set; }
    }
}