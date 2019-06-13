using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APPBASE.Models;
using APPBASE.Helpers;
using APPBASE.Filters;
using APPBASE.Svcapp;

namespace APPBASE.Controllers
{
    public partial class Recapin_dailyController : Controller
    {
        [HttpPost]
        public ActionResult Index(ReportinVM poViewModel)
        {
            //Set ViewModel
            Session[hlpConfig.SessionInfo.getReportdata_inID()] = poViewModel;
            //return RedirectToAction("Reportview");
            return RedirectToAction("Reportview_groupbytrintype");
        }
    } //End public partial class Recapin_dailyController : Controller
} //End namespace APPBASE.Controllers
