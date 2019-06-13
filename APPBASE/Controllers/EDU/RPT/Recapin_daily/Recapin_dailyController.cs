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
    public partial class Recapin_dailyController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private Reportin_inDS oDS = new Reportin_inDS();
        private Transaction_indDS oDSDetail = new Transaction_indDS();
        private Recapin_daily_Validation oVAL;
        //CLASSTYPE
        private ClasstypeDS oDSClasstype = new ClasstypeDS();
        //STUDENT
        private StudentDS oDSStudent = new StudentDS();

        public void prepareLookup()
        {
            //ViewBag.BRANCHALL = oDSBranchall.getDatalist_lookup();
            //ViewBag.YEAR = oDSYear.getDatalist_lookup();
            //ViewBag.SEMESTER = oDSSemester.getDatalist_lookup();
            ViewBag.CLASSTYPE = oDSClasstype.getDatalist_lookup();
            //ViewBag.CLASSLEVEL = oDSClasslevel.getDatalist_lookup();
            //ViewBag.CLASSROOM = oDSClassroom.getDatalist_lookup();
            //ViewBag.STUDENT = oDSStudent.getDatalist_lookup();
        } //End prepareLookup()
        public void prepareLookupFilter()
        {
            //ViewBag.BRANCHALL = oDSBranchall.getDatalist_lookup();
            //ViewBag.YEAR = oDSYear.getDatalist_lookup();
            //ViewBag.SEMESTER = oDSSemester.getDatalist_lookup();
            ViewBag.CLASSTYPE = oDSClasstype.getDatalist_lookup();
            //ViewBag.CLASSLEVEL = oDSClasslevel.getDatalist_lookup();
            //ViewBag.CLASSROOM = oDSClassroom.getDatalist_lookup();
            //ViewBag.STUDENT = oDSStudent.getDatalist_lookup();
        } //End prepareLookupFilter()

        public ActionResult Index()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            //var oData = oDS.getDatalist();
            //return View(oData);
            ReportinVM oData = new ReportinVM();
            Session[hlpConfig.SessionInfo.getReportdata_inID()] = null;
            prepareLookup();
            return View(oData);
        }

        public ActionResult Reportview_groupbytrintype()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;

            ReportinVM oViewmodel = null;
            if (Session[hlpConfig.SessionInfo.getReportdata_inID()] != null)
            {
                oViewmodel = (ReportinVM)Session[hlpConfig.SessionInfo.getReportdata_inID()];
                oViewmodel.RECAP2 = oDSDetail.getDatalist_detail(oViewmodel.TRN_DT, oViewmodel.CLASSTYPE_ID);
                oViewmodel.TRN_AMOUNT = oDS.TRN_AMOUNT;
                //Session[hlpConfig.SessionInfo.getReportdata_inID()] = oViewmodel;
            } //End if (Session[hlpConfig.SessionInfo.getReportdetail_inID()] != null)

            oViewmodel.RECAP2 = oViewmodel.RECAP2.OrderBy(fld => fld.STUDENT_NAME)
                .ThenBy(fld => fld.TRINTYPE_ID)
                .ThenBy(fld => fld.TRN_DT)
                .ToList();
            Session[hlpConfig.SessionInfo.getReportdata_inID()] = oViewmodel;
            return View(oViewmodel);
        } //End public ActionResult Reportview_groupbytrintype()
        public ActionResult Reportprint_groupbytrintype()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            ReportinVM oViewmodel = null;
            if (Session[hlpConfig.SessionInfo.getReportdata_inID()] != null)
            {
                oViewmodel = (ReportinVM)Session[hlpConfig.SessionInfo.getReportdata_inID()];
            } //End if (Session[hlpConfig.SessionInfo.getReportdetail_inID()] != null)
            return View(oViewmodel);
        } //End public ActionResult Reportprint_groupbytrintype()

        public ActionResult Reportview()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;

            ReportinVM oViewmodel = null;
            if (Session[hlpConfig.SessionInfo.getReportdata_inID()] != null)
            {
                oViewmodel = (ReportinVM)Session[hlpConfig.SessionInfo.getReportdata_inID()];
                oViewmodel.RECAP = oDS.getDatalist(oViewmodel.TRN_DT);
                oViewmodel.TRN_AMOUNT = oDS.TRN_AMOUNT;
                Session[hlpConfig.SessionInfo.getReportdata_inID()] = oViewmodel;
            } //End if (Session[hlpConfig.SessionInfo.getReportdetail_inID()] != null)
            return View(oViewmodel);
        } //End public ActionResult Reportview()

        public ActionResult Reportprint()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            var oData = (ReportinVM)Session[hlpConfig.SessionInfo.getReportdata_inID()];
            Session[hlpConfig.SessionInfo.getReportdata_inID()] = null;
            return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class Recapin_dailyController : Controller
} //End namespace APPBASE.Controllers
