using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10API.Models.APIModels;
using LUSSISADTeam10API.Models.DBModels;
using LUSSISADTeam10API.Constants;
namespace LUSSISADTeam10API.Repositories
{
    public class DisbursementDetailsRepo
    {
        // Convert From Auto Generated DB Model to APIModel for Disbursement Details
        private static DisbursementDetailsModel CovertDBDisbursementDetailsstoAPIDisbursementDetails(disbursementdetail disbm)
        {
            DisbursementDetailsModel dism = new DisbursementDetailsModel(disbm.disid, disbm.itemid, disbm.item.description, disbm.qty);
            return dism;
        }
        // Get the list of all Disbursement Details
        public static List<DisbursementDetailsModel> GetAllDisbursementDetails(out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<DisbursementDetailsModel> disbm = new List<DisbursementDetailsModel>();
            try
            {
                // get inventory list from database
                List<disbursementdetail> dism = entities.disbursementdetails.ToList<disbursementdetail>();

                // convert the DB Model list to API Model list
                foreach (disbursementdetail dis in dism)
                {
                    disbm.Add(CovertDBDisbursementDetailsstoAPIDisbursementDetails(dis));
                }
            }

            // if inventory not found, will throw NOTFOUND exception
            catch (NullReferenceException)
            {
                // if there is NULL Exception error, error will be 404
                error = ConError.Status.NOTFOUND;
            }

            catch (Exception e)
            {
                // for other exceptions
                error = e.Message;
            }

            //returning the list
            return disbm;
        }



        // to get the DisbursementDetails by the ItemId
        public static List<DisbursementDetailsModel> GetDisbursementDetailsByItemId(int itemid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<DisbursementDetailsModel> dism = new List<DisbursementDetailsModel>();
            try
            {
                // get requisition list from database
                List<disbursementdetail> disbm = entities.disbursementdetails.Where(p => p.itemid == itemid).ToList<disbursementdetail>();

                // convert the DB Model list to API Model list
                foreach (disbursementdetail dis in disbm)
                {
                    dism.Add(CovertDBDisbursementDetailsstoAPIDisbursementDetails(dis));
                }
            }

            // if requisition not found, will throw NOTFOUND exception
            catch (NullReferenceException)
            {
                // if there is NULL Exception error, error will be 404
                error = ConError.Status.NOTFOUND;
            }

            catch (Exception e)
            {
                // for other exceptions
                error = e.Message;
            }

            //returning the list
            return dism;
        }

        // to get the DisbursementDetails by the DisbursementId
        public static List<DisbursementDetailsModel> GetDisbursementDetailsByDisbursementId(int disid, out string error)
        {
            LUSSISEntities entities = new LUSSISEntities();

            // Initializing the error variable to return only blank if there is no error
            error = "";
            List<DisbursementDetailsModel> dism = new List<DisbursementDetailsModel>();
            try
            {
                // get requisition list from database
                List<disbursementdetail> disbm = entities.disbursementdetails.Where(p => p.disid == disid).ToList<disbursementdetail>();

                // convert the DB Model list to API Model list
                foreach (disbursementdetail dis in disbm)
                {
                    dism.Add(CovertDBDisbursementDetailsstoAPIDisbursementDetails(dis));
                }
            }

            // if requisition not found, will throw NOTFOUND exception
            catch (NullReferenceException)
            {
                // if there is NULL Exception error, error will be 404
                error = ConError.Status.NOTFOUND;
            }

            catch (Exception e)
            {
                // for other exceptions
                error = e.Message;
            }

            //returning the list
            return dism;
        }




    }
}