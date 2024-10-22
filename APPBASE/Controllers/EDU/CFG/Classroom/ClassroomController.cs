﻿using System;
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
    public partial class ClassroomController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private ClassroomDS oDS = new ClassroomDS();
        private ClassroomCRUD oCRUD = new ClassroomCRUD();
        private Classroom_Validation oVAL;
        //DS CFG
        private ClasstypeDS oDSClasstype = new ClasstypeDS();

        public void prepareLookup()
        {
            ViewBag.CLASSTYPE = oDSClasstype.getDatalist_lookup();
        } //End prepareLookup()
        public void prepareLookupFilter()
        {
        } //End prepareLookupFilter()

        public ActionResult Index()
        {
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_KELASSENTRA_INDEX;

            var oData = oDS.getDatalist();

            return View(oData);
        }
        public ActionResult Details(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_KELASSENTRA_DETAILS;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];

            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            prepareLookup();

            return View(oData);
        }
        public ActionResult Create_HIDE20170803()
        {
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_KELASSENTRA_CREATE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            prepareLookup();

            return View();
        }
        public ActionResult Edit(int? id = null)
        {
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_KELASSENTRA_EDIT;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            prepareLookup();

            return View(oData);
        }
        public ActionResult Delete_HIDE20170803(int? id = null)
        {
            if (hlpConfig.SessionInfo.getAppUsername().ToUpper() == Svcapp.valDFLT.SYSADMIN_USER)
            {
                ViewBag.AC_MENU_ID = valMENU.PENGATURAN_KELASSENTRA_DELETE;
                ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
                var oData = oDS.getData(id);
                if (oData == null) { return HttpNotFound(); }
                prepareLookup();
                return View(oData);
            }
            return Redirect(HttpContext.Request.UrlReferrer.ToString());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class ClassroomController : Controller
} //End namespace APPBASE.Controllers
