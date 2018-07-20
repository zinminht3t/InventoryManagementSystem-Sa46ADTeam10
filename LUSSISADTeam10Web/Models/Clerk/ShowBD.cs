using LUSSISADTeam10Web.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Clerk
{
    public class ShowBD
    {
            public int ItemID { get; set; }
            public int Qty { get; set; }
            public string ItemDescription { get; set; }
            public List<BreakDown> BDList { get; set; }

        
    }
}