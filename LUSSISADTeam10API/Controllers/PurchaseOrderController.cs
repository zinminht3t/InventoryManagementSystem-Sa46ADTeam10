using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;

namespace LUSSISADTeam10API.Controllers
{
    [Authorize]
    public class PurchaseOrderController : ApiController
    {
        // to show purchase order list
        [HttpGet]
        [Route("api/purchaseorders")]
        public IHttpActionResult GetAllPurchaseOrders()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

            // get the list from purchase orderrepo and will insert the error if there is one
            List<PurchaseOrderModel> poms = PurchaseOrderRepo.GetAllPurchaseOrders(out error);
            // if the erorr is not blank or the purchase order list is null
            if (error != "" || poms == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Purchase Order Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(poms);

        }

        // to get Purchase Order by purchaseorder id
        [HttpGet]
        [Route("api/purchaseorder/{poid}")]
        public IHttpActionResult GetPurchaseOrderById(int poid)
        {
            string error = "";
            PurchaseOrderModel orm =
                PurchaseOrderRepo.GetPurchaseOrderByID(poid, out error);
            if (error != "" || orm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "PO Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(orm);
        }


        // to get Purchase Order by PO Date
        [HttpGet]
        [Route("api/purchaseorder/podate/{podate}")]
        public IHttpActionResult GetPurchaseOrderByPODate(DateTime podate)
        {
            string error = "";
            List<PurchaseOrderModel> orms =
                PurchaseOrderRepo.GetPurchaseOrderByPODate(podate, out error);
            if (error != "" || orms == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "PO Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(orms);
        }

        // to get Purchase Order by purchased by user id
        [HttpGet]
        [Route("api/purchaseorder/user/{userid}")]
        public IHttpActionResult GetPurchaseOrderByUserID(int userid)
        {
            string error = "";
            List<PurchaseOrderModel> orms =
                PurchaseOrderRepo.GetPurchaseOrderByPurchasedById(userid, out error);
            if (error != "" || orms == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "PO Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(orms);
        }

        // to get Purchase Order by status
        [HttpGet]
        [Route("api/purchaseorder/status/{status}")]
        public IHttpActionResult GetPurchaseOrderByStatus(int status)
        {
            string error = "";
            List<PurchaseOrderModel> orms =
                PurchaseOrderRepo.GetPurchaseOrderByStatus(status, out error);
            if (error != "" || orms == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "PO Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(orms);
        }

        // to update Purchase Order req
        [HttpPost]
        [Route("api/purchaseorder/update")]
        public IHttpActionResult UpdatePO(PurchaseOrderModel po)
        {
            string error = "";
            PurchaseOrderModel orm = PurchaseOrderRepo.UpdatePurchaseOrder(po, out error);
            if (error != "" || orm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "PO Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(orm);
        }



        // to update Purchase Order req
        [HttpPost]
        [Route("api/purchaseorder/complete")]
        public IHttpActionResult UpdatePOStatusComplete(PurchaseOrderModel po)
        {
            string error = "";

            po = PurchaseOrderRepo.GetPurchaseOrderByID(po.PoId, out error);

            // if the staff has already updated the status to "received"
            if (po.Status == ConPurchaseOrder.Status.RECEIVED)
            {
                return Ok(po);
            }
            po.Status = ConPurchaseOrder.Status.RECEIVED;

            List<PurchaseOrderDetailModel> podms = PurchaseOrderDetailRepo.GetPurchaseOrderDetailByID(po.PoId, out error);

            // if the purchase order is completed, the stock must be updated according to deliver qty.
            foreach (PurchaseOrderDetailModel podm in podms)
            {
                // get the inventory using the item id from purchaseorder detail model
                InventoryModel invm = InventoryRepo.GetInventoryByItemid(podm.Itemid, out error);

                // adding the stock accoring to deliver qty
                invm.Stock += podm.DelivQty;

                // update the inventory
                invm = InventoryRepo.UpdateInventory(invm, out error);


                InventoryTransactionModel invtm = new InventoryTransactionModel();

                invtm.InvID = invm.Invid;
                invtm.ItemID = invm.Itemid;
                invtm.Qty = podm.DelivQty;
                invtm.TransType = ConInventoryTransaction.TransType.PURCHASEORDER_RECEIEVED;
                invtm.TransDate = DateTime.Now;
                invtm.Remark = podm.PoId.ToString();
                invtm = InventoryTransactionRepo.CreateInventoryTransaction(invtm, out error);

            }

            // updating the status
            PurchaseOrderModel pom = PurchaseOrderRepo.UpdatePurchaseOrder(po, out error);
            if (error != "" || pom == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "PO Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(pom);
        }

        // to create new Purchase Order req
        [HttpPost]
        [Route("api/purchaseorder/create")]
        public IHttpActionResult CreatePO(PurchaseOrderModel po)
        {
            string error = "";
            PurchaseOrderModel orm = PurchaseOrderRepo.CreatePurchaseOrder(po, out error);
            if (error != "" || orm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(orm);
        }

        // to get Purchase Order Detail by purchaseorder id
        [HttpGet]
        [Route("api/purchaseorderdetail/{poid}")]
        public IHttpActionResult GetPurchaseOrderDetailById(int poid)
        {
            string error = "";
            List<PurchaseOrderDetailModel> orms =
                PurchaseOrderDetailRepo.GetPurchaseOrderDetailByID(poid, out error);
            if (error != "" || orms == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "PO Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(orms);
        }

        // to get Purchase Order Detail by purchaseorder id and itemid
        [HttpGet]
        [Route("api/purchaseorderdetail/{poid}/{itemid}")]
        public IHttpActionResult GetPurchaseOrderDetailByIdAndItemId(int poid, int itemid)
        {
            string error = "";
            PurchaseOrderDetailModel orm =
                PurchaseOrderDetailRepo.GetPurchaseOrderDetailByIDAndItemID(poid, itemid, out error);
            if (error != "" || orm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "PO Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(orm);
        }

        // to update Purchase Order req details
        [HttpPost]
        [Route("api/purchaseorderdetail/update")]
        public IHttpActionResult UpdatePODetail(PurchaseOrderDetailModel podetail)
        {
            string error = "";
            PurchaseOrderDetailModel ordm =
                PurchaseOrderDetailRepo.UpdatePurchaseOrderDetail(podetail, out error);
            if (error != "" || ordm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "PO Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(ordm);
        }

        // to create new Purchase Order req details
        [HttpPost]
        [Route("api/purchaseorderdetail/create")]
        public IHttpActionResult CreatePODetail(PurchaseOrderDetailModel podetail)
        {
            string error = "";
            PurchaseOrderDetailModel ordm =
                PurchaseOrderDetailRepo.CreatePurchaseOrderDetail(podetail, out error);
            if (error != "" || ordm == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(ordm);
        }
    }
}
