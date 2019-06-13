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
    public partial class ClassmajordetailVM
    {
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public string CLASSMAJOR_CODE { get; set; }
        public string CLASSMAJOR_SHORTDESC { get; set; }
        public string CLASSMAJOR_DESC { get; set; }
        public int? CLASSMAJOR_NUM { get; set; }
        public int? CLASSMAJOR_SEQNO { get; set; }
        public int? CLASSTYPE_ID { get; set; }
        public decimal CLASSMAJOR_SPP { get; set; }
        public decimal CLASSMAJOR_SPPDENDA { get; set; }
        public decimal CLASSMAJOR_SEMESTER { get; set; }
        public decimal CLASSMAJOR_MIDSEMESTER { get; set; }
        public decimal CLASSMAJOR_DFTULANG { get; set; }
        public decimal CLASSMAJOR_AKHIRTAHUN { get; set; }
        public decimal CLASSMAJOR_FORMULIR { get; set; }
        public decimal CLASSMAJOR_PANGKAL { get; set; }
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
    } //End public partial class ClassmajordetailVM
} //End namespace APPBASE.Models
