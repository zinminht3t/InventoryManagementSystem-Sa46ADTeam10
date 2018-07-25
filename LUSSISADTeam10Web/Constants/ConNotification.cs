using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Constants
{
    public class ConNotification
    {
        public static class IsRead
        {
            public const bool Read = true;
            public const bool UnRead = false;
        }

        public static class NotiType
        {
            public const int Adjustment = 1;
            public const int RequisitionApproval = 2;


            public const int DeliveredRequisition = 3;
            public const int CollectedRequistion = 4;
            public const int RejectedRequistion = 5;
            public const int HODApprovedRequistion = 6;
            public const int ClerkApprovedRequisiton = 7;


            public const int ClerkApprovedCollectionPointChange = 8;
            public const int ClerkRejectedCollectionPointChange = 9;

            public const int CollectionPointChangeRequestApproval = 10;

            public const int DelegationAssigned = 11;
            public const int DelegationCancelled = 12;

            public const int DeptRepAssigned = 13;

            public const int OutstandingItemsReadyToCollect = 14;
            public const int OutstandingItemsCollected = 15;
        }
    }
}