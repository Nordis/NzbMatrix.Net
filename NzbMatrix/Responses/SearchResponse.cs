using System;
using System.Collections.Generic;

namespace NzbMatrix.Responses
{
    public class SearchResponse : ISearchResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NzbUrl { get; set; }

        public string Size { get; set; }

        public decimal Bytes { get { return decimal.Parse(Size); } }

        public DateTime IndexDate { get; set; }
        public DateTime UsenetDate { get; set; }
        public string Category { get; set; }
        public string Group { get; set; }
        public int Comments { get; set; }
        public int Hits { get; set; }
        public string Nfo { get; set; }
        public string Weblink { get; set; }
        public string Language { get; set; }
        public string ImageUrl { get; set; }
        public int Region { get; set; }
    }
}
