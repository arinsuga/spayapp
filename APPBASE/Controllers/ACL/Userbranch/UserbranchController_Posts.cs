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
    public partial class UserbranchController : Controller
    {
        [HttpPost]
        public ActionResult Create(UserdetailBRANCHVM poViewModel, HttpPostedFileBase FileUSER_IMG)
        {
            ViewBag.AC_MENU_ID = valMENU.HAKAKSES_USERBRANCH_CREATE;

            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;

            //USERNAME=RES_CD
            //poViewModel.USERNAME = poViewModel.RES_CD;
            oVAL = new UserBRANCH_Validation(poViewModel);
            oVAL.Validate_Create();
            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                poViewModel.PASSWORD = hlpObf.randomEncrypt(poViewModel.PASSWORD);
                oCRUD.CreateBRANCH(poViewModel, FileUSER_IMG);
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
        public ActionResult Edit(UserdetailBRANCHVM poViewModel, HttpPostedFileBase FileUSER_IMG)
        {
            ViewBag.AC_MENU_ID = valMENU.HAKAKSES_USERBRANCH_EDIT;

            oVAL = new UserBRANCH_Validation(poViewModel);
            oVAL.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                if (poViewModel.PASSWORD != null) { poViewModel.PASSWORD = hlpObf.randomEncrypt(poViewModel.PASSWORD); }
                oCRUD.UpdateBRANCH(poViewModel, FileUSER_IMG);
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
            ViewBag.AC_MENU_ID = valMENU.HAKAKSES_USERBRANCH_DELETE;

            oCRUD.DeleteBRANCH(id);

            if (oCRUD.isERR)
            {
                TempData["ERRMSG"] = oCRUD.ERRMSG;
                return RedirectToAction("ErrorSYS", "Error");
            } //End if (!oCRUD.isERR) {

            TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
            return RedirectToAction("Index");
        }
    } //End public partial class UserbranchController : Controller
} //End namespace APPBASE.Controllers