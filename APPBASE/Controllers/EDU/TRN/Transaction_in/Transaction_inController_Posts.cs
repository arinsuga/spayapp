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
using Omu.ValueInjecter;

namespace APPBASE.Controllers
{
    public partial class Transaction_inController : Controller
    {
        [HttpPost]
        public ActionResult Index(Transaction_indetailVM poViewModel)
        {
            //Set ViewModel
            Transaction_indetailVM oViewModel = poViewModel;

            //Retreave Data requirement
            YeardetailVM oDatayear = oDSYear.getData_byPeriod(oDSSysinfo.getData().SYSDATE);
            StudentdetailVM oDatastudent = oDSStudent.getData(poViewModel.STUDENT_ID);

            //Mapp data properti
            oViewModel.InjectFrom(oDatastudent);
            oViewModel.InjectFromStudentVM(oDatastudent);
            oViewModel.InjectFromYearVM(oDatayear);
            oViewModel.InjectReceipt();
            oViewModel.setSYSDATE();


            Session[hlpConfig.SessionInfo.getTransaction_methodID()] = hlpConfig.SessionInfo.getTransaction_methodsysdate();
            Session[hlpConfig.SessionInfo.getTransaction_inID()] = oViewModel;
            Session[hlpConfig.SessionInfo.sSESSIONID_ISBACKDATE] = "NO";
            return RedirectToAction("Create");
        }
        [HttpPost]
        public ActionResult Indexbackdate(Transaction_indetailVM poViewModel)
        {
            //Set ViewModel
            Transaction_indetailVM oViewModel = poViewModel;

            //Retreave Data requirement
            YeardetailVM oDatayear = oDSYear.getData_byPeriod(oDSSysinfo.getData().SYSDATE);
            StudentdetailVM oDatastudent = oDSStudent.getData(poViewModel.STUDENT_ID);

            //Mapp data properti
            oViewModel.InjectFrom(oDatastudent);
            oViewModel.InjectFromStudentVM(oDatastudent);
            oViewModel.InjectFromYearVM(oDatayear);
            oViewModel.InjectReceipt();
            oViewModel.setSYSDATE();

            if ((oViewModel.TRN_DT >= oViewModel.YEAR_FROM) && (oViewModel.TRN_DT <= oViewModel.YEAR_TO)) {
                Session[hlpConfig.SessionInfo.getTransaction_methodID()] = hlpConfig.SessionInfo.getTransaction_methodbackdate();
                Session[hlpConfig.SessionInfo.getTransaction_inID()] = oViewModel;
                Session[hlpConfig.SessionInfo.sSESSIONID_ISBACKDATE] = "YES";
                return RedirectToAction("Create");
            } //End if ((oViewModel.TRN_DT >= oViewModel.YEAR_FROM) && (oViewModel.TRN_DT <= oViewModel.YEAR_TO))

            return View(oViewModel);
        }

        [HttpPost]
        public ActionResult Create(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = (Transaction_indetailVM)Session[hlpConfig.SessionInfo.getTransaction_inID()];
            oViewModel.ActionID = poViewModel.ActionID;
            oViewModel.RECEIPT_PAIDBY = poViewModel.RECEIPT_PAIDBY;
            //Fill TRINTYPE
            var oDataTrinttype = oDSTrintype.getData(poViewModel.TRINTYPE_ID);
            if (oDataTrinttype != null) {
                oViewModel.TRINTYPE_ID = poViewModel.TRINTYPE_ID;
                oViewModel.TRINTYPE_CODE = oDataTrinttype.TRINTYPE_CODE;
                oViewModel.TRINTYPE_SHORTDESC = oDataTrinttype.TRINTYPE_SHORTDESC;
                oViewModel.TRINTYPE_DESC = oDataTrinttype.TRINTYPE_DESC;
                oViewModel.TRINMETHOD_ID = oDataTrinttype.TRINMETHOD_ID;
            } //End if (oDataTrinttype != null)
            //Update session
            Session[hlpConfig.SessionInfo.getTransaction_inID()] = oViewModel; 

            //Run Action
            return this.gotoAction(oViewModel);

            oVAL = new Transaction_in_Validation(poViewModel);
            oVAL.Validate_Create();

            return View(oViewModel);
        }
        [HttpPost]
        public ActionResult Edit(Transaction_indetailVM poViewModel)
        {
            oVAL = new Transaction_in_Validation(poViewModel);
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
                return RedirectToAction("Details", new { id = oCRUD.ID });
            }
            return View(poViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            oCRUD.Delete(id);

            if (oCRUD.isERR)
            {
                TempData["ERRMSG"] = oCRUD.ERRMSG;
                return RedirectToAction("ErrorSYS", "Error");
            } //End if (!oCRUD.isERR) {

            TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
            return RedirectToAction("Index");
        }





        [HttpPost]
        public ActionResult Create_BACKUP(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = (Transaction_indetailVM)Session[hlpConfig.SessionInfo.getTransaction_inID()];
            oViewModel.ActionID = poViewModel.ActionID;
            oViewModel.RECEIPT_PAIDBY = poViewModel.RECEIPT_PAIDBY;
            //Fill TRINTYPE
            var oDataTrinttype = oDSTrintype.getData(poViewModel.TRINTYPE_ID);
            if (oDataTrinttype != null)
            {
                oViewModel.TRINTYPE_ID = poViewModel.TRINTYPE_ID;
                oViewModel.TRINTYPE_CODE = oDataTrinttype.TRINTYPE_CODE;
                oViewModel.TRINTYPE_SHORTDESC = oDataTrinttype.TRINTYPE_SHORTDESC;
                oViewModel.TRINTYPE_DESC = oDataTrinttype.TRINTYPE_DESC;
                oViewModel.TRINMETHOD_ID = oDataTrinttype.TRINMETHOD_ID;
            } //End if (oDataTrinttype != null)
            //Update session
            Session[hlpConfig.SessionInfo.getTransaction_inID()] = oViewModel;

            //ACtionID=1: Save All Transaction
            if (oViewModel.ActionID == 1)
            {
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

                    return RedirectToAction("Reportview");

                } //End if (ModelState.IsValid)
            } //End if (oViewModel.ActionID == 1)
            //ACtionID=2: Cancel-All Transaction
            if (oViewModel.ActionID == 2)
            {
                oViewModel.ActionID = null;
                Session[hlpConfig.SessionInfo.getTransaction_inID()] = null;
                return RedirectToAction("Index");
            } //End if (oViewModel.ActionID == 2)


            //ACtionID=3: Add/Edit-Transaction Detail
            if (oViewModel.ActionID == 3)
            {
                //TRINTYPE_ID=1: Pembayaran SPP
                if (oViewModel.TRINTYPE_ID == 1)
                {
                    return RedirectToAction("CreateSPP");
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


            } //End if (oViewModel.ActionID == 3)

            //ACtionID=4: Delete-Transaction Detail
            if (oViewModel.ActionID == 4)
            {
                oViewModel.DETAIL = this.removeItem(oViewModel);
                //Update session
                this.updateSESSIOAN_Transaction(oViewModel);
                return RedirectToAction("Create");
            } //End if (oViewModel.ActionID == 4)

            oVAL = new Transaction_in_Validation(poViewModel);
            oVAL.Validate_Create();


            return View(oViewModel);
        } //End public ActionResult Create_BACKUP(Transaction_indetailVM poViewModel)
    } //End public partial class Transaction_inController : Controller
} //End namespace APPBASE.Controllers
