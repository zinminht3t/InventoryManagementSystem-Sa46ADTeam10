using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10Web.Models.Report
{
    public class ItemTrendAnalysisModel
    {
        public ItemTrendAnalysisModel(string month, int dept1Data, int dept2Data, int dept3Data)
        {
            Month = month;
            Dept1Data = dept1Data;
            Dept2Data = dept2Data;
            Dept3Data = dept3Data;
        }
        public ItemTrendAnalysisModel() : this("",0,0,0) { }
        public string Month { get; set; }
        public int Dept1Data { get; set; }
        public int Dept2Data { get; set; }
        public int Dept3Data { get; set; }
    }
}