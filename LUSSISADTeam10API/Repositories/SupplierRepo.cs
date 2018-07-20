using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Repositories
{
    public static class SupplierRepo
    {
        // Convert From Auto Generated DB Model to APIModel
        private static SupplierModel ConvertDBSupToAPISup(supplier sup)
        {
            SupplierModel sm = new SupplierModel(
                    sup.supid,
                    sup.supname,
                    sup.supemail,
                    sup.supphone,
                    sup.contactname,
                    sup.gstregno,
                    sup.active
                );
            return sm;
        }

        // Get the list of all suppliers and will return with error if there is one.
        public static List<SupplierModel> GetAllSuppliers(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<SupplierModel> sms = new List<SupplierModel>();
            try
            {
                // get department list from database
                List<supplier> sups = entities.suppliers.ToList<supplier>();

                // convert the DB Model list to API Model list
                foreach (supplier sup in sups)
                {
                    sms.Add(ConvertDBSupToAPISup(sup));
                }
            }

            // if department not found, will throw NOTFOUND exception
            catch (NullReferenceException)
            {
                // if there is NULL Exception error, error will be 404
                error = ConError.Status.NOTFOUND;
            }

            catch (Exception e)
            {
                // for other exceptions
                error = e.Message;
            }

            //returning the list
            return sms;
        }
        public static SupplierModel GetSupplierById(int supid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            supplier sup = new supplier();
            SupplierModel sm = new SupplierModel();
            try
            {
                sup = entities.suppliers
                    .Where(x => x.supid == supid)
                    .First();
                sm = ConvertDBSupToAPISup(sup);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return sm;
        }
        public static List<SupplierModel> GetSupplierByStatus(int status, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            List<supplier> sups = new List<supplier>();
            List<SupplierModel> sm = new List<SupplierModel>();
            try
            {
                sups = entities.suppliers
                    .Where(x => x.active == status)
                    .ToList();
                foreach(supplier s in sups)
                {
                    sm.Add(ConvertDBSupToAPISup(s));
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
            return sm;
        }

        public static List<SupplierModel> GetSuppliersByItemId(int itemid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            item item = new item();
            List<supplieritem> supitems = new List<supplieritem>();
            List<SupplierModel> sms = new List<SupplierModel>();
            try
            {
                item = entities.items
                    .Where(x => x.itemid == itemid)
                    .First();
                supitems = item.supplieritems.ToList();
                foreach (supplieritem si in supitems)
                {
                    sms.Add(new SupplierModel(
                        si.supplier.supid,
                        si.supplier.supname,
                        si.supplier.supemail,
                        si.supplier.supphone,
                        si.supplier.contactname,
                        si.supplier.gstregno,
                        si.supplier.active
                    ));
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
            return sms;
        }

        public static SupplierModel UpdateSupplier(SupplierModel sm, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            supplier sup = new supplier();
            SupplierModel s = new SupplierModel();
            try
            {
                // finding the supplier object using supplier API model
                sup = entities.suppliers.Where(x => x.supid == sm.SupId).First();

                // transfering data from API model to DB Model
                sup.supid = sm.SupId;
                sup.supname = sm.SupName;
                sup.supemail = sm.SupEmail;
                sup.supphone = sm.SupPhone;
                sup.contactname = sm.ContactName;
                sup.gstregno = sm.GstRegNo;
                sup.active = sm.Active;

                // saving the update
                entities.SaveChanges();

                // return the updated model 
                s = ConvertDBSupToAPISup(sup);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return s;
        }
        public static SupplierModel CreateSupplier(SupplierModel sm, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            supplier sup = new supplier();
            try
            {
                sup.supname = sm.SupName;
                sup.supemail = sm.SupEmail;
                sup.supphone = sm.SupPhone;
                sup.contactname = sm.ContactName;
                sup.gstregno = sm.GstRegNo;
                sup.active = sm.Active;

                entities.suppliers.Add(sup);
                entities.SaveChanges();
                sm = ConvertDBSupToAPISup(sup);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return sm;
        }

        public static SupplierModel DeactivateSupplier(SupplierModel sm, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            supplier sup = new supplier();
            error = "";
            try
            {
                sup = entities.suppliers
                    .Where(x => x.supid == sm.SupId)
                    .First();
                sup.active = ConSupplier.Active.INACTIVE;
                entities.SaveChanges();
                sm = ConvertDBSupToAPISup(sup);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return sm;
        }

        public static SupplierModel ActivateSupplier(SupplierModel sm, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            supplier sup = new supplier();
            error = "";
            try
            {
                sup = entities.suppliers
                    .Where(x => x.supid == sm.SupId)
                    .First();
                sup.active = ConSupplier.Active.ACTIVE;
                entities.SaveChanges();
                sm = ConvertDBSupToAPISup(sup);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return sm;
        }
    }
}