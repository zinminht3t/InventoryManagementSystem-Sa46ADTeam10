using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class DelegationModel
    {
        
        public DelegationModel(int delid, DateTime? startdate, DateTime? enddate, int userid, String username , int role , string depname,
            int active, int assignedby , String ausername , int arole ,String adeptname)
        {
            this.delid = delid;
            this.startdate = startdate;
            this.enddate = enddate;
            this.userid = userid;
            this.username = username;
            this.role = role;
            this.depname = depname;
            this.active = active;
            this.assignedbyId = assignedby;
            this.assignedbyusername = ausername;
            this.assignedbyrole = arole;
            this.assignedbydepname = adeptname;
        }
        public DelegationModel() : this(0,null,null, 0,"", 0, "" ,0, 0 ,"" ,0 ,"")
        {
        }
        public int delid { get; set; }

        public DateTime? startdate { get; set; }

        public DateTime? enddate { get; set; }

        public int userid { get; set; }

        public String username { get; set; }
        public int role { get; set; }
        public String depname { get; set; }

        public int active { get; set; }

        public int assignedbyId { get; set; }
        public String assignedbyusername { get; set; }
        public int assignedbyrole { get; set; }
        public String assignedbydepname { get; set; }

    }
}