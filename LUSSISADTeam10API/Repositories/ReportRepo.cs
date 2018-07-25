using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Repositories
{
    public class ReportRepo
    {
        private static ReportsModel ConvertDBReporttoAPIreport(MonthlyItemUsageByHOD monthlyhod)
        {
            ReportsModel rm = new ReportsModel(monthlyhod.Item, monthlyhod.Category, monthlyhod.Quantity, monthlyhod.Unit_of_Measurement,monthlyhod.deptid,monthlyhod.deptname);
            return rm;
        }

        private static RequsitionListReportModel ConvertDBRequsitionListtoAPI(RequistionList reqlist)
        {
            RequsitionListReportModel reqm = new RequsitionListReportModel(reqlist.reqdate, reqlist.Status, reqlist.deptid);
            return reqm;
        }


        private static MonthlyItemUsageByClerkModel ConvertMonthlyItemUsageByClerktoAPI(MonthItemUsage miuc)
        {
            MonthlyItemUsageByClerkModel iucm = new MonthlyItemUsageByClerkModel(miuc.Item_,miuc.Usage_Item,miuc.Month_Name,miuc.year, miuc.supname, miuc.supid);
            return iucm;
        }


        private static ItemTrendAnalysisModel ConvertItemTrendAnalysis(ItemTrendAnalysi ita)
        {
            ItemTrendAnalysisModel iucm = new ItemTrendAnalysisModel(ita.DepartmentName,ita.Item_Name,ita.Item_Usage,ita.deptid,ita.itemid,ita.Monthofreq,ita.Yearofreq);
            return iucm;
        }

        private static FrequentlyTop5ItemsModel ConvertFrequentlyItem(FrequentlyTop5ItemsDashboard ft)
        {
            FrequentlyTop5ItemsModel fti = new FrequentlyTop5ItemsModel(ft.itemid,ft.description,ft.Total_Order_Qty);
            return fti;
        }

        private static OrderByDepartmentModel ConvertOrderByDepartmentModeltoAPI(OrderByDepartmentDarshboard od)
        {
            OrderByDepartmentModel odm = new OrderByDepartmentModel(od.Total_Order_Qty,od.deptname);
            return odm;
        }



        public static List<ReportsModel> MonthlyItemUsageByHOD(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<ReportsModel> ims = new List<ReportsModel>();
            try
            {


                List<MonthlyItemUsageByHOD> rms = entities.MonthlyItemUsageByHODs.ToList<MonthlyItemUsageByHOD>();

                // convert the DB Model list to API Model list
                foreach (MonthlyItemUsageByHOD rep in rms)
                {
                    ims.Add(ConvertDBReporttoAPIreport(rep));
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
            return ims;
        }


        public static List<RequsitionListReportModel> RequsitionList(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<RequsitionListReportModel> realism = new List<RequsitionListReportModel>();
            try
            {


                List<RequistionList> rms = entities.RequistionLists.ToList<RequistionList>();

                // convert the DB Model list to API Model list
                foreach (RequistionList repl in rms)
                {
                    realism.Add(ConvertDBRequsitionListtoAPI(repl));
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
            return realism;
        }

        public static List<MonthlyItemUsageByClerkModel> ItemUsageByClerk(out string error,int suppliername1,int suppliername2, int suppliername3, int month)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<MonthlyItemUsageByClerkModel> mucbc = new List<MonthlyItemUsageByClerkModel>();
            try
            {


                List<MonthItemUsage> rms = entities.MonthItemUsages.Where(p =>( p.supid == suppliername1 || p.supid == suppliername2 || p.supid == suppliername3 )&& p.Month_Name == month).ToList<MonthItemUsage>();

                // convert the DB Model list to API Model list
                foreach (MonthItemUsage repl in rms)
                {
                    mucbc.Add(ConvertMonthlyItemUsageByClerktoAPI(repl));
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
            return mucbc;
        }

        public static List<MonthlyItemUsageByClerkModel> ItemUsageByClerk(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<MonthlyItemUsageByClerkModel> mucbc = new List<MonthlyItemUsageByClerkModel>();

            try
            {


                List<MonthItemUsage> rms = entities.MonthItemUsages.ToList<MonthItemUsage>();

                // convert the DB Model list to API Model list
                foreach (MonthItemUsage repl in rms)
                {
                    mucbc.Add(ConvertMonthlyItemUsageByClerktoAPI(repl));
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
            return mucbc;
        }

        public static List<ItemTrendAnalysisModel> ItemTrendAnalysis(out string error,int fristdepartname,int seconddepartname, int thirddepartname,int itemid)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<ItemTrendAnalysisModel> mucbc = new List<ItemTrendAnalysisModel>();

            try
            {


                List<ItemTrendAnalysi> rms = entities.ItemTrendAnalysis.Where(p=>(p.deptid == fristdepartname || p.deptid == seconddepartname || p.deptid == thirddepartname) && p.itemid == itemid).ToList<ItemTrendAnalysi>();

                // convert the DB Model list to API Model list
                foreach (ItemTrendAnalysi repl in rms)
                {
                    mucbc.Add(ConvertItemTrendAnalysis(repl));
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
            return mucbc;
        }

        public static List<ItemTrendAnalysisModel> ItemTrendAnalysis(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<ItemTrendAnalysisModel> mucbc = new List<ItemTrendAnalysisModel>();

            try
            {


                List<ItemTrendAnalysi> rms = entities.ItemTrendAnalysis.ToList<ItemTrendAnalysi>();

                // convert the DB Model list to API Model list
                foreach (ItemTrendAnalysi repl in rms)
                {
                    mucbc.Add(ConvertItemTrendAnalysis(repl));
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
            return mucbc;
        }


        public static List<FrequentlyTop5ItemsModel> FrequentlyTop5Items(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<FrequentlyTop5ItemsModel> ftfiveI = new List<FrequentlyTop5ItemsModel>();

            try
            {


                List<FrequentlyTop5ItemsDashboard> ftfive = entities.FrequentlyTop5ItemsDashboard.ToList<FrequentlyTop5ItemsDashboard>();

                // convert the DB Model list to API Model list
                foreach (FrequentlyTop5ItemsDashboard ft in ftfive)
                {
                    ftfiveI.Add(ConvertFrequentlyItem(ft));
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
            return ftfiveI;
        }



        public static List<OrderByDepartmentModel> OrderByDept(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<OrderByDepartmentModel> odm = new List<OrderByDepartmentModel>();

            try
            {


                List<OrderByDepartmentDarshboard> omdd = entities.OrderByDepartmentDarshboards.ToList<OrderByDepartmentDarshboard>();

                // convert the DB Model list to API Model list
                foreach (OrderByDepartmentDarshboard od in omdd)
                {
                    odm.Add(ConvertOrderByDepartmentModeltoAPI(od));
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
            return odm;
        }

    }

}

   
    
