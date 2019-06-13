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
    [Table("VWSYS01MAIN_INFO")]
    public partial class Sysinfo_info
    {
        [Key]
        public int? ID { get; set; }
        public DateTime? SYSDATE { get; set; }
    } //End public partial class Sysinfo_info
} //End namespace APPBASE.Models
