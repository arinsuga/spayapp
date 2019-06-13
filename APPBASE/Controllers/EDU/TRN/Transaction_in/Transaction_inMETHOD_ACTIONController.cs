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
    public partial class Transaction_inController : Controller
    {
        //ACTION-Main
        private ActionResult gotoAction(Transaction_indetailVM poViewModel)
        {
            Transaction_indetailVM oViewModel = poViewModel;

            //ACtionID=1: Save All Transaction
            if (oViewModel.ActionID == 1) { return this.gotoAction_1Save(oViewModel); } //End if (oViewModel.ActionID == 1)
            //ACtionID=2: Cancel-All Transaction
            if (oViewModel.ActionID == 2) { return this.gotoAction_2Cancel(oViewModel); } //End if (oViewModel.ActionID == 2)
            //ACtionID=3: Add/Edit-Transaction Detail
            if (oViewModel.ActionID == 3) { return this.gotoAction_3Detail(oViewModel); } //End if (oViewModel.ActionID == 3)
            //ACtionID=4: Delete-Transaction Detail
            if (oViewModel.ActionID == 4) { return this.gotoAction_4Delete(oViewModel); } //End if (oViewModel.ActionID == 4)

            return View(oViewModel);
        } //End private ActionResult gotoAction(Transaction_indetailVM poViewModel)

        //ACTION-1Save
        private ActionResult gotoAction_1Save(Transaction_indetailVM poViewModel)
        {
            Transaction_indetailVM oViewModel = poViewModel;

            oViewModel.ActionID = null;
            oVAL = new Transaction_in_Validation(oViewModel);
            oVAL.Validate_Create();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.SaveNEW(oViewModel);
                oViewModel.ID = oCRUD.ID;
                if (oCRUD.isERR)
                {
                    TempData["ERRMSG"] = oCRUD.ERRMSG;
                    return RedirectToAction("ErrorSYS", "Error");
                } //End if (!oCRUD.isERR) {

                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                //Update session
                //Session[hlpConfig.SessionInfo.getTransaction_inID()] = oViewModel;
                this.updateSESSIOAN_Transaction(oViewModel);
                //Session[hlpConfig.SessionInfo.getTransactionView_inID()] = Session[hlpConfig.SessionInfo.getTransaction_inID()];
                this.updateSESSIOAN_TransactionView(oViewModel);
                //Session[hlpConfig.SessionInfo.getTransaction_inID()] = null;
                this.resetSESSIOAN_Transaction();

                //return RedirectToAction("Reportview");
                return RedirectToAction("Reportprint");

            } //End if (ModelState.IsValid)

            return View(oViewModel);
        } //End private ActionResult gotoAction_1Save(Transaction_indetailVM poViewModel)
        //ACTION-2Cancel
        private ActionResult gotoAction_2Cancel(Transaction_indetailVM poViewModel)
        {
            Transaction_indetailVM oViewModel = poViewModel;

            oViewModel.ActionID = null;
            Session[hlpConfig.SessionInfo.getTransaction_inID()] = null;

            if (Session[hlpConfig.SessionInfo.getTransaction_methodID()] == hlpConfig.SessionInfo.getTransaction_methodbackdate())
                return RedirectToAction("Indexbackdate");

            return RedirectToAction("Index");
        } //End private ActionResult gotoAction_2Cancel(Transaction_indetailVM poViewModel)
        //ACTION-3Detail
        private ActionResult gotoAction_3Detail(Transaction_indetailVM poViewModel)
        {
            Transaction_indetailVM oViewModel = poViewModel;

            //TRINTYPE_ID=1: Pembayaran SPP
            if (oViewModel.TRINTYPE_ID == 1)
            {
                return RedirectToAction("CreateSPP");
            } //End if (oViewModel.TRINTYPE_ID == 1)
            //TRINTYPE_ID=2: Pembayaran SPP Denda
            if (oViewModel.TRINTYPE_ID == 2)
            {
                return RedirectToAction("CreateSPPDenda");
            } //End if (oViewModel.TRINTYPE_ID == 1)
            //TRINTYPE_ID=9: Pembayaran EKSKUL
            if (oViewModel.TRINTYPE_ID == 9)
            {
                return RedirectToAction("CreateEKSKUL");
            } //End if (oViewModel.TRINTYPE_ID == 1)
            //TRINTYPE_ID=10: Pembayaran SCLUB
            if (oViewModel.TRINTYPE_ID == 10)
            {
                return RedirectToAction("CreateSCLUB");
            } //End if (oViewModel.TRINTYPE_ID == 1)
            //BOLEH DICICIL - TRINTYPE_ID = 7-DU, 8-UAT, 11-PRAKERIN, 13-U.PANGKAL
            if ((oViewModel.TRINTYPE_ID == 7) || (oViewModel.TRINTYPE_ID == 8) ||
                (oViewModel.TRINTYPE_ID == 11) || (oViewModel.TRINTYPE_ID == 13))
            {
                return RedirectToAction("CreateCANINSTALL");
            } //End if ((oViewModel.TRINTYPE_ID >= 3) && (oViewModel.TRINTYPE_ID <= 13))
            //TIDAK BOLEH DICICIL - TRINTYPE_ID = 3_4-MID-GNP-GJL, 5_6-SMT-GNP-GJL, 12-FORMULIR
            if ((oViewModel.TRINTYPE_ID == 3) || (oViewModel.TRINTYPE_ID == 4) ||
                (oViewModel.TRINTYPE_ID == 5) || (oViewModel.TRINTYPE_ID == 6) ||
                (oViewModel.TRINTYPE_ID == 12))
            {
                return RedirectToAction("CreateREGULER");
            } //End if ((oViewModel.TRINTYPE_ID >= 3) && (oViewModel.TRINTYPE_ID <= 13))
            //OTHERS - TRINTYPE_ID = 14-UANG BUKU, 15-UANG SERAGAM
            if ((oViewModel.TRINTYPE_ID == 14) || (oViewModel.TRINTYPE_ID == 15))
            {
                return RedirectToAction("CreateOTHER");
            } //End if ((oViewModel.TRINTYPE_ID >= 3) && (oViewModel.TRINTYPE_ID <= 13))

            return View(oViewModel);
        } //End private ActionResult gotoAction_3Detail(Transaction_indetailVM poViewModel)
        //ACTION-4Delete
        private ActionResult gotoAction_4Delete(Transaction_indetailVM poViewModel) {
            Transaction_indetailVM oViewModel = poViewModel;

            oViewModel.DETAIL = this.removeItem(oViewModel);
            //Update session
            this.updateSESSIOAN_Transaction(oViewModel);

            return RedirectToAction("Create");
        } //End private ActionResult gotoAction_4Delete(Transaction_indetailVM poViewModel)

    } //End public partial class Transaction_inController : Controller
} //End namespace APPBASE.Controllers
