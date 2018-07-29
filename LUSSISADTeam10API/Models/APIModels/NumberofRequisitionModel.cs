using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LUSSISADTeam10API.Models.APIModels
{
    public class NumberofRequisitionModel
    {
        public NumberofRequisitionModel(int numofreq,int reqid,string deptname)
        {
            NumberofReq = numofreq;
            Reqid = reqid;
            Deptname = deptname;

        }

        public NumberofRequisitionModel() :this (0,0,"") {}

        public int NumberofReq { get; set; }
        public int Reqid { get; set; }
        public string Deptname { get; set; }


    }
}