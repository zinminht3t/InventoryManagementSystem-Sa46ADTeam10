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
    public class NotificationController : ApiController
    {
        // to show notification list
        [HttpGet]
        [Route("api/notis")]
        public IHttpActionResult GetAllNoti()
        {
            // declare and initialize error variable to accept the error from Repo
            string error = "";

           
            List<NotificationModel> nms = NotificationRepo.GetAllNoti(out error);
         
            if (error != "" || nms == null)
            {
                // if the error is 404
                if (error == ConError.Status.NOTFOUND)
                    return Content(HttpStatusCode.NotFound, "Purchase Order Not Found");
                // if the error is other one
                return Content(HttpStatusCode.BadRequest, error);
            }
            // if there is no error
            return Ok(nms);

        }
        [HttpGet]
        [Route("api/noti/{notiid}")]
        public IHttpActionResult GetNotificationByid(int notiid)
        {
            string error = "";
            NotificationModel nm = NotificationRepo.GetNotiBynotiid(notiid, out error);
            if (error != "" || nm == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "Notification Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(nm);
        }



        [HttpGet]
        [Route("api/noti/isread/{isread}/{deptid}/{role}")]
        public IHttpActionResult GetNotiByisread(bool isread, int deptid ,int role)
        {
            
            string error = "";
           // isread = ConNotification.IsRead.Read;
            List<NotificationModel> nms =
                NotificationRepo.GetNotiByisread(isread,deptid,role, out error);
            if (error != "" || nms == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "PO Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(nms);
        }


        [HttpGet]
        [Route("api/notification/unread/{isread}/{deptid}/{role}")]
        public IHttpActionResult GetNotiByunread(bool isread, int deptid, int role)
        {

            string error = "";
          //  isread = ConNotification.IsRead.UnRead;
            List<NotificationModel> nms =
                NotificationRepo.GetNotiByisread(isread, deptid, role, out error);
            if (error != "" || nms == null)
            {
                if (error == ConError.Status.NOTFOUND)
                {
                    return Content(HttpStatusCode.NotFound, "PO Not Found");
                }
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(nms);
        }

        [HttpPost]
        [Route("api/notification/create")]
        public IHttpActionResult CreateNoti(NotificationModel noti)
        {
            string error = "";
            NotificationModel notim = NotificationRepo.CreatNotification(noti, out error);
            if (error != "" || notim == null)
            {
                return Content(HttpStatusCode.BadRequest, error);
            }
            return Ok(notim);
        }







    }
}

