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
using APPBASE.Svcapp;
using Omu.ValueInjecter;

namespace APPBASE.Controllers
{
    public partial class Transaction_inController : Controller
    {
        [HttpPost]
        public ActionResult CreateREGULER(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            //Transaction_indetailVM oViewModel = (Transaction_indetailVM)Session[hlpConfig.SessionInfo.getTransaction_inID()];
            Transaction_indetailVM oViewModel = this.getSESSIOAN_Transaction();

            oViewModel.ActionID = poViewModel.ActionID;
            oViewModel.TRND_DESC = poViewModel.TRND_DESC;
            oViewModel.TRND_AMOUNT = hlpConvertionAndFormating.ConvertStringToDecimal(poViewModel.TRND_AMOUNT_S);

            oViewModel = this.CREATEMap_ViewModel(oViewModel);
            
            //Update session
            //Session[hlpConfig.SessionInfo.getTransaction_inID()] = oViewModel;
            this.updateSESSIOAN_Transaction(oViewModel);

            return RedirectToAction("Create");
        }
        public ActionResult CreateREGULER_BACKUP(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            //Transaction_indetailVM oViewModel = (Transaction_indetailVM)Session[hlpConfig.SessionInfo.getTransaction_inID()];
            Transaction_indetailVM oViewModel = this.getSESSIOAN_Transaction();

            oViewModel.ActionID = poViewModel.ActionID;
            oViewModel.TRND_DESC = poViewModel.TRND_DESC;
            //EXTRA CUSTOM-TRANSACTIONDETAIL BASE
            oDSClasslevel.getData(oViewModel.CLASSLEVEL_ID, oViewModel.TRINTYPE_ID, oViewModel.IS_PINDAHAN);
            oViewModel.TRND_PRICEBASE = oDSClasslevel.TRND_PRICEBASE;
            oViewModel.TRND_QTYBASE = oDSClasslevel.TRND_QTYBASE;
            oViewModel.TRND_AMOUNTBASE = oDSClasslevel.TRND_AMOUNTBASE;

            //Add Transaction Detail
            if (oViewModel.DETAIL == null) { oViewModel.DETAIL = new List<Transaction_inddetailVM>(); }
            Transaction_inddetailVM oViewModelDETAIL = new Transaction_inddetailVM();
            oViewModelDETAIL.TRND_METHODID = oViewModel.TRINMETHOD_ID;
            oViewModelDETAIL.TRND_TYPEID = oViewModel.TRINTYPE_ID;
            oViewModelDETAIL.TRINTYPE_CODE = oViewModel.TRINTYPE_CODE;
            oViewModelDETAIL.TRINTYPE_SHORTDESC = oViewModel.TRINTYPE_SHORTDESC;
            oViewModelDETAIL.TRINTYPE_DESC = oViewModel.TRINTYPE_DESC;
            oViewModelDETAIL.TRND_QTY = 1;
            oViewModelDETAIL.TRND_PRICE = 1;
            oViewModelDETAIL.TRND_AMOUNT = oViewModel.TRND_AMOUNT;
            oViewModelDETAIL.TRND_PRICEBASE = oViewModel.TRND_AMOUNT;
            oViewModelDETAIL.TRND_QTYBASE = 1;
            oViewModelDETAIL.TRND_AMOUNTBASE = oViewModel.TRND_AMOUNT;
            oViewModelDETAIL.TRND_DESC = oViewModel.TRND_DESC;
            //Add Detail
            oViewModel.DETAIL.Add(oViewModelDETAIL);
            //Reset TRINTYPE
            var oDataTrinttype = oDSTrintype.getData(poViewModel.TRINTYPE_ID);
            oViewModel.TRINTYPE_ID = null;
            oViewModel.TRINTYPE_CODE = null;
            oViewModel.TRINTYPE_SHORTDESC = null;
            oViewModel.TRINTYPE_DESC = null;
            oViewModel.TRINMETHOD_ID = null;
            //Update session
            //Session[hlpConfig.SessionInfo.getTransaction_inID()] = oViewModel;
            this.updateSESSIOAN_Transaction(oViewModel);

            return RedirectToAction("Create");
        }
    } //End public partial class Transaction_inController : Controller
} //End namespace APPBASE.Controllers
