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
    public partial class ClassroomController : Controller
    {
        [HttpPost]
        public ActionResult Create_HIDE20170803(ClassroomdetailVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_KELASSENTRA_CREATE;

            oVAL = new Classroom_Validation(poViewModel);
            oVAL.Validate_Create();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Create(poViewModel);
                if (oCRUD.isERR)
                {
                    TempData["ERRMSG"] = oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                TempData["CRUDAction"] = "_PartialConfirmSaved";
                return RedirectToAction("Index");

            } //End if (ModelState.IsValid)
            prepareLookup();

            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Edit(ClassroomdetailVM poViewModel)
        {
            ViewBag.AC_MENU_ID = valMENU.PENGATURAN_KELASSENTRA_EDIT;

            oVAL = new Classroom_Validation(poViewModel);
            oVAL.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Update(poViewModel);
                if (oCRUD.isERR)
                {
                    TempData["ERRMSG"] = oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                TempData["CRUDAction"] = "_PartialConfirmSaved";
                return RedirectToAction("Index");

            }
            prepareLookup();
            return View(poViewModel);
        }
        [HttpPost, ActionName("Delete_HIDE20170803")]
        public ActionResult DeleteConfirmed_HIDE20170803(int? id)
        {
            if (hlpConfig.SessionInfo.getAppUsername().ToUpper() == Svcapp.valDFLT.SYSADMIN_USER) {
                ViewBag.AC_MENU_ID = valMENU.PENGATURAN_KELASSENTRA_DELETE;

                oCRUD.Delete(id);

                if (oCRUD.isERR)
                {
                    TempData["ERRMSG"] = oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                TempData["CRUDAction"] = "_PartialConfirmDeleted";
                return RedirectToAction("Index");
            }
            return Redirect(HttpContext.Request.UrlReferrer.ToString());
        }
    } //End public partial class ClassroomController : Controller
} //End namespace APPBASE.Controllers
