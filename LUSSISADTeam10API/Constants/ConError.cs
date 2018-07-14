using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Constants
{
    public static class ConError
    {
        public static class Status
        {
            public const string BADREQUEST = "400";
            public const string UNAUTHORIZED = "401";
            public const string FORBIDDEN = "403";
            public const string NOTFOUND = "404";
        }
    }
}