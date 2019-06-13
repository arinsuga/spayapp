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
    [Table("EDU01CFG_CLASSROOM")]
    public partial class Classroom : CRUD
    {
        public Byte? DTA_STS { get; set; }
        public string CLASSROOM_CODE { get; set; }
        public string CLASSROOM_SHORTDESC { get; set; }
        public string CLASSROOM_DESC { get; set; }
        public int? CLASSROOM_SEQNO { get; set; }
        public int? CLASSLEVEL_ID { get; set; }

        public decimal CLASSROOM_SPP { get; set; }
        public decimal CLASSROOM_SPPDENDA { get; set; }
        public decimal CLASSLEVEL_SPPPINDAH { get; set; }
        public decimal CLASSLEVEL_SPPPINDAHDENDA { get; set; }

        public decimal CLASSROOM_SEMESTER { get; set; }
        public decimal CLASSROOM_MIDSEMESTER { get; set; }
        public decimal CLASSROOM_DFTULANG { get; set; }
        public decimal CLASSROOM_AKHIRTAHUN { get; set; }
        public decimal CLASSROOM_FORMULIR { get; set; }
        public decimal CLASSROOM_PANGKAL { get; set; }
    } //End public partial class Classroom : CRUD
} //End namespace APPBASE.Models
