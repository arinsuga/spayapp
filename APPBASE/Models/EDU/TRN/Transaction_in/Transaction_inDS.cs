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
    [Table("VWEDU01TRN_IN_INFO")]
    public partial class Transaction_in_info
    {
        public int? CREATEBY { get; set; }
        public int? UPDATEBY { get; set; }
        public DateTime? CREATEDT { get; set; }
        public DateTime? UPDATEDT { get; set; }
        [Key]
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public int? BRANCH_ID { get; set; }
        public int? YEAR_ID { get; set; }
        public int? SEMESTER_ID { get; set; }
        public int? CLASSTYPE_ID { get; set; }
        public int? CLASSLEVEL_ID { get; set; }
        public int? CLASSROOM_ID { get; set; }
        public int? CLASSMAJOR_ID { get; set; }
        public DateTime? TRN_DT { get; set; }
        public Byte? TRN_STS { get; set; }
        public decimal? TRN_AMOUNT { get; set; }
        public string TRN_TERBILANG { get; set; }
        public string TRN_DESC { get; set; }
        public int? STUDENT_ID { get; set; }
        public int? RECEIPT_NO { get; set; }
        public DateTime? RECEIPT_PRINTDT { get; set; }
        public string RECEIPT_PAIDBY { get; set; }
        public string RECEIPT_RECEIVEDBY { get; set; }
        public string CACHE_YEAR_CODE { get; set; }
        public string CACHE_YEAR_SHORTDESC { get; set; }
        public string CACHE_YEAR_DESC { get; set; }
        public DateTime? CACHE_YEAR_FROM { get; set; }
        public DateTime? CACHE_YEAR_TO { get; set; }
        public Byte? BRANCH_TYPE { get; set; }
        public string BRANCH_CODE { get; set; }
        public string BRANCH_SHORTDESC { get; set; }
        public string BRANCH_DESC { get; set; }
        public string YEAR_CODE { get; set; }
        public string YEAR_SHORTDESC { get; set; }
        public string YEAR_DESC { get; set; }
        public DateTime? YEAR_FROM { get; set; }
        public DateTime? YEAR_TO { get; set; }
        public string SEMESTER_CODE { get; set; }
        public string SEMESTER_SHORTDESC { get; set; }
        public string SEMESTER_DESC { get; set; }
        public Byte? SEMESTER_NUM { get; set; }
        public string CLASSTYPE_CODE { get; set; }
        public string CLASSTYPE_SHORTDESC { get; set; }
        public string CLASSTYPE_DESC { get; set; }
        public int? CLASSTYPE_NUM { get; set; }
        public string CLASSLEVEL_CODE { get; set; }
        public string CLASSLEVEL_SHORTDESC { get; set; }
        public string CLASSLEVEL_DESC { get; set; }
        public int? CLASSLEVEL_NUM { get; set; }
        public int? CLASSLEVEL_SEQNO { get; set; }
        public string CLASSROOM_CODE { get; set; }
        public string CLASSROOM_SHORTDESC { get; set; }
        public string CLASSROOM_DESC { get; set; }
        public int? CLASSROOM_SEQNO { get; set; }
        public string CLASSMAJOR_CODE { get; set; }
        public string CLASSMAJOR_SHORTDESC { get; set; }
        public string CLASSMAJOR_DESC { get; set; }
        public int? CLASSMAJOR_NUM { get; set; }
        public int? CLASSMAJOR_SEQNO { get; set; }
        public string STUDENT_NAME { get; set; }
        public string STUDENT_NICKNAME { get; set; }
        public string STUDENT_NIS { get; set; }
        public string STUDENT_NISN { get; set; }
        public int? STUDENT_CLASSTYPE_ID { get; set; }
        public string STUDENT_CLASSTYPE_CODE { get; set; }
        public string STUDENT_CLASSTYPE_SHORTDESC { get; set; }
        public int? STUDENT_CLASSROOM_ID { get; set; }
        public string STUDENT_CLASSROOM_CODE { get; set; }
        public string STUDENT_CLASSROOM_SHORTDESC { get; set; }
        public int? STUDENT_CLASSLEVEL_ID { get; set; }
        public string STUDENT_CLASSLEVEL_CODE { get; set; }
        public string STUDENT_CLASSLEVEL_SHORTDESC { get; set; }
        public int? STUDENT_CLASSLEVEL_NUM { get; set; }

        public int? STUDENT_IS_PINDAHAN { get; set; }
        public decimal? STUDENT_SPP_AMOUNT { get; set; }
    } //End public partial class Transaction_in_info
} //End namespace APPBASE.Models
