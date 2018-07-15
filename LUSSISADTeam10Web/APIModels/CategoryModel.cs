using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    //Hsu Yee Phyo
    public class CategoryModel
    {
        public CategoryModel(int catid, string name, string shelflocation, string shelflevel)
        {
            this.catid = catid;
            this.name = name;
            this.shelflocation = shelflocation;
            this.shelflevel = shelflevel;
        }
        public CategoryModel(): this(0, "", "", "")
        {            
        }
        public int catid { get; set; }
        public string name { get; set; }
        public string shelflocation { get; set; }
        public string shelflevel { get; set; }
    }
}