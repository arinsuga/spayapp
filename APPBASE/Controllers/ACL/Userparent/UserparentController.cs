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
    public partial class UserparentController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private UserDS oDS = new UserDS();
        private UserCRUD oCRUD = new UserCRUD();
        private UserPARENT_Validation oVAL;

        public int? ROLE_ID { get; set; }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            ViewBag.AC_MENU_ID = valMENU.HAKAKSES_USERPARENT_INDEX;

            var oData = oDS.getDatalist_Parent();
            return View(oData);
        }
        public ActionResult Details(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.HAKAKSES_USERPARENT_DETAILS;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            var oData = oDS.getDataPARENT(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Create()
        {
            ViewBag.AC_MENU_ID = valMENU.HAKAKSES_USERPARENT_CREATE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            return View();
        }
        public ActionResult Edit(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.HAKAKSES_USERPARENT_EDIT;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getDataPARENT(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Delete(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.HAKAKSES_USERPARENT_DELETE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            var oData = oDS.getDataPARENT(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Activate(string id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.HAKAKSES_USERPARENT_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            //var oData = oDS.getDataCPAR(id);
            //if (oData == null) { return HttpNotFound(); }
            //if (oData.BP_STS == valFLAG.FLAG_ACTIVE) { oData.BP_STS_NM = lblFIELD.USR_STS_ACTIVE; }
            //else { oData.BP_STS_NM = lblFIELD.USR_STS_INACTIVE; }

            //return View(oData);
            return View();
        }
        public ActionResult Deactivate(string id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.HAKAKSES_USERPARENT_DELETE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            //var oData = oDS.getDataCPAR(id);
            //if (oData == null) { return HttpNotFound(); }
            //if (oData.BP_STS == valFLAG.FLAG_ACTIVE) { oData.BP_STS_NM = lblFIELD.USR_STS_ACTIVE; }
            //else { oData.BP_STS_NM = lblFIELD.USR_STS_INACTIVE; }

            //return View(oData);
            return View();
        }
    } //End public partial class UserparentController : Controller
} //End namespace APPBASE.Controllers