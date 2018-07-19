using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Repositories
{
    public class NotificationRepo
    {
        private static NotificationModel CovertDBNotitoAPINoti(notification noti)
        {
            NotificationModel nm = new NotificationModel(noti.notiid,noti.datetime,noti.deptid,noti.role,noti.title,noti.remark,noti.isread);
            return nm;
        }
        
        public static List<NotificationModel> GetAllNoti(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<NotificationModel> nms = new List<NotificationModel>();
            try
            {
                // get department list from database
                List<notification> notis = entities.notifications.ToList<notification>();

                // convert the DB Model list to API Model list
                foreach (notification noti in notis)
                {
                    nms.Add(CovertDBNotitoAPINoti(noti));
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
            return nms;
        }

        public static NotificationModel GetNotiBynotiid(int notiid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";

            notification noti = new notification();
            NotificationModel nm = new NotificationModel();
            try
            {
                noti = entities.notifications.Where(p => p.notiid == notiid).FirstOrDefault<notification>();
                nm = CovertDBNotitoAPINoti(noti);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return nm;
        }


        public static List<NotificationModel> GetNotiByisread(bool isread,int deptid, int role, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            error = "";
            List<notification> no = new List<notification>();
            notification noti = new notification();
            List<NotificationModel> nm = new List<NotificationModel>();
            try
            {
                no = entities.notifications.Where(p => p.isread == isread && p.deptid == deptid && p.role == role).ToList<notification>();

                foreach (notification notii in no)
                {
                    nm.Add(CovertDBNotitoAPINoti(notii));
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
            return nm;
        }


        public static NotificationModel CreatNotification(NotificationModel nm, out string error)
        {
            error = "";
            LUSSISEntities entities = new LUSSISEntities();
            notification n = new notification();
            try
            {
                n.datetime = nm.Datetime;
                n.deptid = nm.Deptid;
                n.role = nm.Role;
                n.title = nm.Title;
                n.remark = nm.Remark;
                n.isread = nm.Isread;
                n = entities.notifications.Add(n);
                entities.SaveChanges();
                nm = CovertDBNotitoAPINoti(n);
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return nm;
        }



    }
}