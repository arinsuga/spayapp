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
    public partial class SysinfodetailVM
    {
        public int? ID { get; set; }
        public DateTime? SYSDATE { get; set; }
        //Tanggal (cth: 1 s/d 31)
        public Byte? SYSDAY { get; set; }
        //Nomor bulan sebenarnya (cth:1=Januari;2=Februari)
        public Byte? SYSMONTH { get; set; }
        public Byte? SYSMONTH_SEQNO { get; set; }
        public Byte? SYSYEAR { get; set; }
    } //End public partial class SysinfodetailVM
} //End namespace APPBASE.Models
