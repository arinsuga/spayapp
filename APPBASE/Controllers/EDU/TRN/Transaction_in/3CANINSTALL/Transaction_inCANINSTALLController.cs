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
        public ActionResult CreateCANINSTALL()
        {
            //ViewBag.AC_MENU_ID = valMENU.MODULE_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            //Update ViewModel
            Transaction_indetailVM oViewModel = this.getSESSIOAN_Transaction();
            oViewModel = CREATEInit_ViewModel(oViewModel);
            oViewModel = CREATEInitCANINSTALL_ViewModel(oViewModel);
            //Update Session
            updateSESSIOAN_Transaction(oViewModel);
            this.prepareData(oViewModel);

            return View("~/Views/Transaction_in/3CANINSTALL/CreateCANINSTALL.cshtml", oViewModel);
        } //End public ActionResult CreateCANINSTALL()
    } //End public partial class Transaction_inController : Controller
} //End namespace APPBASE.Controllers
