using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Clerk
{
    public class PendingCollectionPointViewModel
    {   
        public List<PendingCP> pCP { get; set;}

}
    public class PendingCP
    {
        public bool Approve { get; set; }
        public int DepCpID { get; set; }     
        public int CpID { get; set; }
        public string Remark { get; set; }
        public string CpName { get; set; }
        public string OldCpName { get; set; }
        public string DepName { get; set; }
        public int DepID { get; set; }
    }

    }