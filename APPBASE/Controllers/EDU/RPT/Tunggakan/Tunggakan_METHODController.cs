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
using APPBASE.Svcbiz;


namespace APPBASE.Controllers
{
    public partial class TunggakanController : Controller
    {
        //RESET SESSION
        private void resetSESSIOAN()
        {
            Session[hlpConfig.SessionInfo.getReportdata_inID()] = null;
        } //End private void resetSESSIOAN()
        //UPDATE SESSION
        private void updateSESSIOAN(ReportinVM poViewModel)
        {
            Session[hlpConfig.SessionInfo.getReportdata_inID()] = poViewModel;
        } //End private void updateSESSIOAN()
        //GET SESSION
        private ReportinVM getSESSIOAN()
        {
            if (Session[hlpConfig.SessionInfo.getReportdata_inID()] != null)
            {
                return (ReportinVM)Session[hlpConfig.SessionInfo.getReportdata_inID()];
            } //End if (Session[hlpConfig.SessionInfo.getTransaction_inID()] != null)

            return null;
        } //End private Transaction_indetailVM getSESSIOAN()
    } //End public partial class TunggakanController : Controller
} //End namespace APPBASE.Controllers
