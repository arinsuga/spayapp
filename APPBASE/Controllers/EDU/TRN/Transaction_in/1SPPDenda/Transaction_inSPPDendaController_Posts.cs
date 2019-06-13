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
        public ActionResult CreateSPPDenda(Transaction_indetailVM poViewModel) {
            //Update ViewModel
            Transaction_indetailVM oViewModel = (Transaction_indetailVM)Session[hlpConfig.SessionInfo.getTransaction_inID()];
            oViewModel.ActionID = poViewModel.ActionID;
            if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE) {
                oViewModel.TRND_AMOUNT = poViewModel.TRND_AMOUNT;
            } //End if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
            oViewModel.TRND_DESC = poViewModel.TRND_DESC;
            oViewModel = this.CREATEMapsppdenda_ViewModel(oViewModel, poViewModel);

            //Update session
            this.updateSESSIOAN_Transaction(oViewModel);

            return RedirectToAction("Create");
        } //End public ActionResult CreateSPPDenda(Transaction_indetailVM poViewModel)
    } //End public partial class Transaction_inController : Controller
} //End namespace APPBASE.Controllers
