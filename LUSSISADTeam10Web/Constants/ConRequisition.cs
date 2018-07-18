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

        public static class StatusString
        {
            public const string PENDING = "Pending";
            public const string APPROVED = "Approved";
            public const string REQUESTPENDING = "Request Pending";
            public const string PREPARING = "Preparing";
            public const string DELIVERED = "Delivered";
            public const string OUTSTANDINGREQUISITION = "Outstanding Requisition";
            public const string COMPLETED = "Completed";
        }

        public static string CovertStatustoStatusString(int status)
        {
            switch (status)
            {
                case Status.PENDING:
                    return StatusString.PENDING;
                case Status.APPROVED:
                    return StatusString.APPROVED;
                case Status.REQUESTPENDING:
                    return StatusString.REQUESTPENDING;
                case Status.PREPARING:
                    return StatusString.PREPARING;
                case Status.DELIVERED:
                    return StatusString.DELIVERED;
                case Status.OUTSTANDINGREQUISITION:
                    return StatusString.OUTSTANDINGREQUISITION;
                case Status.COMPLETED:
                    return StatusString.COMPLETED;
            }
            return "";
        }
    }
}