using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class NumberofRequestModel
    {
        public NumberofRequestModel (int deptid,int? noofreq,int? produceyear, int? producemonth,string deptname)
        {
            this.Deptid = deptid;
            this.Noofreq = noofreq;
            this.Produceyear = Produceyear;
            this.Producemonth = producemonth;
            this.Deptname = deptname;
        }

        public NumberofRequestModel() : this( 0,0,0,0,"") {}

        public int Deptid { get; set; }

        public int? Noofreq { get; set; }


        public int? Produceyear { get; set; }

        public int? Producemonth { get; set; }

        public string Deptname { get; set; }


        
    }
}