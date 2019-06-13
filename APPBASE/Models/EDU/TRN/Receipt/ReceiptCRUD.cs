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
    [Table("EDU01TRN_RECEIPT")]
    public partial class Receipt : CRUD
    {
        public Byte? DTA_STS { get; set; }
        public int? RECEIPT_NO { get; set; }
        public DateTime? RECEIPT_DT { get; set; }
        public decimal RECEIPT_AMOUNT { get; set; }
        public string RECEIPT_TERBILANG { get; set; }
        public string RECEIPT_DESC { get; set; }
        public string PAIDBY { get; set; }
        public string RECEIVEDBY { get; set; }
    } //End public partial class Receipt : CRUD
} //End namespace APPBASE.Models
