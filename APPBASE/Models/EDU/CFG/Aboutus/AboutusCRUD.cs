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
    [Table("EDU01CFG_ABOUT")]
    public partial class Aboutus : CRUD
    {
        public int? ID { get; set; }
        public string SHORT_DESC { get; set; }
        public string FULL_DESC { get; set; }
    } //End public partial class Aboutus : CRUD
} //End namespace APPBASE.Models
