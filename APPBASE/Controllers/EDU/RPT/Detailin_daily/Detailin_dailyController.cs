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
    public partial class Detailin_dailyController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private Transaction_indDS oDS = new Transaction_indDS();
        private Detailin_daily_Validation oVAL;
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
            ViewBag.STUDENT = oDSStudent.getDatalist_lookup();
        } //End prepareLookup()
        public void prepareLookupFilter()
        {
            //ViewBag.BRANCHALL = oDSBranchall.getDatalist_lookup();
            //ViewBag.YEAR = oDSYear.getDatalist_lookup();
            //ViewBag.SEMESTER = oDSSemester.getDatalist_lookup();
            ViewBag.CLASSTYPE = oDSClasstype.getDatalist_lookup();
            //ViewBag.CLASSLEVEL = oDSClasslevel.getDatalist_lookup();
            //ViewBag.CLASSROOM = oDSClassroom.getDatalist_lookup();
            ViewBag.STUDENT = oDSStudent.getDatalist_lookup();
        } //End prepareLookupFilter()

        public ActionResult Index()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            ReportinVM oData = new ReportinVM();
            Session[hlpConfig.SessionInfo.getReportdata_inID()] = null;
            prepareLookup();
            return View(oData);
        }
        public ActionResult Reportview()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            ReportinVM oViewmodel = null;
            if (Session[hlpConfig.SessionInfo.getReportdata_inID()] != null)
            {
                oViewmodel = (ReportinVM)Session[hlpConfig.SessionInfo.getReportdata_inID()];
                if (oViewmodel.STUDENT_ID != null)
                { oViewmodel.DETAIL = oDS.getDatalist_detail(oViewmodel.TRN_DT, oViewmodel.CLASSTYPE_ID, oViewmodel.STUDENT_ID); }
                else { oViewmodel.DETAIL = oDS.getDatalist_detail(oViewmodel.TRN_DT, null, oViewmodel.STUDENT_ID); }

                Session[hlpConfig.SessionInfo.getReportdata_inID()] = oViewmodel;
            } //End if (Session[hlpConfig.SessionInfo.getReportdetail_inID()] != null)

            if (oViewmodel.DETAIL.Count > 0)
            {
                //YEAR
                oViewmodel.CACHE_YEAR_CODE = oViewmodel.DETAIL[0].CACHE_YEAR_CODE;
                oViewmodel.CACHE_YEAR_SHORTDESC = oViewmodel.DETAIL[0].CACHE_YEAR_SHORTDESC;
                oViewmodel.CACHE_YEAR_DESC = oViewmodel.DETAIL[0].CACHE_YEAR_DESC;
                oViewmodel.CACHE_YEAR_FROM = oViewmodel.DETAIL[0].CACHE_YEAR_FROM;
                oViewmodel.CACHE_YEAR_TO = oViewmodel.DETAIL[0].CACHE_YEAR_TO;
                //CLASSTYPE
                oViewmodel.CLASSTYPE_ID = oViewmodel.DETAIL[0].CLASSTYPE_ID;
                oViewmodel.CLASSTYPE_CODE = oViewmodel.DETAIL[0].CLASSTYPE_CODE;
                oViewmodel.CLASSTYPE_SHORTDESC = oViewmodel.DETAIL[0].CLASSTYPE_SHORTDESC;
                oViewmodel.CLASSTYPE_DESC = oViewmodel.DETAIL[0].CLASSTYPE_DESC;
                oViewmodel.CLASSTYPE_NUM = oViewmodel.DETAIL[0].CLASSTYPE_NUM;
            } //End if ((oViewmodel.DETAIL.Count > 0) && (oViewmodel.DETAIL !=null))

            return View(oViewmodel);
        }
        public ActionResult Reportprint()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            ReportinVM oViewmodel = null;
            if (Session[hlpConfig.SessionInfo.getReportdata_inID()] != null)
            {
                oViewmodel = (ReportinVM)Session[hlpConfig.SessionInfo.getReportdata_inID()];
            } //End if (Session[hlpConfig.SessionInfo.getReportdetail_inID()] != null)
            return View(oViewmodel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class Detailin_dailyController : Controller
} //End namespace APPBASE.Controllers
