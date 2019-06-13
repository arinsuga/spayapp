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
    [Table("EDU01INST_IN")]
    public partial class Installment_in : CRUD
    {
        public Byte? DTA_STS { get; set; }
        public int? BRANCH_ID { get; set; }
        public int? YEAR_ID { get; set; }
        public int? SEMESTER_ID { get; set; }
        public int? CLASSTYPE_ID { get; set; }
        public int? CLASSLEVEL_ID { get; set; }
        public int? CLASSROOM_ID { get; set; }
        public int? CLASSMAJOR_ID { get; set; }
        public DateTime? INST_DT { get; set; }
        public Byte? INST_STS { get; set; }
        public DateTime? INST_STARTDT { get; set; }
        public DateTime? INST_ENDDT { get; set; }
        public Byte? INST_TYPEID { get; set; }
        public Byte? INST_SUBTYPEID { get; set; }
        public decimal? INST_QTYBASE { get; set; }
        public decimal? INST_PRICEBASE { get; set; }
        public decimal? INST_AMOUNTBASE { get; set; }
        public decimal? INST_QTY { get; set; }
        public decimal? INST_AMOUNT { get; set; }
        public string INST_DESC { get; set; }
        public int? STUDENT_ID { get; set; }
        public int? INSTD_ID { get; set; }
        public string CACHE_YEAR_CODE { get; set; }
        public string CACHE_YEAR_SHORTDESC { get; set; }
        public string CACHE_YEAR_DESC { get; set; }
        public DateTime? CACHE_YEAR_FROM { get; set; }
        public DateTime? CACHE_YEAR_TO { get; set; }
    } //End public partial class Installment_in : CRUD
} //End namespace APPBASE.Models
