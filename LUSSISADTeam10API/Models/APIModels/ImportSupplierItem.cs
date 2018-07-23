using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class ImportSupplierItem
    {
        public ImportSupplierItem
           ( string SupName, 
           string Description, double Price, string Uom )
        {
         
            this.SupName = SupName;           
            this.Description = Description;
            this.Price = Price;
            this.Uom = Uom;
          

        }

        public ImportSupplierItem() :
            this("", "", 0.0, "" )
        {
        }

      

    

        public string SupName { get; set; }
       

        public string Description { get; set; }

        public double Price { get; set; }

        public string Uom { get; set; }
    }
}
