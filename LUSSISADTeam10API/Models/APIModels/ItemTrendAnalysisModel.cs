using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class ItemTrendAnalysisModel
    {
        public string Month { get; set; }
        public int Dept1Data { get; set; }
        public int Dept2Data { get; set; }
        public int Dept3Data { get; set; }
    }
}