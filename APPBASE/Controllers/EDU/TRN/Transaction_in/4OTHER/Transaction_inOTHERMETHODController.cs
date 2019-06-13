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
        //HEADER
        private Transaction_indetailVM CREATEInitOTHER_ViewModel(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = this.CREATEInit_ViewModel(poViewModel);
            return oViewModel;
        } //End private Transaction_indetailVM CREATEInitOTHER_ViewModel(Transaction_indetailVM poViewModel)
        private Transaction_indetailVM CREATEMapOTHER_ViewModel(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = poViewModel;

            //RESET DETAIL TRANSACTION BY TRINTYPE: REGULER
            oViewModel.DETAIL = this.removeItem(oViewModel);
            //Add Transaction Detail
            if (oViewModel.DETAIL == null) { oViewModel.DETAIL = new List<Transaction_inddetailVM>(); }
            Transaction_inddetailVM oViewModelDETAIL = getItem(oViewModel);
            oViewModel.DETAIL.Add(oViewModelDETAIL);
            //Reset TRINTYPE
            oViewModel.TRINTYPE_ID = null;
            oViewModel.TRINTYPE_CODE = null;
            oViewModel.TRINTYPE_SHORTDESC = null;
            oViewModel.TRINTYPE_DESC = null;
            oViewModel.TRINMETHOD_ID = null;

            return oViewModel;
        } //End private Transaction_indetailVM CREATEMapOTHER_ViewModel(Transaction_indetailVM poViewModel)

    } //End public partial class Transaction_inController : Controller
} //End namespace APPBASE.Controllers
