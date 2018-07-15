using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class DelegationModel
    {
        
        public DelegationModel(int delid, DateTime? startdate, DateTime? enddate, int userid, int active, int assignedby)
        {
            this.delid = delid;
            this.startdate = startdate;
            this.enddate = enddate;
            this.userid = userid;
            this.active = active;
            this.assignedby = assignedby;

        }
        public DelegationModel() : this(0,null,null, 0,0, 0)
        {
        }
        public int delid { get; set; }

        public DateTime? startdate { get; set; }

        public DateTime? enddate { get; set; }

        public int userid { get; set; }

        public int active { get; set; }

        public int assignedby { get; set; } 

    }
}