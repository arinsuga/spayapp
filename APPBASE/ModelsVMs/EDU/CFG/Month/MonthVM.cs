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
    public partial class MonthVM
    {
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public string MONTH_CODE { get; set; }
        public string MONTH_SHORTDESC { get; set; }
        public string MONTH_DESC { get; set; }
        //Nomor bulan sebenarnya (cth:1=Januari;2=Februari)
        public Byte? MONTH_NUM { get; set; }
        //Nomor bulan sesuai Tahun Ajaran (cth:1-6=Juli-Desember;7-12=Januari-Juni)
        public Byte? MONTH_SEQNO { get; set; }
        //1=sudah bayar; 0/null=belum bayar
        public Byte? ISPAYED { get; set; }
    } //End public partial class MonthVM
} //End namespace APPBASE.Models

