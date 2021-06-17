using System;

namespace WebScrapper.Data.Models
{
    public class SearchResult : BaseModel
    {
        public string Url { get; set; }
        public string Keywords { get; set; }
        public string Ranking { get; set; }
        public DateTime SearchDate { get; set; }
        public int Occurrences { get; set; }
    }
}
