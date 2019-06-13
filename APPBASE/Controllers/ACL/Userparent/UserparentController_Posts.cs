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
    public partial class UserparentController : Controller
    {
        [HttpPost]
        public ActionResult Create(UserdetailPARENTVM poViewModel, HttpPostedFileBase FileUSER_IMG)
        {
            ViewBag.AC_MENU_ID = valMENU.HAKAKSES_USERPARENT_CREATE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;

            //USERNAME=RES_CD
            //poViewModel.USERNAME = poViewModel.RES_CD;
            oVAL = new UserPARENT_Validation(poViewModel);
            oVAL.Validate_Create();
            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                poViewModel.PASSWORD = hlpObf.randomEncrypt(poViewModel.PASSWORD);
                poViewModel.ROLE_ID = 7; //Set Parent roles
                oCRUD.CreatePARENT(poViewModel, FileUSER_IMG);
                if (oCRUD.isERR) {
                    TempData["ERRMSG"] = oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = oCRUD.ID });
            } //End if (ModelState.IsValid)

            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Edit(UserdetailPARENTVM poViewModel, HttpPostedFileBase FileUSER_IMG)
        {
            ViewBag.AC_MENU_ID = valMENU.HAKAKSES_USERPARENT_EDIT;

            oVAL = new UserPARENT_Validation(poViewModel);
            oVAL.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                if (poViewModel.PASSWORD != null) { poViewModel.PASSWORD = hlpObf.randomEncrypt(poViewModel.PASSWORD); }
                oCRUD.UpdatePARENT(poViewModel, FileUSER_IMG);
                if (oCRUD.isERR)
                {
                    TempData["ERRMSG"] = oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = oCRUD.ID });
            }
            return View(poViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            ViewBag.AC_MENU_ID = valMENU.HAKAKSES_USERPARENT_DELETE;

            oCRUD.DeletePARENT(id);

            if (oCRUD.isERR)
            {
                TempData["ERRMSG"] = oCRUD.ERRMSG;
                return RedirectToAction("ErrorSYS", "Error");
            } //End if (!oCRUD.isERR) {

            TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
            return RedirectToAction("Index");
        }
    } //End public partial class UserparentController : Controller
} //End namespace APPBASE.Controllers