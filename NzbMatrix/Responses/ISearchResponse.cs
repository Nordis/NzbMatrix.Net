using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Components.DictionaryAdapter;

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

    public interface ISearchResponse
    {
        [Key("NZBID")]
        int Id { get; set; }

        [Key("NZBNAME")]
        string Name { get; set; }

        [Key("LINK")]
        string NzbUrl { get; set; }

        [Key("SIZE")]
        string Size { get; set; }

        [Key("INDEX_DATE")]
        DateTime IndexDate { get; set; }

        [Key("USENET_DATE")]
        DateTime UsenetDate { get; set; }

        [Key("CATEGORY")]
        string Category { get; set; }

        [Key("GROUP")]
        string Group { get; set; }

        [Key("COMMENTS")]
        int Comments { get; set; }

        [Key("HITS")]
        int Hits { get; set; }

        [Key("NFO")]
        string Nfo { get; set; }

        [Key("WEBLINK")]
        string Weblink { get; set; }

        [Key("LANGUAGE")]
        string Language { get; set; }

        [Key("IMAGE")]
        string ImageUrl { get; set; }

        [Key("REGION")]
        int Region { get; set; }
    }
}
