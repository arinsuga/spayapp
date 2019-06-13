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
using Omu.ValueInjecter;

namespace APPBASE.Controllers
{
    [MyActionFilterAttribute]
    public partial class Transaction_inController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        //DS
        private Transaction_inDS oDS = new Transaction_inDS();
        private Transaction_indDS oDSDetail = new Transaction_indDS();
        //CRUD
        private Transaction_inCRUD oCRUD = new Transaction_inCRUD();
        private Transaction_indCRUD oCRUDDetail = new Transaction_indCRUD();
        //VAL
        private Transaction_in_Validation oVAL;

        //SYSINFO
        private SysinfoDS oDSSysinfo = new SysinfoDS();
        //CONFIG YEAR
        private YearDS oDSYear = new YearDS();
        //STUDENT
        private StudentDS oDSStudent = new StudentDS();
        //TRINTYPE
        private TrintypeDS oDSTrintype = new TrintypeDS();
        //CLASSLEVEL
        private ClasslevelDS oDSClasslevel = new ClasslevelDS();
        //CONFIG MONTHSPP
        private MonthsppDS oDSMonthspp = new MonthsppDS();
        //Installment
        private Installment_inDS oDSInstallment = new Installment_inDS();
        
        public void prepareLookup()
        {
            //ViewBag.CITY = oDSCity.getDatalist_lookup();
            //ViewBag.GENDER = oDSGender.getDatalist_lookup();
            //ViewBag.RELIGION = oDSReligion.getDatalist_lookup();
            //ViewBag.EDUCATION = oDSEducation.getDatalist_lookup();
            //ViewBag.JOBTYPE = oDSJobtype.getDatalist_lookup();
            //ViewBag.BLOODTYPE = oDSBloodtype.getDatalist_lookup();

            //ViewBag.BRANCHALL = oDSBranchall.getDatalist_lookup();
            //ViewBag.YEAR = oDSYear.getDatalist_lookup();
            //ViewBag.SEMESTER = oDSSemester.getDatalist_lookup();
            //ViewBag.CLASSTYPE = oDSClasstype.getDatalist_lookup();
            //ViewBag.CLASSLEVEL = oDSClasslevel.getDatalist_lookup();
            //ViewBag.CLASSROOM = oDSClassroom.getDatalist_lookup();
            //ViewBag.STUDENTSTS = oDSStudentsts.getDatalist_lookup();
            ViewBag.STUDENT = oDSStudent.getDatalist_lookup2();
            ViewBag.TRINTYPE = oDSTrintype.getDatalist_lookup();
        } //End prepareLookup()
        public void prepareLookupFilter()
        {
            //ViewBag.BRANCHALL = oDSBranchall.getDatalist_lookup();
            //ViewBag.CLASSTYPE = oDSClasstype.getDatalist_lookup();
            //ViewBag.CLASSLEVEL = oDSClasslevel.getDatalist_lookup();
            //ViewBag.CLASSROOM = oDSClassroom.getDatalist_lookup();
        } //End prepareLookupFilter()
        public void prepareData(Transaction_indetailVM poViewModel)
        {
            Transaction_indetailVM oViewModel = poViewModel;

            ViewBag.TRINHIST = oDSDetail.getDatalist_detail(oViewModel.STUDENT_ID, oViewModel.TRINTYPE_ID, oViewModel.YEAR_FROM, oViewModel.YEAR_TO);
        } //End public void prepareData()

        public ActionResult Index()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            //var oData = oDS.getDatalist();
            //return View(oData);

            Session[hlpConfig.SessionInfo.sSESSIONID_ISBACKDATE] = "";
            Session[hlpConfig.SessionInfo.getTransaction_methodID()] = null;
            Session[hlpConfig.SessionInfo.getTransactionView_inID()] = null;
            if (Session[hlpConfig.SessionInfo.getTransaction_inID()] != null) return RedirectToAction("Create");

            Transaction_indetailVM oData = new Transaction_indetailVM();
            prepareLookup();
            return View(oData);
        }

        public ActionResult Indexbackdate()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            //var oData = oDS.getDatalist();
            //return View(oData);
            Session[hlpConfig.SessionInfo.sSESSIONID_ISBACKDATE] = "";
            Session[hlpConfig.SessionInfo.getTransaction_methodID()] = null;
            Session[hlpConfig.SessionInfo.getTransactionView_inID()] = null;
            if (Session[hlpConfig.SessionInfo.getTransaction_inID()] != null) return RedirectToAction("Create");

            Transaction_indetailVM oData = new Transaction_indetailVM();
            prepareLookup();
            oData.TRN_DT = DateTime.Now;
            return View(oData);
        }

        public ActionResult Details(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(oData);
        }
        public ActionResult Create()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;

            Transaction_indetailVM oModel = new Transaction_indetailVM();
            if (Session[hlpConfig.SessionInfo.getTransaction_inID()] != null) {

                oModel = (Transaction_indetailVM)Session[hlpConfig.SessionInfo.getTransaction_inID()];
            } //End if (Session[hlpConfig.SessionInfo.getTransaction_inID()] != null)
            //Calculate Transaction
            oModel.TRN_AMOUNT = 0;
            if (oModel.DETAIL != null)
            {
                foreach (var item in oModel.DETAIL)
                {
                    if (item.TRND_AMOUNT != null)
                        oModel.TRN_AMOUNT = oModel.TRN_AMOUNT + item.TRND_AMOUNT;
                } //End foreach (var item in oModel.DETAIL)
            } //End if (oModel.DETAIL != null)

            prepareLookup();

            //Cleanup installment
            if (oModel.INSTLIST != null) oModel.INSTLIST.RemoveAll(fld => fld.INST_TYPEID == null);
            if (oModel.MONTHLY_INST_SPP != null) if (oModel.MONTHLY_INST_SPP.INST_TYPEID == null)
                    oModel.MONTHLY_INST_SPP = null;
            if (oModel.MONTHLY_INST_SCLUB != null) if (oModel.MONTHLY_INST_SCLUB.INST_TYPEID == null)
                    oModel.MONTHLY_INST_SCLUB = null;
            if (oModel.MONTHLY_INST_EKSKUL != null) if (oModel.MONTHLY_INST_EKSKUL.INST_TYPEID == null)
                    oModel.MONTHLY_INST_EKSKUL = null;

            return View(oModel);
        }
        public ActionResult Edit(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_UPDATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(oData);
        }
        public ActionResult Delete(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_DELETE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(oData);
        }

        public ActionResult Reportview_last()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            var oData = oDS.getData_last();
            oData.DETAIL = oDSDetail.getDatalist_detail(oData.ID);
            //return View(oData);
            return View("Reportprint", oData);
        }
        public ActionResult Reportview()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            if (Session[hlpConfig.SessionInfo.getTransactionView_inID()] == null) { return RedirectToAction("Index"); } //End if (Session[hlpConfig.SessionInfo.getTransactionView_inID()] == null)
            Transaction_indetailVM oViewmodel = (Transaction_indetailVM)Session[hlpConfig.SessionInfo.getTransactionView_inID()];

            var oData = oDS.getData(oViewmodel.ID);
            oData.DETAIL = oDSDetail.getDatalist_detail(oData.ID);
            return View(oData);
        }
        public ActionResult Reportprint()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_INDEX;
            if (Session[hlpConfig.SessionInfo.getTransactionView_inID()] == null) { return RedirectToAction("Index"); } //End if (Session[hlpConfig.SessionInfo.getTransactionView_inID()] == null)
            Transaction_indetailVM oViewmodel = (Transaction_indetailVM)Session[hlpConfig.SessionInfo.getTransactionView_inID()];

            var oData = oDS.getData(oViewmodel.ID);
            oData.DETAIL = oDSDetail.getDatalist_detail(oData.ID);
            return View(oData);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class Transaction_inController : Controller
} //End namespace APPBASE.Controllers
