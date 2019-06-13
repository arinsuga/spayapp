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
    [Table("VWEDU01CFG_MAIN_INFO")]
    public partial class Mainconfig_info
    {
        public int? CREATEBY { get; set; }
        public int? UPDATEBY { get; set; }
        public DateTime? CREATEDT { get; set; }
        public DateTime? UPDATEDT { get; set; }
        [Key]
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public string COMPANY_NAME { get; set; }
        public int? RECEIPT_NO { get; set; }
        public string RECEIPT_FORMAT { get; set; }
        public int? YEAR_ID { get; set; }
        public int? HQBRANCH_ID { get; set; }
        public int? DEFBRANCH_ID { get; set; }
        public string YEAR_CODE { get; set; }
        public string YEAR_SHORTDESC { get; set; }
        public string YEAR_DESC { get; set; }
        public DateTime? YEAR_FROM { get; set; }
        public DateTime? YEAR_TO { get; set; }
        public Byte? HQBRANCH_TYPE { get; set; }
        public string HQBRANCH_CODE { get; set; }
        public string HQBRANCH_SHORTDESC { get; set; }
        public string HQBRANCH_DESC { get; set; }
        public string HQADDR_CITY { get; set; }
        public string HQADDR_KEC { get; set; }
        public string HQADDR_KEL { get; set; }
        public string HQADDR_ZIP { get; set; }
        public string HQADDR_STREET1 { get; set; }
        public string HQADDR_STREET2 { get; set; }
        public string HQPHONE { get; set; }
        public string HQFAX { get; set; }
        public string HQEMAIL { get; set; }
        public Byte? DEFBRANCH_TYPE { get; set; }
        public string DEFBRANCH_CODE { get; set; }
        public string DEFBRANCH_SHORTDESC { get; set; }
        public string DEFBRANCH_DESC { get; set; }
        public string DEFADDR_CITY { get; set; }
        public string DEFADDR_KEC { get; set; }
        public string DEFADDR_KEL { get; set; }
        public string DEFADDR_ZIP { get; set; }
        public string DEFADDR_STREET1 { get; set; }
        public string DEFADDR_STREET2 { get; set; }
        public string DEFPHONE { get; set; }
        public string DEFFAX { get; set; }
        public string DEFEMAIL { get; set; }
    } //End public partial class Mainconfig_info
} //End namespace APPBASE.Models
