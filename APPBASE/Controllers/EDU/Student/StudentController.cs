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
//using APPBASE.Svcapp;
using APPBASE.Svcbiz;

namespace APPBASE.Controllers
{
    [MyActionFilterAttribute]
    public partial class StudentController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private StudentDS oDS = new StudentDS();
        private StudentCRUD oCRUD = new StudentCRUD();
        private Student_Validation oVAL;
        //DS CFG
        //private BranchallDS oDSBranchall = new BranchallDS();
        private YearDS oDSYear = new YearDS();
        private SemesterDS oDSSemester = new SemesterDS();
        private ClasstypeDS oDSClasstype = new ClasstypeDS();
        private ClasslevelDS oDSClasslevel = new ClasslevelDS();
        private ClassroomDS oDSClassroom = new ClassroomDS();
        //DS LOV
        private CityDS oDSCity = new CityDS();
        private GenderDS oDSGender = new GenderDS();
        private ReligionDS oDSReligion = new ReligionDS();
        private EducationDS oDSEducation = new EducationDS(); 
        private JobtypeDS oDSJobtype = new JobtypeDS();
        private BloodtypeDS oDSBloodtype = new BloodtypeDS();
        private StudentstsDS oDSStudentsts = new StudentstsDS();

        public void prepareLookup(){
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
            ViewBag.CLASSLEVEL = oDSClasslevel.getDatalist_lookup();
            ViewBag.CLASSROOM = oDSClassroom.getDatalist_lookup();
            ViewBag.STUDENTSTS = oDSStudentsts.getDatalist_lookup();
        } //End prepareLookup()
        public void prepareLookupFilter()
        {
            //ViewBag.BRANCHALL = oDSBranchall.getDatalist_lookup();
            //ViewBag.CLASSTYPE = oDSClasstype.getDatalist_lookup();
            //ViewBag.CLASSLEVEL = oDSClasslevel.getDatalist_lookup();
            ViewBag.CLASSROOM = oDSClassroom.getDatalist_lookup();
        } //End prepareLookupFilter()

        public ActionResult Index()
        {
            //ViewBag.AC_MENU_ID = valMENU.TATAUSAHA_SISWA_INDEX;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];
            ViewBag.CRUDAction = TempData["CRUDAction"];

            var oData = new StudentVM();
            prepareLookupFilter();
            return View(oData);
        }

        public ActionResult Details(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.TATAUSAHA_SISWA_DETAILS;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            StudentVM oData = new StudentVM();
            oData.DETAIL = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(oData);
        }


        public ActionResult Create()
        {
            //ViewBag.AC_MENU_ID = valMENU.TATAUSAHA_SISWA_CREATE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            StudentVM oData = new StudentVM();
            oData.DETAIL = new StudentdetailVM();
            prepareLookup();

            return View(oData);
        }

        public ActionResult Edit(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.TATAUSAHA_SISWA_EDIT;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            StudentVM oData = new StudentVM();
            oData.DETAIL = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(oData);
        }

        public ActionResult Delete(int? id = null)
        {
            //ViewBag.AC_MENU_ID = valMENU.TATAUSAHA_SISWA_DELETE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            StudentVM oData = new StudentVM();
            oData.DETAIL = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            prepareLookup();
            return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class StudentController : Controller
} //End namespace APPBASE.Controllers
