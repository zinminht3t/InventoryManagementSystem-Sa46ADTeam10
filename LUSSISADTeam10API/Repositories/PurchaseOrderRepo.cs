using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Repositories
{
    public class PurchaseOrderRepo
    {
        // Convert From Auto Generated DB Model to APIModel
        private static PurchaseOrderModel ConvertDBtoAPIPOModel(purchaseorder po)
        {
            List<PurchaseOrderDetailModel> podms = new List<PurchaseOrderDetailModel>();
            foreach (purchaseorderdetail pod in po.purchaseorderdetails)
            {
                podms.Add(new PurchaseOrderDetailModel(pod.poid, pod.itemid, pod.item.description, pod.qty, pod.delivqty, pod.item.category.name, pod.item.uom));
            }
            PurchaseOrderModel pom = new PurchaseOrderModel(po.poid, po.purchasedby, po.user.fullname, po.supid, po.supplier.supname, po.podate, po.status, podms);
            return pom;
        }
        
        //Get all purchase order list
        public static List<PurchaseOrderModel> GetAllPurchaseOrders(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<PurchaseOrderModel> pom = new List<PurchaseOrderModel>();
            try
            {
                // get purchaseorder list from database
                List<purchaseorder> pos = entities.purchaseorders.ToList<purchaseorder>();

                // convert the DB Model list to API Model list
                foreach (purchaseorder po in pos)
                {
                    pom.Add(ConvertDBtoAPIPOModel(po));
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
            return pom;
        }
        //find Purchase Order by id
        public static PurchaseOrderModel GetPurchaseOrderByID(int poid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            purchaseorder po = new purchaseorder();
            PurchaseOrderModel pom = new PurchaseOrderModel();
            try
            {
                po = entities.purchaseorders.Where(a => a.poid == poid).FirstOrDefault<purchaseorder>();
                pom = ConvertDBtoAPIPOModel(po);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return pom;
        }

        //find PurchaseOrder by purchased by id
        public static List<PurchaseOrderModel> GetPurchaseOrderByPurchasedById(int purchasedby, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            List<purchaseorder> po = new List<purchaseorder>();
            List<PurchaseOrderModel> pom = new List<PurchaseOrderModel>();
            try
            {
                po = entities.purchaseorders.Where(a => a.purchasedby == purchasedby).ToList<purchaseorder>();
                foreach (purchaseorder ad in po)
                {
                    pom.Add(ConvertDBtoAPIPOModel(ad));
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
            return pom;
        }

        //find PurchaseOrder by Purchase Order date
        public static List<PurchaseOrderModel> GetPurchaseOrderByPODate(DateTime podate, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            List<purchaseorder> po = new List<purchaseorder>();
            List<PurchaseOrderModel> pom = new List<PurchaseOrderModel>();
            try
            {
                po = entities.purchaseorders.Where(a => a.podate == podate).ToList<purchaseorder>();
                foreach (purchaseorder ad in po)
                {
                    pom.Add(ConvertDBtoAPIPOModel(ad));
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
            return pom;
        }

        //find PurchaseOrder by status
        public static List<PurchaseOrderModel> GetPurchaseOrderByStatus(int status, out string error)
        {

            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            List<purchaseorder> po = new List<purchaseorder>();
            List<PurchaseOrderModel> pom = new List<PurchaseOrderModel>();
            try
            {
                po = entities.purchaseorders.Where(a => a.status == status).ToList<purchaseorder>();
                foreach (purchaseorder ad in po)
                {
                    pom.Add(ConvertDBtoAPIPOModel(ad));
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
            return pom;
        }

        //Create new PurchaseOrder
        public static PurchaseOrderModel CreatePurchaseOrder(PurchaseOrderModel pom, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            purchaseorder po = new purchaseorder();
            List<purchaseorderdetail> pods = new List<purchaseorderdetail>();
            try
            {
                po.purchasedby = pom.Purchasedby;
                po.supid = pom.Supid;
                po.podate = DateTime.Now;
                po.status = pom.Status;
                po = entities.purchaseorders.Add(po);
                entities.SaveChanges();
                pom = GetPurchaseOrderByID(po.poid, out error);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return pom;
        }

        //Update PurchaseOrder
        public static PurchaseOrderModel UpdatePurchaseOrder(PurchaseOrderModel pom, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            purchaseorder po = new purchaseorder();
            try
            {
                po = entities.purchaseorders.Where(p => p.poid == pom.PoId).FirstOrDefault<purchaseorder>();

                po.purchasedby = pom.Purchasedby;
                po.supid = pom.Supid;
                po.status = pom.Status;
                entities.SaveChanges();

                pom = GetPurchaseOrderByID(po.poid, out error);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return pom;
        }
    }
}