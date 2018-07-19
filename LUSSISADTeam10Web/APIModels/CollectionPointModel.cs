using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class CollectionPointModel
    {
        public CollectionPointModel(int cpid, string cpname, string cplocation, double? latitude, double? longitude)
        {
            this.Cpid = cpid;
            this.Cpname = cpname;
            this.Cplocation = cplocation;       
            this.Latitude = latitude;       
            this.Longitude = longitude;       
        }

        public CollectionPointModel() : this(0, "", "", 0, 0)
        {
        }

        public int Cpid { get; set; }
        public string Cpname { get; set; }
        public string Cplocation { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }


    }
}