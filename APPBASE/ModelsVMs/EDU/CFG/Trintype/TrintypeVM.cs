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
    public partial class TrintypedetailVM
    {
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public string TRINTYPE_CODE { get; set; }
        public string TRINTYPE_SHORTDESC { get; set; }
        public string TRINTYPE_DESC { get; set; }
        public int? TRINTYPE_MAIN { get; set; }
        public int? TRINTYPE_SEQNO { get; set; }
        public int? TRINMETHOD_ID { get; set; }
    } //End public partial class TrintypedetailVM

} //End namespace APPBASE.Models
