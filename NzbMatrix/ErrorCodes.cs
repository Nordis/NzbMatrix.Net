using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NzbMatrix
{
    public enum ErrorCode
    {
        InvalidLogin,
        InvalidApi,
        InvalidNzbId,
        PleaseWait,
        VipOnly,
        DisabledAccount,
        DailyLimit,
        NoNzbFound
    }
}
