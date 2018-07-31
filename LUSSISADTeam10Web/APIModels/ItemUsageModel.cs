using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.APIModels
{
    public class ItemUsageModel
    {
        public ItemUsageModel(string month, int Sup1Data, int Sup2Data, int Sup3Data)
        {
            Month = month;
            this.Sup1Data = Sup1Data;
            this.Sup2Data = Sup2Data;
            this.Sup3Data = Sup3Data;
        }
        public ItemUsageModel() : this("", 0, 0, 0) { }
        public string Month { get; set; }
        public int Sup1Data { get; set; }
        public int Sup2Data { get; set; }
        public int Sup3Data { get; set; }
    }
}