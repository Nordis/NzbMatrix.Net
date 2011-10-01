using System;
using System.Collections.Generic;

namespace NzbMatrix.Responses
{
    /*
        NZBID:444027; = NZB ID On Site
        NZBNAME:mandriva linux 2009; = NZB Name On Site
        LINK:nzbmatrix.com/nzb-details.php?id=444027&hit=1; = Link To NZB Details PAge
        SIZE:1469988208.64; = Size in bytes
        INDEX_DATE:2009-02-14 09:08:55; = Indexed By Site (Date/Time GMT)
        USENET_DATE:2009-02-12 2:48:47; = Posted To Usenet (Date/Time GMT)
        CATEGORY:TV > Divx/Xvid; = NZB Post Category
        GROUP:alt.binaries.linux; = Usenet Newsgroup
        COMMENTS:0; = Number Of Comments Posted
        HITS:174; = Number Of Hits (Views)
        NFO:yes; = NFO Present
        WEBLINK:http://linux.org; = HTTP Link To Attached Website
        LANGUAGE:English; = Language Attached From Our Index
        IMAGE:http://linux.org/logo.gif; = HTTP Link To Attached Image
        REGION:0; = Region Coding (See notes)
     */

    public class SearchResponse
    {
        private readonly Dictionary<string, string> _values;

        public SearchResponse(Dictionary<string, string> values)
        {
            _values = values;
        }

        public int Id 
        { 
            get { return int.Parse(_values["NZBID"]); } 
        }

        public string Name 
        {
            get { return _values["NZBNAME"]; }
        }

        public string NzbUrl 
        {
            get { return _values["LINK"]; }
        }

        public long Bytes
        {
            get { return long.Parse(_values["SIZE"]); }
        }

        public DateTime IndexDate
        {
            get { return DateTime.Parse(_values["INDEX_DATE"]); }
        }

        public DateTime UsenetDate
        {
            get { return DateTime.Parse(_values["USENET_DATE"]); }
        }

        public string Category
        {
            get { return _values["CATEGORY"]; }
        }

        public string Group
        {
            get { return _values["GROUP"]; }
        }

        public int Comments
        {
            get { return int.Parse(_values["COMMENTS"]); }
        }

        public int Hits
        {
            get { return int.Parse(_values["HITS"]); }
        }

        public bool HasNfo
        {
            get { return (!string.IsNullOrEmpty(_values["NFO"]) && _values["NFO"] == "yes"); }
        }

        public string Weblink
        {
            get { return _values["WEBLINK"]; }
        }

        public string Language
        {
            get { return _values["LANGUAGE"]; }
        }

        public string ImageUrl
        {
            get { return _values["IMAGE"]; }
        }

        public int Region
        {
            get { return int.Parse(_values["REGION"]); }
        }
    }
}
