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
    public class SysinfoDS
    {
        //Constructor
        public SysinfoDS() { } //End public SysinfoDS
        public SysinfodetailVM getData()
        {
            SysinfodetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Sysinfo_infos
                           select new SysinfodetailVM
                           {
                               ID = tb.ID,
                               SYSDATE = tb.SYSDATE
                           };
                oReturn = oQRY.First();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public SysinfodetailVM getData(int? id = null)
        public DateTime? getSYSDATE() {
            return this.getData().SYSDATE;
        } //End public DateTime? getSYSDATE()
        public SysinfodetailVM getSYSDATEVM()
        {
            SysinfodetailVM vReturn = this.getData();

            vReturn.SYSDAY = (Byte?)vReturn.SYSDATE.Value.Day;
            vReturn.SYSMONTH = (Byte?)vReturn.SYSDATE.Value.Month;
            vReturn.SYSYEAR = (Byte?)vReturn.SYSDATE.Value.Year;

            return vReturn;
        } //End public SysinfodetailVM getSYSDATEVM()
    } //End public class SysinfoDS
} //End namespace APPBASE.Models
