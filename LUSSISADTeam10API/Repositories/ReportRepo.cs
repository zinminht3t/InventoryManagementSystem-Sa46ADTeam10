using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using LUSSISADTeam10API
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Repositories
{
    public class ReportRepo
    {
        private static ReportModel ConvertDBReporttoAPIreport(ReportModel reportModel)
        {
            ReportModel rm = new ReportModel(reportModel.Description,reportModel.Name,reportModel.Qty,reportModel.Uom);
            return rm;
        }

    //    public static List<ReportModel> MonthlyItemUsageByHOD(out string error)
    //    {
    //        LUSSISEntities entities = new LUSSISEntities();

    //        // Initializing the error variable to return only blank if there is no error
    //        error = "";
    //        List<ReportModel> ims = new List<ReportModel>();
    //        try
    //        {
                

    //            List<ReportModel> rms = entities.

    //            // convert the DB Model list to API Model list
    //            foreach (item item in items)
    //            {
    //                ims.Add(CovertDBItemtoAPIItem(item));
    //            }
    //        }

    }
}