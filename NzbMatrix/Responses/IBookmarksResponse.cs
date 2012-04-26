using Castle.Components.DictionaryAdapter;

namespace NzbMatrix.Responses
{
    /*
        RESULT:xxxxxxxxxxxxx;
     */

    public interface IBookmarksResponse
    {
        [Key("RESULT")]
        string Result { get; set; }
    }
}