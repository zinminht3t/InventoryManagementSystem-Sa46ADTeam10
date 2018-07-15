using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Constants
{
    public static class ConRequisition
    {
        public static class Status
        {
            public const int PENDING = 0;
            public const int APPROVED = 1;
            public const int REQUESTPENDING = 2;
            public const int PREPARING = 3;
            public const int DELIVERED = 4;
            public const int OUTSTANDINGREQUISITION = 5;
            public const int COMPLETED = 6;
        }
    }
}