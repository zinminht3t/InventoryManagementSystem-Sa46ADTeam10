using LUSSISADTeam10Web.API;
using LUSSISADTeam10Web.Constants;
using LUSSISADTeam10Web.Models;
using LUSSISADTeam10Web.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LUSSISADTeam10Web.Controllers
{
    public class HODController : Controller
    {
        // GET: HOD
        public ActionResult Index()
        {
            return View("HODDashboard");
        }

        // Start AM

        // End AM

        // Start Phyo2

        public ActionResult GetRequsitionApporRej(int reqid)
        {
             string error = "";
             string token = "QvYxJISfdbvAZ5L6tBTI52hMTZ_Gowj7LIv57m3d87ej6zhPP96f2qxaSio9S5_hWKbd8XJFEVmbdxBlDTfiXXvYgqyEmQkFQD8lQNqXovK2jh7mMUphmoQrdqnJekFmSguzG7kpYHC36zQla4WWDx7urd71jQ2nHOcnOKPgBvkEidsLXQ9qsRx2hW7kxnvI7vuYZk2oGEfk_EZeHc5O_RFRek3Pp9GhJSOO05yznpnQfBK4j81898XuvzVYdsYTb_FhnTNAyzjrtlPa4rBf0FZGhqFN7Q9ja13dwNoX8PV2x_eU2VN-dDG_HxFpMJkCA15SKK73mjk3oW4HQwT3SXkYgFRjPFlyT-MYD8Cdr4g";
            RequisitionModel reqms = APIRequisition.GetRequisitionByReqid(reqid, token, out error);
            return View(reqms);
        }

        // End Phyo2

        // Start MaHSU

        // End MaHsu

        // Start TAZ

        // ENd TAZ

        // Start ZMH

        // End ZMH

    }
}