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
        public ActionResult CreateOTHER()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;

            //Update ViewModel
            Transaction_indetailVM oViewModel = this.getSESSIOAN_Transaction();

            oViewModel = CREATEInit_ViewModel(oViewModel);
            updateSESSIOAN_Transaction(oViewModel);
            this.prepareData(oViewModel);

            return View("~/Views/Transaction_in/4OTHER/CreateOTHER.cshtml", oViewModel);
        } //End public ActionResult CreateOTHER()
    } //End public partial class Transaction_inController : Controller
} //End namespace APPBASE.Controllers
