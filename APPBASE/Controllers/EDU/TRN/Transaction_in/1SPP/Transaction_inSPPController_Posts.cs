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
        public ActionResult CreateSPP(Transaction_indetailVM poViewModel) {
            //Update ViewModel
            Transaction_indetailVM oViewModel = (Transaction_indetailVM)Session[hlpConfig.SessionInfo.getTransaction_inID()];
            oViewModel.ActionID = poViewModel.ActionID;
            oViewModel.TRND_DESC = poViewModel.TRND_DESC;
            //oViewModel.TRND_AMOUNT = poViewModel.TRND_AMOUNT;
            oViewModel.TRND_AMOUNT = hlpConvertionAndFormating.ConvertStringToDecimal(poViewModel.TRND_AMOUNT_S);

            if (oViewModel.MONTHLY_INST_SPP.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
            {
                oViewModel.TRND_AMOUNTBASE = hlpConvertionAndFormating.ConvertStringToDecimal(poViewModel.TRND_AMOUNTBASE_S);
            } //End if (oViewModel.INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)


            oViewModel = this.CREATEMapspp_ViewModel(oViewModel, poViewModel);
            oViewModel = this.CREATEMapspp_ViewModelINST(oViewModel);

            //Update session
            //Session[hlpConfig.SessionInfo.getTransaction_inID()] = oViewModel;
            this.updateSESSIOAN_Transaction(oViewModel);

            return RedirectToAction("Create");
        } //End public ActionResult CreateSPP(Transaction_indetailVM poViewModel)

        public ActionResult CreateSPP_BACKUP(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = (Transaction_indetailVM)Session[hlpConfig.SessionInfo.getTransaction_inID()];
            oViewModel.ActionID = poViewModel.ActionID;
            if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
            {
                oViewModel.TRND_AMOUNT = poViewModel.TRND_AMOUNT;
            } //End if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
            oViewModel.TRND_DESC = poViewModel.TRND_DESC;
            //oViewModel = this.CREATEMap_ViewModel(oViewModel);
            oViewModel = this.CREATEMapspp_ViewModel(oViewModel, poViewModel);
            oViewModel = this.CREATEMapspp_ViewModelINST(oViewModel);

            //Update session
            //Session[hlpConfig.SessionInfo.getTransaction_inID()] = oViewModel;
            this.updateSESSIOAN_Transaction(oViewModel);

            return RedirectToAction("Create");
        } //End public ActionResult CreateSPP(Transaction_indetailVM poViewModel)
    } //End public partial class Transaction_inController : Controller
} //End namespace APPBASE.Controllers
