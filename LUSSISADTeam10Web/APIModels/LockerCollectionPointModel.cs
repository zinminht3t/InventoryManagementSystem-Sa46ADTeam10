using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class LockerCollectionPointModel
    {
        public LockerCollectionPointModel(int lockerid, string lockername, string lockersize,int cpid,int status,string cpname)
        {
            this.Lockerid = lockerid;
            this.Lockername = lockername;
            this.Lockersize = lockersize;
            this.Cpid = cpid;
            this.Status = status;
            this.Cpname = cpname;
          
                 
           
        }

        public LockerCollectionPointModel(): this(0,"","",0,0,"")
        {

        }

        public int Lockerid { get; set; }

        public string Lockername { get; set; }

        public string Lockersize { get; set; }

        public int Cpid { get; set; }

        public int Status { get; set; }

        public string Cpname { get; set; }

        
    }
}