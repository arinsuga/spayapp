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
    [Table("EDU01CFG_MAIN")]
    public partial class Mainconfig : CRUD
    {
        public Byte? DTA_STS { get; set; }
        public string COMPANY_NAME { get; set; }
        public int? RECEIPT_NO { get; set; }
        public string RECEIPT_FORMAT { get; set; }
        public int? YEAR_ID { get; set; }
        public int? HQBRANCH_ID { get; set; }
        public int? DEFBRANCH_ID { get; set; }
    } //End public partial class Mainconfig : CRUD
} //End namespace APPBASE.Models
