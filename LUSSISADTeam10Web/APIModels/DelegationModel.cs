using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class DelegationModel
    {
        
        public DelegationModel(int delid, DateTime? startdate, DateTime? enddate, int userid, String username , int role , string depname,
            int active, int assignedby , String ausername , int arole ,String adeptname)
        {
            this.Delid = delid;
            this.Startdate = startdate;
            this.Enddate = enddate;
            this.Userid = userid;
            this.Username = username;
            this.Role = role;
            this.Depname = depname;
            this.Active = active;
            this.AssignedbyId = assignedby;
            this.Assignedbyusername = ausername;
            this.Assignedbyrole = arole;
            this.Assignedbydepname = adeptname;
        }
        public DelegationModel() : this(0,null,null, 0,"", 0, "" ,0, 0 ,"" ,0 ,"")
        {
        }
        public int Delid { get; set; }

        public DateTime? Startdate { get; set; }

        public DateTime? Enddate { get; set; }

        public int Userid { get; set; }

        public String Username { get; set; }
        public int Role { get; set; }
        public String Depname { get; set; }

        public int Active { get; set; }

        public int AssignedbyId { get; set; }
        public String Assignedbyusername { get; set; }
        public int Assignedbyrole { get; set; }
        public String Assignedbydepname { get; set; }

    }
}