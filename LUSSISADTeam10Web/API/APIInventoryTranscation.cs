using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSISADTeam10Web.Models.APIModels;
using Newtonsoft.Json;
using RestSharp;

namespace LUSSISADTeam10Web.API
{
    public class APIInventoryTranscation
    {
        public static List<InventoryTransactionModel> GetAllInventoryTransactions(string token, out string error)
        {
            string url = APIHelper.Baseurl + "/inventorytransactions/";
            List<InventoryTransactionModel> invtrans = APIHelper.Execute<List<InventoryTransactionModel>>(token, url, out error);
            return invtrans;
        }

        public static InventoryTransactionModel GetInventoryTransactionByInvtID(string token, int invtranid, out string error)
        {
            string url = APIHelper.Baseurl + "/inventorytransaction/" + invtranid;
            InventoryTransactionModel invtran = APIHelper.Execute<InventoryTransactionModel>(token, url, out error);
            return invtran;
        }

        public static List<InventoryTransactionModel> GetInventoryTransactionByInvID(int invid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/inventorytransaction/inventory/" + invid;
            List<InventoryTransactionModel> invtrans = APIHelper.Execute<List<InventoryTransactionModel>>(token, url, out error);
            return invtrans;
        }


        public static List<InventoryTransactionModel> GetInventoryTransactionByItemID(int itemid, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/inventorytransaction/item/" + itemid;
            List<InventoryTransactionModel> invtrans = APIHelper.Execute<List<InventoryTransactionModel>>(token, url, out error);
            return invtrans;
        }


        public static List<InventoryTransactionModel> GetInventoryTransactionByTransType(int transtype, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/inventorytransaction/transtype/" + transtype;
            List<InventoryTransactionModel> invtrans = APIHelper.Execute<List<InventoryTransactionModel>>(token, url, out error);
            return invtrans;
        }

        public static List<InventoryTransactionModel> GetInventoryTransactionByTransDate(DateTime transdate, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/inventorytransaction/transdate/" + transdate;
            List<InventoryTransactionModel> invtrans = APIHelper.Execute<List<InventoryTransactionModel>>(token, url, out error);
            return invtrans;
        }


        public static List<InventoryTransactionModel> GetInventoryTransactionByTransDate(DateTime startdate,DateTime enddate, string token, out string error)
        {
            string url = APIHelper.Baseurl + "/inventorytransaction/transdaterange/" + startdate + enddate;
            List<InventoryTransactionModel> invtrans = APIHelper.Execute<List<InventoryTransactionModel>>(token, url, out error);
            return invtrans;
        }

        public static InventoryTransactionModel UpdateInventoryTransaction(string token, InventoryTransactionModel itm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/inventorytransaction/update";
            string objectstring = JsonConvert.SerializeObject(itm);
            itm = APIHelper.Execute<InventoryTransactionModel>(token, objectstring, url, out error);
            return itm;
        }


        public static InventoryTransactionModel CreateInventoryTransaction(string token, InventoryTransactionModel itm, out string error)
        {
            error = "";
            string url = APIHelper.Baseurl + "/inventorytransaction/create";
            string objectstring = JsonConvert.SerializeObject(itm);
            itm = APIHelper.Execute<InventoryTransactionModel>(token, objectstring, url, out error);
            return itm;
        }











    }
}