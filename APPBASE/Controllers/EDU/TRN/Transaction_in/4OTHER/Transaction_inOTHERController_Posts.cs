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
        public ActionResult CreateOTHER(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            //Transaction_indetailVM oViewModel = (Transaction_indetailVM)Session[hlpConfig.SessionInfo.getTransaction_inID()];
            Transaction_indetailVM oViewModel = this.getSESSIOAN_Transaction();

            oViewModel.ActionID = poViewModel.ActionID;
            //oViewModel.TRND_AMOUNT = poViewModel.TRND_AMOUNT;
            oViewModel.TRND_AMOUNT = hlpConvertionAndFormating.ConvertStringToDecimal(poViewModel.TRND_AMOUNT_S);
            oViewModel.TRND_DESC = poViewModel.TRND_DESC;
            oViewModel = this.CREATEMapOTHER_ViewModel(oViewModel);
            
            //Update session
            //Session[hlpConfig.SessionInfo.getTransaction_inID()] = oViewModel;
            this.updateSESSIOAN_Transaction(oViewModel);

            return RedirectToAction("Create");
        } //End public ActionResult CreateOTHER(Transaction_indetailVM poViewModel)
    } //End public partial class Transaction_inController : Controller
} //End namespace APPBASE.Controllers
