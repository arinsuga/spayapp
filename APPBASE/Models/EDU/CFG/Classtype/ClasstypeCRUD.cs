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
    [Table("EDU01CFG_CLASSTYPE")]
    public partial class Classtype : CRUD
    {
        public Byte? DTA_STS { get; set; }
        public string CLASSTYPE_CODE { get; set; }
        public string CLASSTYPE_SHORTDESC { get; set; }
        public string CLASSTYPE_DESC { get; set; }
        public int? CLASSTYPE_NUM { get; set; }
        public int? CLASSTYPE_SEQNO { get; set; }
        public decimal CLASSTYPE_SPP { get; set; }
        public decimal CLASSTYPE_SPPDENDA { get; set; }
        public decimal CLASSTYPE_SEMESTER { get; set; }
        public decimal CLASSTYPE_MIDSEMESTER { get; set; }
        public decimal CLASSTYPE_DFTULANG { get; set; }
        public decimal CLASSTYPE_AKHIRTAHUN { get; set; }
        public decimal CLASSTYPE_FORMULIR { get; set; }
        public decimal CLASSTYPE_PANGKAL { get; set; }
    } //End public partial class Classtype : CRUD
} //End namespace APPBASE.Models
