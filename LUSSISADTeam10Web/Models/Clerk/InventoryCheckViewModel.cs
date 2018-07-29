using LUSSISADTeam10Web.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Clerk
{
    public class InventoryCheckViewModel
    {

        
        public List<InventoryDetailModel> Invs { get; set; }

        public List<int> InvIDs { get; set; }
    }
}