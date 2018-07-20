using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class RequisitionModel

    {
        public RequisitionModel(int reqid, int? rasiedby, String rasiedbyname, 
            int? approvedby, String approvedbyname, int cpid, string cpname,
            int depid, string depname, int status, DateTime? reqdate , List<RequisitionDetailsModel> rdms) {

            this.Reqid = reqid;
            this.Raisedby = rasiedby;
            this.Rasiedbyname = rasiedbyname;
            this.Approvedby = approvedby;
            this.Approvedbyname = approvedbyname;
            this.Cpid = cpid;
            this.Cpname = cpname;
            this.Depid = depid;
            this.Depname = depname;
            this.Status = status;
            this.Reqdate = reqdate;
            this.Requisitiondetails = rdms;


        }
        public RequisitionModel() : this(0, 0, "",0,"", 0, "", 0, "", 0, null , null)
        {
        }

        public int Reqid { get; set; }

        public int? Raisedby { get; set; }

        public String Rasiedbyname { get; set; }

        public int? Approvedby { get; set; }
        public String Approvedbyname { get; set; }

        public int Depid { get; set; }
        public String Depname { get; set; }

        public int Cpid { get; set; }
        public String Cpname { get; set; }

        public int Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Reqdate { get; set; }

        public List<RequisitionDetailsModel> Requisitiondetails { get; set; }
    }
}