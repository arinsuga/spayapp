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
        public ActionResult CreateCANINSTALL(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = this.getSESSIOAN_Transaction();
            oViewModel.ActionID = poViewModel.ActionID;
            oViewModel.TRND_DESC = poViewModel.TRND_DESC;
            oViewModel.TRND_AMOUNT = hlpConvertionAndFormating.ConvertStringToDecimal(poViewModel.TRND_AMOUNT_S);

            if (oViewModel.INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE) {
                //oViewModel.TRND_AMOUNTBASE = poViewModel.TRND_AMOUNTBASE;
                oViewModel.TRND_AMOUNTBASE = hlpConvertionAndFormating.ConvertStringToDecimal(poViewModel.TRND_AMOUNTBASE_S);
            } //End if (oViewModel.INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)

            oViewModel = this.CREATEMapCANINSTALL_ViewModel(oViewModel);
            oViewModel = this.CREATEMapCANINSTALL_ViewModelINST(oViewModel);
            
            //Update session
            this.updateSESSIOAN_Transaction(oViewModel);

            return RedirectToAction("Create");
        } //End public ActionResult CreateCANINSTALL(Transaction_indetailVM poViewModel)
    } //End public partial class Transaction_inController : Controller
} //End namespace APPBASE.Controllers
