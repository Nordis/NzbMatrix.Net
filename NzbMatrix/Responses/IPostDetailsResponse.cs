using System;

using Castle.Components.DictionaryAdapter;

namespace NzbMatrix.Responses
{
    /*
        NZBNAME:mandriva linux 2009; = NZB Name On Site
        LINK:http://linux.org; = HTTP Link To Attached Website
        SIZE:1469988208.64; = Size in bytes
        INDEX_DATE:2009-02-14 09:08:55; = Indexed By Site (Date/Time GMT)
        USENET_DATE:2009-02-12 2:48:47; = Posted To Usenet (Date/Time GMT)
        CATEGORY:Apps > PC; = Our Site Category
        GROUP:alt.binaries.linux; = Usenet Newsgroup
        COMMENTS:0; = Number Of Comments Posted
        HITS:174; = Number Of Hits (Views)
        NFO:yes; = NFO Present
        PARTS:5702; = Number Of Parts
        USENET_SUBJECT:[mandriva linux 2009] - "mandriva linux 2009.part03.rar" yEnc (1/201); = Usenet Post Subject
        LANGUAGE:English; = Language Attached From Our Index
        IMAGE:http://linux.org/logo.gif; = HTTP Link To Attached Image
        REGION:FREE; = Region Info
     */

    public interface IPostDetailsResponse
    {
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

        [Key("PARTS")]
        int Parts { get; set; }

        [Key("USENET_SUBJECT")]
        string Subject { get; set; }

        [Key("LANGUAGE")]
        string Language { get; set; }

        [Key("IMAGE")]
        string ImageUrl { get; set; }

        [Key("REGION")]
        int Region { get; set; }
    }
}