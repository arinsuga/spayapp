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
    [Table("EDU01TRN_IND")]
    public partial class Transaction_ind : CRUD
    {
        public Byte? DTA_STS { get; set; }
        public int? TRND_METHODID { get; set; }
        public int? TRND_TYPEID { get; set; }
        public int? TRND_SUBTYPEID { get; set; }
        public int? TRND_ITEMTYPEID { get; set; }
        public int? TRND_ITEMID { get; set; }
        public decimal? TRND_QTY { get; set; }
        public decimal? TRND_PRICE { get; set; }
        public decimal? TRND_AMOUNT { get; set; }
        public decimal? TRND_PRICEBASE { get; set; }
        public decimal? TRND_QTYBASE { get; set; }
        public decimal? TRND_AMOUNTBASE { get; set; }
        public string TRND_DESC { get; set; }
        public int? TRN_ID { get; set; }
        public int? INST_ID { get; set; }
        public int? INSTD_ID { get; set; }
        public int? INSTD_SEQNO { get; set; }
    } //End public partial class Transaction_ind : CRUD
} //End namespace APPBASE.Models
