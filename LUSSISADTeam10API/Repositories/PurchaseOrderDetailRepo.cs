using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Repositories
{
    public class PurchaseOrderDetailRepo
    {
        // Convert From Auto Generated DB Model to APIModel
        private static PurchaseOrderDetailModel ConvertDBtoAPIPOModel(purchaseorderdetail pod)
        {
            PurchaseOrderDetailModel pom = new PurchaseOrderDetailModel(pod.poid, pod.itemid, pod.item.description, pod.qty, pod.delivqty, pod.item.category.name, pod.item.uom, pod.price);
            return pom;
        }
        //find Purchase Order by id
        public static List<PurchaseOrderDetailModel> GetPurchaseOrderDetailByID(int poid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            purchaseorder po = new purchaseorder();
            List<PurchaseOrderDetailModel> podms = new List<PurchaseOrderDetailModel>();
            try
            {
                po = entities.purchaseorders.Where(a => a.poid == poid).FirstOrDefault<purchaseorder>();
                foreach (purchaseorderdetail pod in po.purchaseorderdetails)
                {
                    podms.Add(ConvertDBtoAPIPOModel(pod));
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
            return podms;
        }
        //find Purchase Order detail by id and itemid
        public static PurchaseOrderDetailModel GetPurchaseOrderDetailByIDAndItemID(int poid, int itemid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            purchaseorderdetail pod = new purchaseorderdetail();
            PurchaseOrderDetailModel podm = new PurchaseOrderDetailModel();
            try
            {
                pod = entities.purchaseorderdetails.Where(a => a.poid == poid && a.itemid == itemid).FirstOrDefault<purchaseorderdetail>();
                podm = ConvertDBtoAPIPOModel(pod);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return podm;
        }
        //Create new PurchaseOrder
        public static PurchaseOrderDetailModel CreatePurchaseOrderDetail(PurchaseOrderDetailModel podm, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            purchaseorderdetail pod = new purchaseorderdetail();
            try
            {
                pod.poid = podm.PoId;
                pod.itemid = podm.Itemid;
                pod.qty = podm.Qty;
                pod.delivqty = podm.DelivQty;
                pod.price = podm.Price;
                entities.purchaseorderdetails.Add(pod);
                entities.SaveChanges();
                podm = GetPurchaseOrderDetailByIDAndItemID(pod.poid, pod.itemid, out error);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return podm;
        }
        //Update PurchaseOrder
        public static PurchaseOrderDetailModel UpdatePurchaseOrderDetail(PurchaseOrderDetailModel podm, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            purchaseorderdetail pod = new purchaseorderdetail();
            try
            {
                pod = entities.purchaseorderdetails.Where(p => p.poid == podm.PoId && p.itemid == podm.Itemid).FirstOrDefault<purchaseorderdetail>();
                pod.itemid = podm.Itemid;
                pod.qty = podm.Qty;
                pod.price = podm.Price;
                pod.delivqty = podm.DelivQty;
                entities.SaveChanges();
                podm = GetPurchaseOrderDetailByIDAndItemID(pod.poid, pod.itemid, out error);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return podm;
        }
    }
}