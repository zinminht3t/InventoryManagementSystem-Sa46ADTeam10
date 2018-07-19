using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    //Hsu Yee Phyo
    public class CategoryModel
    {
        public CategoryModel(int catid, string name, string shelflocation, string shelflevel)
        {
            this.Catid = catid;
            this.Name = name;
            this.Shelflocation = shelflocation;
            this.Shelflevel = shelflevel;
        }
        public CategoryModel(): this(0, "", "", "")
        {            
        }
        public int Catid { get; set; }
        public string Name { get; set; }
        public string Shelflocation { get; set; }
        public string Shelflevel { get; set; }
    }
}