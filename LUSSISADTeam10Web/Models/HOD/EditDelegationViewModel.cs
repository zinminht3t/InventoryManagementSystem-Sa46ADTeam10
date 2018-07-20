using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.HOD
{
    public class EditDelegationViewModel
    {
        public int Deleid { get; set; }
        public int Userid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int assignedby { get; set; }
        public int active { get; set; }
    }
}