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
    [Table("EDU01INST_IND")]
    public partial class Installment_ind : CRUD
    {
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
    } //End public partial class Installment_ind : CRUD
} //End namespace APPBASE.Models
