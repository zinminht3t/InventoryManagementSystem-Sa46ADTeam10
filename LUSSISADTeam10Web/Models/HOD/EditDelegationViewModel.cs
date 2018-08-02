using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.HOD
{
    public class EditDelegationViewModel
    {
        public int Deleid { get; set; }
        public int Userid { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int assignedby { get; set; }
        public int active { get; set; }
    }
}