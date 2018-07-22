using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class DisbursementLockerModel
    {
        public DisbursementLockerModel(int disID, int reqID, int lockerID, DateTime deliveredDate, DateTime? collectedDate, byte status)
        {
            DisID = disID;
            ReqID = reqID;
            LockerID = lockerID;
            DeliveredDate = deliveredDate;
            CollectedDate = collectedDate;
            Status = status;
        }

        public DisbursementLockerModel() : this(0, 0, 0, new DateTime(), new DateTime(), 0) { }

        public int DisID { get; set; }
        public int ReqID { get; set; }
        public int LockerID { get; set; }
        public DateTime DeliveredDate { get; set; }
        public DateTime? CollectedDate { get; set; }
        public byte Status { get; set; }
    }
}