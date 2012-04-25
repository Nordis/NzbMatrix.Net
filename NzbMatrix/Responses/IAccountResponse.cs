using Castle.Components.DictionaryAdapter;

namespace NzbMatrix.Responses
{
    /*
        USERNAME:foobar; = Userame On Site
        USERID:5654; = Account ID number
        API_DAILY_RATE:0; = Your daily rate limitation used
        API_DAILY_DOWNLOAD:0; = Your daily API download limitation used
     */

    public interface IAccountResponse
    {
        [Key("USERNAME")]
        string Username { get; set; }

        [Key("USERID")]
        string UserId { get; set; }

        [Key("API_DAILY_RATE")]
        string ApiDailyRate { get; set; }

        [Key("API_DAILY_DOWNLOAD")]
        string ApiDailyDownload { get; set; }
    }
}