using LUSSISADTeam10API.Constants;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using System;
using System.Collections.Generic;
using LUSSISADTeam10API.Models;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Objects;

namespace LUSSISADTeam10API.Repositories
{
    public class ReportRepo
    {
        private static ReportsModel ConvertDBReporttoAPIreport(MonthlyItemUsageByHOD monthlyhod)
        {
            ReportsModel rm = new ReportsModel(monthlyhod.Item, monthlyhod.Category, monthlyhod.Quantity, monthlyhod.Unit_of_Measurement, monthlyhod.deptid, monthlyhod.deptname, monthlyhod.MonthProduce, monthlyhod.YearProduce);
            return rm;
        }

        private static RequsitionListReportModel ConvertDBRequsitionListtoAPI(RequistionList reqlist)
        {
            RequsitionListReportModel reqm = new RequsitionListReportModel(reqlist.reqdate, reqlist.Status, reqlist.deptid);
            return reqm;
        }


        private static MonthlyItemUsageByClerkModel ConvertMonthlyItemUsageByClerktoAPI(MonthItemUsage miuc)
        {
            MonthlyItemUsageByClerkModel iucm = new MonthlyItemUsageByClerkModel(miuc.Item_, miuc.Usage_Item, miuc.Month_Name, miuc.year, miuc.supname, miuc.supid);
            return iucm;
        }


        private static ItemTrendAnalysisModel ConvertItemTrendAnalysis(ItemTrendAnalysi ita)
        {
            ItemTrendAnalysisModel iucm = new ItemTrendAnalysisModel(ita.DepartmentName, ita.Item_Name, ita.Item_Usage, ita.deptid, ita.itemid, ita.Monthofreq, ita.Yearofreq);
            return iucm;
        }

        private static FrequentlyTop5ItemsModel ConvertFrequentlyItem(FrequentlyTop5ItemsDashboard ft)
        {
            FrequentlyTop5ItemsModel fti = new FrequentlyTop5ItemsModel(ft.itemid, ft.description, ft.Total_Order_Qty);
            return fti;
        }

        private static OrderByDepartmentModel ConvertOrderByDepartmentModeltoAPI(OrderByDepartmentDarshboard od)
        {
            OrderByDepartmentModel odm = new OrderByDepartmentModel(od.Total_Order_Qty, od.deptname);
            return odm;
        }

        private static NumberofRequestModel ConvertDBNumberofReqtoAPI(NumberofRequest nur)
        {
            NumberofRequestModel odm = new NumberofRequestModel(nur.deptid, nur.noofrequest, nur.produceyear, nur.producemonth, nur.deptname);
            return odm;
        }

        public static List<PurchaseOrderFor5MonthModel> GetPOFor5Months(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();
            List<PurchaseOrderFor5MonthModel> pomfs = new List<PurchaseOrderFor5MonthModel>();
            List<PurchaseOrderModel> poms = new List<PurchaseOrderModel>();
            List<PurchaseOrderModel> FilteredPoms = new List<PurchaseOrderModel>();
            int count = 0;
            try
            {
                poms = PurchaseOrderRepo.GetPurchaseOrderByStatus(ConPurchaseOrder.Status.RECEIVED, out error);

                if(poms == null)
                {
                    count = 5;
                }

                while(count < 5)
                {
                    PurchaseOrderFor5MonthModel po5m = new PurchaseOrderFor5MonthModel();

                    FilteredPoms = poms.Where(x => x.Podate.Value.Month == (DateTime.Today.Month - count)).ToList();
                    if(FilteredPoms == null || FilteredPoms.Count < 1)
                    {
                        po5m.Month = DateTime.Today.AddMonths((count) * -1).ToString("MMMM");
                        pomfs.Add(po5m);
                    }
                    else
                    {
                        double AllPOTotal = 0;

                        foreach (PurchaseOrderModel pom in FilteredPoms)
                        {
                            double total = 0;
                            foreach (PurchaseOrderDetailModel podm in pom.podms)
                            {
                                double amount = 0;

                                amount = podm.Qty * podm.Price ?? default(double);

                                total += amount;
                            }
                            AllPOTotal += total;
                        }
                        po5m.PurchaseOrderCount = FilteredPoms.Count;
                        po5m.Total = AllPOTotal;
                        po5m.Month = DateTime.Today.AddMonths((count) * -1).ToString("MMMM");
                        pomfs.Add(po5m);
                    }
                    count++;
                }
            }

            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
                pomfs = new List<PurchaseOrderFor5MonthModel>();
            }

            catch (Exception e)
            {
                error = e.Message;
                pomfs = new List<PurchaseOrderFor5MonthModel>();
            }

            return pomfs;
        }





        //public static List<ReportsModel> MonthlyItemUsageByHOD(out string error)
        //{
        //    LUSSISEntities entities = new LUSSISEntities();

        //    // Initializing the error variable to return only blank if there is no error
        //    error = "";
        //    List<ReportsModel> ims = new List<ReportsModel>();
        //    try
        //    {


        //        List<MonthlyItemUsageByHOD> rms = entities.MonthlyItemUsageByHODs.ToList<MonthlyItemUsageByHOD>();

        //        // convert the DB Model list to API Model list
        //        foreach (MonthlyItemUsageByHOD rep in rms)
        //        {
        //            ims.Add(ConvertDBReporttoAPIreport(rep));
        //        }
        //    }
        //    catch (NullReferenceException)
        //    {
        //        error = ConError.Status.NOTFOUND;
        //    }
        //    catch (Exception e)
        //    {
        //        error = e.Message;
        //    }
        //    return ims;
        //}



        //public static List<ReportsModel> MonthlyItemUsageByHODRpt(out string error, int month, int year)
        //{
        //    LUSSISEntities entities = new LUSSISEntities();

        //    // Initializing the error variable to return only blank if there is no error
        //    error = "";
        //    List<ReportsModel> mucbc = new List<ReportsModel>();
        //    try
        //    {


        //        List<MonthlyItemUsageByHOD> rms = entities.MonthlyItemUsageByHODs.Where(p => p.YearProduce == year && p.MonthProduce == month).ToList<MonthlyItemUsageByHOD>();

        //        // convert the DB Model list to API Model list
        //        foreach (MonthlyItemUsageByHOD mtu in rms)
        //        {
        //            mucbc.Add(ConvertDBReporttoAPIreport(mtu));
        //        }
        //    }
        //    catch (NullReferenceException)
        //    {
        //        error = ConError.Status.NOTFOUND;
        //    }
        //    catch (Exception e)
        //    {
        //        error = e.Message;
        //    }
        //    return mucbc;
        //}





        //public static List<RequistionList1> RequsitionList(out string error, int deptid, DateTime fromdate, DateTime todate)
        //{
        //    LUSSISEntities entities = new LUSSISEntities();

        //    // Initializing the error variable to return only blank if there is no error
        //    error = "";
        //    List<RequistionList1> rl = new List<RequistionList1>();


        //    try
        //    {
        //        rl = entities.GetRequistionList(deptid, fromdate, todate).ToList<RequistionList1>();

        //    }
        //    catch (NullReferenceException)
        //    {
        //        error = ConError.Status.NOTFOUND;
        //    }
        //    catch (Exception e)
        //    {
        //        error = e.Message;
        //    }

        //    return rl;
        //}

        //public static List<MonthlyItemUsageByClerkModel> ItemUsageByClerk(out string error,int suppliername1,int suppliername2, int suppliername3, int month)
        //{
        //    LUSSISEntities entities = new LUSSISEntities();

        //    // Initializing the error variable to return only blank if there is no error
        //    error = "";
        //    List<MonthlyItemUsageByClerkModel> mucbc = new List<MonthlyItemUsageByClerkModel>();
        //    List<MonthItemUsage> rms = new List<MonthItemUsage>();

        //    //List<MonthItemUsage> sup1rms = new List<MonthItemUsage>();
        //    //List<MonthItemUsage> sup2rms = new List<MonthItemUsage>();
        //    //List<MonthItemUsage> sup3rms = new List<MonthItemUsage>();




        //    try
        //    {



        //        //sup1rms = 
        //        //    entities.MonthItemUsages.Where(p => p.supid == suppliername1
        //        //    && p.Month_Name == month).ToList<MonthItemUsage>();
        //        //sup2rms =
        //        //    entities.MonthItemUsages.Where(p => (p.supid == suppliername2)
        //        //    && p.Month_Name == month).ToList<MonthItemUsage>();
        //        //sup3rms =
        //        //    entities.MonthItemUsages.Where(p => (p.supid == suppliername3)
        //        //    && p.Month_Name == month).ToList<MonthItemUsage>();



        //        //rms.AddRange(sup1rms);
        //        //rms.AddRange(sup2rms);
        //        //rms.AddRange(sup3rms);


        //        //rms = entities.MonthItemUsages.Where(p => p.Month_Name == month).ToList<MonthItemUsage>();


        //        rms = entities.GetMonthlyItemUsage.T

        //        // convert the DB Model list to API Model list
        //        foreach (MonthItemUsage repl in rms)
        //        {
        //            mucbc.Add(ConvertMonthlyItemUsageByClerktoAPI(repl));
        //        }
        //    }
        //    catch (NullReferenceException)
        //    {
        //        error = ConError.Status.NOTFOUND;
        //    }
        //    catch (Exception e)
        //    {
        //        error = e.Message;
        //    }
        //    return mucbc;
        //}

        //public static List<MonthlyItemUsageByClerkModel> ItemUsageByClerk(out string error)
        //{
        //    LUSSISEntities entities = new LUSSISEntities();

        //    // Initializing the error variable to return only blank if there is no error
        //    error = "";
        //    List<MonthlyItemUsageByClerkModel> mucbc = new List<MonthlyItemUsageByClerkModel>();

        //    try
        //    {


        //        List<MonthItemUsage> rms = entities.MonthItemUsages.ToList<MonthItemUsage>();

        //        // convert the DB Model list to API Model list
        //        foreach (MonthItemUsage repl in rms)
        //        {
        //            mucbc.Add(ConvertMonthlyItemUsageByClerktoAPI(repl));
        //        }
        //    }
        //    catch (NullReferenceException)
        //    {
        //        error = ConError.Status.NOTFOUND;
        //    }
        //    catch (Exception e)
        //    {
        //        error = e.Message;
        //    }
        //    return mucbc;
        //}

        //public static List<ItemTrendAnalysisModel> ItemTrendAnalysis(out string error,int fristdepartname,int seconddepartname, int thirddepartname,int itemid)
        //{
        //    LUSSISEntities entities = new LUSSISEntities();

        //    // Initializing the error variable to return only blank if there is no error
        //    error = "";
        //    List<ItemTrendAnalysisModel> mucbc = new List<ItemTrendAnalysisModel>();

        //    try
        //    {


        //        List<ItemTrendAnalysi> rms = entities.ItemTrendAnalysis.Where(p=>(p.deptid == fristdepartname || p.deptid == seconddepartname || p.deptid == thirddepartname) && p.itemid == itemid).ToList<ItemTrendAnalysi>();

        //        // convert the DB Model list to API Model list
        //        foreach (ItemTrendAnalysi repl in rms)
        //        {
        //            mucbc.Add(ConvertItemTrendAnalysis(repl));
        //        }
        //    }
        //    catch (NullReferenceException)
        //    {
        //        error = ConError.Status.NOTFOUND;
        //    }
        //    catch (Exception e)
        //    {
        //        error = e.Message;
        //    }
        //    return mucbc;
        //}

        //public static List<ItemTrendAnalysisModel> ItemTrendAnalysis(out string error)
        //{
        //    LUSSISEntities entities = new LUSSISEntities();

        //    // Initializing the error variable to return only blank if there is no error
        //    error = "";
        //    List<ItemTrendAnalysisModel> mucbc = new List<ItemTrendAnalysisModel>();

        //    try
        //    {


        //        List<ItemTrendAnalysi> rms = entities.ItemTrendAnalysis.ToList<ItemTrendAnalysi>();

        //        // convert the DB Model list to API Model list
        //        foreach (ItemTrendAnalysi repl in rms)
        //        {
        //            mucbc.Add(ConvertItemTrendAnalysis(repl));
        //        }
        //    }
        //    catch (NullReferenceException)
        //    {
        //        error = ConError.Status.NOTFOUND;
        //    }
        //    catch (Exception e)
        //    {
        //        error = e.Message;
        //    }
        //    return mucbc;
        //}


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



        public static List<NumberofRequestModel> NumberofRequest(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<NumberofRequestModel> noq = new List<NumberofRequestModel>();

            try
            {


                List<NumberofRequest> omdd = entities.NumberofRequests.ToList<NumberofRequest>();

                // convert the DB Model list to API Model list
                foreach (NumberofRequest od in omdd)
                {
                    noq.Add(ConvertDBNumberofReqtoAPI(od));
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
            return noq;
        }

        public static List<MonthlyItemUsage> ItemUsageByClerk(out string error, int sup1, int sup2, int sup3)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<MonthlyItemUsage> mit = new List<MonthlyItemUsage>();

            try
            {

                mit = entities.GetMonthlyItemUsage(sup1, sup2, sup3).ToList<MonthlyItemUsage>();
            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return mit;

        }

        public static List<NumberofRequsition> NumberofRequisition(out string error,int month)
        {
            LUSSISEntities entities = new LUSSISEntities();
             error = "";
            List<NumberofRequsition> nm = new List<NumberofRequsition>();
            try
            {
                nm = entities.GetNumberofRequsition(month).ToList<NumberofRequsition>();
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

        public static List<ItemTrendAnalysis> ItemTrendAnalysis(out string error, int d1, int d2, int d3, int month)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<ItemTrendAnalysis> ita = new List<ItemTrendAnalysis>();
            ItemTrendAnalysis i = new ItemTrendAnalysis();

            try
            {
                ita = entities.GetItemTrendAnalysis(d1, d2, d3, month).ToList<ItemTrendAnalysis>();

            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return ita;
        }

      



        public static List<RequistionList1> RequisitionList(out string error, int deptid, DateTime startdate, DateTime enddate)
        {

            LUSSISEntities entities = new LUSSISEntities();
            List<RequistionList1> rl = new List<RequistionList1>();
            // Initializing the error variable to return only blank if there is no error
            error = "";
            try
            {


                rl = entities.GetRequistionList(deptid, startdate, enddate).ToList<RequistionList1>();


            }
            catch (NullReferenceException)
            {
                error = ConError.Status.NOTFOUND;
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return rl;
        }






    }

}



