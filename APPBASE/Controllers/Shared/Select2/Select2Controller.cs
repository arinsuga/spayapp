using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Filters;
using APPBASE.Svcbiz;

namespace APPBASE.Controllers
{
    [MyActionFilterAttribute]
    public partial class Select2ajaxController : Controller
    {
        //[HttpGet]
        //public JsonResult getClassroom(string psFilter1, string psFilter2, string psFilter3)
        //{
        //    int? nFilter1 = null;
        //    if ((psFilter1 != null) && (psFilter1 != "")) nFilter1 = Convert.ToInt32(psFilter1);

        //    //int? nFilter2 = null;
        //    //if ((psFilter2 != null) && (psFilter2 != "")) nFilter2 = Convert.ToInt32(psFilter2);

        //    //int? nFilter3 = null;
        //    //if ((psFilter3 != null) && (psFilter3 != "")) nFilter3 = Convert.ToInt32(psFilter3);

        //    Select2VM data = new ClassroomDS().getDatalist_select2ajax("", nFilter1);
        //    return Json(data.items, JsonRequestBehavior.AllowGet);
        //} //End public ActionResult getClassroom(string searchTerm, int pageSize, int pageNum, string psFilter1 = null, string psFilter2 = null, string psFilter3 = null)
    
    } //End public partial class Select2ajaxController : Controller
} //End namespace APPBASE.Controllers
