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
    [MyActionFilterAttribute]
    public partial class TunggakanController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private Transaction_indDS oDS = new Transaction_indDS();
        private Detailin_daily_Validation oVAL;
        //STUDENT
        private StudentDS oDSStudent = new StudentDS();
        //CLASSTYPE
        private ClasstypeDS oDSClasstype = new ClasstypeDS();
        //CLASSLEVEL
        private ClasslevelDS oDSClasslevel = new ClasslevelDS();
        //MONTHS
        private MonthsppDS oDSMonths = new MonthsppDS();

        public void prepareLookup()
        {
            //ViewBag.BRANCHALL = oDSBranchall.getDatalist_lookup();
            //ViewBag.YEAR = oDSYear.getDatalist_lookup();
            //ViewBag.SEMESTER = oDSSemester.getDatalist_lookup();
            ViewBag.CLASSTYPE = oDSClasstype.getDatalist_lookup();
            ViewBag.CLASSLEVEL = oDSClasslevel.getDatalist_lookup();
            //ViewBag.CLASSROOM = oDSClassroom.getDatalist_lookup();
            ViewBag.MONTHS = oDSMonths.getDatalist_lookup();
        } //End prepareLookup()
        public void prepareLookupFilter()
        {
            //ViewBag.BRANCHALL = oDSBranchall.getDatalist_lookup();
            //ViewBag.YEAR = oDSYear.getDatalist_lookup();
            //ViewBag.SEMESTER = oDSSemester.getDatalist_lookup();
            ViewBag.CLASSTYPE = oDSClasstype.getDatalist_lookup();
            ViewBag.CLASSLEVEL = oDSClasslevel.getDatalist_lookup();
            //ViewBag.CLASSROOM = oDSClassroom.getDatalist_lookup();
            ViewBag.MONTHS = oDSMonths.getDatalist_lookup();
        } //End prepareLookupFilter()

        public ActionResult Index()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            ReportinVM oData = new ReportinVM();
            //Session[hlpConfig.SessionInfo.getReportdata_inID()] = null;
            this.resetSESSIOAN();

            prepareLookup();
            return View(oData);
        }
        public ActionResult Reportview()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            ReportinVM oViewmodel = null;
            //if (Session[hlpConfig.SessionInfo.getReportdata_inID()] != null)
            if (this.getSESSIOAN() != null)
            {
                //GET SESSION
                oViewmodel = this.getSESSIOAN();
                //EXECUTE REPORT
                oViewmodel.executeReport_TUNGGAKAN();
                //UPDATE SESSION
                //updateSESSIOAN(oViewmodel);
                //RESET SESSION
                this.resetSESSIOAN();
            } //End if (Session[hlpConfig.SessionInfo.getReportdetail_inID()] != null)

            if (oViewmodel==null) return RedirectToAction("Index");

            //VIEW REPORT
            return View(oViewmodel);
        }
        public ActionResult Reportprint()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;

            //Get Session
            var oData = this.getSESSIOAN();
            //Reset Session
            this.resetSESSIOAN();
            return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class TunggakanController : Controller
} //End namespace APPBASE.Controllers
