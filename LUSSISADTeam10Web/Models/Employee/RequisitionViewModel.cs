using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Employee
{
    public class RequisitionViewModel

    {
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

        public List<RequisitionDetailsViewModel> Requisitiondetails { get; set; }
    }
}