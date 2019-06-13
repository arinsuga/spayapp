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
    public partial class Installment_inddetailVM {
        public int? ID { get; set; }
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
        public int? INSTD_ID { get; set; }
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
        public Byte? INSTD_STS { get; set; }
        public DateTime? INSTD_STARTDT { get; set; }
        public DateTime? INSTD_ENDDT { get; set; }
        public DateTime? INSTD_PAYDT { get; set; }
        public Byte? INSTD_TYPEID { get; set; }
        public Byte? INSTD_SUBTYPEID { get; set; }
        public decimal? INSTD_AMOUNTBASE { get; set; }
        public decimal? INSTD_AMOUNT { get; set; }
        public string INSTD_DESC { get; set; }
        public int? INSTD_SEQNO { get; set; }
    } //End public partial class Installment_inddetailVM
    public partial class Installment_inddetailVMBACKUP
    {
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public Byte? INSTD_STS { get; set; }
        public DateTime? INSTD_STARTDT { get; set; }
        public DateTime? INSTD_ENDDT { get; set; }
        public DateTime? INSTD_PAYDT { get; set; }
        public Byte? INSTD_TYPEID { get; set; }
        public Byte? INSTD_SUBTYPEID { get; set; }
        public decimal? INSTD_AMOUNTBASE { get; set; }
        public decimal? INSTD_AMOUNT { get; set; }
        public string INSTD_DESC { get; set; }
        public int? INSTD_SEQNO { get; set; }
        public int? INST_ID { get; set; }
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
        public int? INSTD_ID { get; set; }
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
    } //End public partial class Installment_inddetailVMBACKUP
} //End namespace APPBASE.Models
