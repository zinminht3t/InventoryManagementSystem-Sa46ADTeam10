using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Repositories
{
    public static class SupplierItemRepo
    {
        // Convert From Auto Generated DB Model to APIModel
        private static SupplierItemModel ConvertDBSupItemToAPISupItem(supplieritem supitem)
        {
            return new SupplierItemModel(
                    supitem.supid,
                    supitem.supplier.supname,
                    supitem.itemid,
                    supitem.item.description,
                    supitem.price,
                    supitem.item.uom
                );
        }

        public static List<SupplierItemModel> GetItemsBySupplier(int supid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            supplier sup = new supplier();
            List<SupplierItemModel> sims = new List<SupplierItemModel>();
            try
            {
                sup = entities.suppliers
                    .Where(x => x.supid == supid)
                    .First();
                foreach (supplieritem supitem in sup.supplieritems)
                {
                    sims.Add(ConvertDBSupItemToAPISupItem(supitem));
                }
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return sims;
        }
        public static SupplierItemModel AddItemOfSupplier
            (SupplierItemModel sim, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            supplieritem supitem = new supplieritem();
            supitem.supid = sim.SupId;
            supitem.itemid = sim.ItemId;
            supitem.price = sim.Price;
            entities.supplieritems.Add(supitem);
            entities.SaveChanges();
            return sim;
        }

        public static SupplierItemModel UpdateSupplierItem
            (SupplierItemModel sim, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            supplieritem supitem = entities.supplieritems
                .Where(x => x.supid == sim.SupId &&
                x.itemid == sim.ItemId).First();
            supitem.price = sim.Price;
            entities.SaveChanges();
            return sim;
        }
    }
}