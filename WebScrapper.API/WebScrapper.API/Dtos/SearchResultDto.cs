using System;
using System.ComponentModel.DataAnnotations;

namespace WebScrapper.Api.Dtos
{
    public class SearchResultDto
    {
        public string Url { get; set; }
        public string Keywords { get; set; }
        public string Ranking { get; set; }
        public int Occurrences { get; set; }
        public string SearchDate { get; set; }
    }
}
