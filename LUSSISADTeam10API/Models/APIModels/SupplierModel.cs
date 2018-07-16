using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10API.Constants;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class SupplierModel
    {
        public SupplierModel
            (int SupId,
            string SupName,
            string SupEmail,
            int? SupPhone,
            string ContactName,
            string GstRegNo,
            int Active)
        {
            this.SupId = SupId;
            this.SupName = SupName;
            this.SupEmail = SupEmail;
            this.SupPhone = SupPhone;
            this.ContactName = ContactName;
            this.GstRegNo = GstRegNo;
            this.Active = Active;
        }

        public SupplierModel() :
            this(0, "", "", 0, "", "", ConCommon.Active.INACTIVE)
        {
        }

        public int SupId { get; set; }

        public string SupName { get; set; }

        public string SupEmail { get; set; }

        public int? SupPhone { get; set; }

        public string ContactName { get; set; }

        public string GstRegNo { get; set; }

        public int Active { get; set; }
    }
}