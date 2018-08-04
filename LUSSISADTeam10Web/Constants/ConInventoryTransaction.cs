using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Constants
{
    public class ConInventoryTransaction
    {
        public static class TransType
        {
            public const int ADJUSTMENT = 0;
            public const int PURCHASEORDER_RECEIEVED = 1;
            public const int DISBURSEMENT = 2;
            public const int OUTSTANDING = 3;
        }
    }
}
