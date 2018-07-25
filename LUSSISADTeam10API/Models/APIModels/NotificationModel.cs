using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace LUSSISADTeam10API.Models.APIModels
{
    public class NotificationModel
    {
        public NotificationModel(int notiID, DateTime datetime, int deptid, int role, string title, string remark, bool isread, int n, int r)
        {
            NotiID = notiID;
            Datetime = datetime;
            Deptid = deptid;
            Role = role;
            Title = title;
            Remark = remark;
            Isread = isread;
            NotiType = n;
            ResID = r;
        }

        public NotificationModel():this(0, new DateTime(), 0, 0, "", "",true, 0, 0) { }

        public int NotiID { get; set; }
        public DateTime  Datetime{ get; set; }

        public int Deptid  { get; set; }

        public int Role { get; set; }

        public string Title { get; set; }

        public string Remark { get; set; }

        public bool Isread { get; set; }
        public int ResID { get; set; }
        public int NotiType { get; set; }
    }
}