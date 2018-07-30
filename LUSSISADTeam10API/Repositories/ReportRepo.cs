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

        // start zmh
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

                if (poms == null)
                {
                    count = 5;
                }

                while (count < 5)
                {
                    PurchaseOrderFor5MonthModel po5m = new PurchaseOrderFor5MonthModel();

                    FilteredPoms = poms.Where(x => x.Podate.Value.Month == (DateTime.Today.Month - count)).ToList();
                    if (FilteredPoms == null || FilteredPoms.Count < 1)
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
        public static List<ItemTrendAnalysisModel> ItemTrendAnalysis(int d1, int d2, int d3, int category, out string error)
        {
            error = "";
            List<ItemTrendAnalysisModel> itms = new List<ItemTrendAnalysisModel>();
            LUSSISEntities entities = new LUSSISEntities();
            int count = 0;
            List<DepartmentModel> deps = DepartmentRepo.GetAllDepartments(out error);
            try
            {
                while (count < 3)
                {
                    ItemTrendAnalysisModel itm = new ItemTrendAnalysisModel();
                    List<SPItemTrendAnalysis_Result> itar = entities.SPItemTrendAnalysis(DateTime.Today.Month - count, category).ToList();
                    itm.Month = DateTime.Today.AddMonths((count) * -1).ToString("MMMM");
                    if (itar.Count > 0)
                    {
                        List<SPItemTrendAnalysis_Result> itard1 = itar.Where(x => x.deptid == d1).ToList();
                        if(itard1.Count > 0)
                        {
                            itm.Dept1Data = itard1.FirstOrDefault().usage ?? default(int);
                        }
                        else
                        {
                            itm.Dept1Data = 0;
                        }

                        List<SPItemTrendAnalysis_Result> itard2 = itar.Where(x => x.deptid == d2).ToList();
                        if (itard2.Count > 0)
                        {
                            itm.Dept2Data = itard2.FirstOrDefault().usage ?? default(int);
                        }
                        else
                        {
                            itm.Dept2Data = 0;
                        }

                        List<SPItemTrendAnalysis_Result> itard3 = itar.Where(x => x.deptid == d3).ToList();
                        if (itard1.Count > 0)
                        {
                            itm.Dept3Data = itard3.FirstOrDefault().usage ?? default(int);
                        }
                        else
                        {
                            itm.Dept3Data = 0;
                        }
                    }
                    else
                    {
                        itm.Dept1Data = 0;
                        itm.Dept2Data = 0;
                        itm.Dept3Data = 0;
                    }
                    itms.Add(itm);
                    count++;
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
            return itms;
        }

        // end zmh


        // start hwy

        // end hwy

    }

}



