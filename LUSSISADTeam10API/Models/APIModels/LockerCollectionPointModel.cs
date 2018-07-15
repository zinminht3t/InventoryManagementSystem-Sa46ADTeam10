using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class LockerCollectionPointModel
    {
        public LockerCollectionPointModel(int lockerid, string lockername, string lockersize,int cpid,int status,string cpname)
        {
            this.lockerid = lockerid;
            this.lockername = lockername;
            this.lockersize = lockersize;
            this.cpid = cpid;
            this.status = status;
            this.cpname = cpname;
          
                 
           
        }

        public LockerCollectionPointModel(): this(0,"","",0,0,"")
        {

        }

        public int lockerid { get; set; }

        public string lockername { get; set; }

        public string lockersize { get; set; }

        public int cpid { get; set; }

        public int status { get; set; }

        public string cpname { get; set; }

        
    }
}