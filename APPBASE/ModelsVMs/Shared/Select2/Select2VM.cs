using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
 
    //Extra classes to format the results the way the select2 dropdown wants them
    public class Select2VM
    {
        public int total_count { get; set; }
        public List<Select2detailVM> items { get; set; }
    }

    public class Select2detailVM
    {
        public string id { get; set; }
        public string text { get; set; }
    }


} //End namespace APPBASE.Models

