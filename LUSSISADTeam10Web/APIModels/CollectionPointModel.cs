using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class CollectionPointModel
    {
        public CollectionPointModel(int cpid, string cpname, string cplocation)
        {
            this.cpid = cpid;
            this.cpname = cpname;
            this.cplocation = cplocation;       
        }

        public CollectionPointModel() : this(0, "", "")
        {
        }

        public int cpid { get; set; }

        public string cpname { get; set; }

        public string cplocation { get; set; }
        

    }
}