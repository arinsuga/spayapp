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
    [Table("VWEDU01RPT_INREKAP_INFO")]
    public partial class Reportin_in_info
    {
        public int? CREATEBY { get; set; }
        public int? UPDATEBY { get; set; }
        public DateTime? CREATEDT { get; set; }
        public DateTime? UPDATEDT { get; set; }
        [Key]
        public int? ID { get; set; }
        public string CACHE_YEAR_CODE { get; set; }
        public string CACHE_YEAR_SHORTDESC { get; set; }
        public string CACHE_YEAR_DESC { get; set; }
        public DateTime? CACHE_YEAR_FROM { get; set; }
        public DateTime? CACHE_YEAR_TO { get; set; }
        public DateTime? TRN_DT { get; set; }
        public int? TRINTYPE_TYPEID { get; set; }
        public string TRINTYPE_CODE { get; set; }
        public string TRINTYPE_SHORTDESC { get; set; }
        public string TRINTYPE_DESC { get; set; }
        public int? TRINTYPE_SEQNO { get; set; }
        public decimal? TRN_AMOUNT_SD { get; set; }
        public decimal? TRN_AMOUNT_SMP { get; set; }
        public decimal? TRN_AMOUNT_SMA { get; set; }
        public decimal? TRN_AMOUNT_SMK { get; set; }
        public decimal? TRN_AMOUNT { get; set; }
    } //End public partial class Reportin_in_info
} //End namespace APPBASE.Models
