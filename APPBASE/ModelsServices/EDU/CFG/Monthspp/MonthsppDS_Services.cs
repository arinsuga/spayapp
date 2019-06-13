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
    public class MonthsppDS
    {
        //Constructor
        public MonthsppDS() { } //End public YearDS
        public List<MonthsppVM> getDatalist()
        {
            List<MonthsppVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Monthspps
                           select new MonthsppVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               MONTHSPP_CODE = tb.MONTHSPP_CODE,
                               MONTHSPP_SHORTDESC = tb.MONTHSPP_SHORTDESC,
                               MONTHSPP_DESC = tb.MONTHSPP_DESC,
                               MONTHSPP_NUM = tb.MONTHSPP_NUM,
                               MONTHSPP_SEQNO = tb.MONTHSPP_SEQNO
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<YearlistVM> getDatalist()
        public MonthsppVM getData(int? id = null)
        {
            MonthsppVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Monthspps
                           where tb.ID == id
                           select new MonthsppVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               MONTHSPP_CODE = tb.MONTHSPP_CODE,
                               MONTHSPP_SHORTDESC = tb.MONTHSPP_SHORTDESC,
                               MONTHSPP_DESC = tb.MONTHSPP_DESC,
                               MONTHSPP_NUM = tb.MONTHSPP_NUM,
                               MONTHSPP_SEQNO = tb.MONTHSPP_SEQNO
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public YeardetailVM getData(int? id = null)
        public YeardetailVM getData_byPeriod(DateTime? pdDate)
        {
            YeardetailVM oReturn;
            DateTime? dDate = pdDate.Value.Date;
            
            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Years
                           where tb.DTA_STS != 3
                           select new YeardetailVM
                           {
                           };
                oQRY = oQRY.Where(fld => dDate >= fld.YEAR_FROM &&
                                         dDate <= fld.YEAR_TO);

                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public YeardetailVM getData(int? id = null)

        public List<MonthsppVM> getDatalist_lookup()
        {
            List<MonthsppVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Monthspps
                           select new MonthsppVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               MONTHSPP_CODE = tb.MONTHSPP_CODE,
                               MONTHSPP_SHORTDESC = tb.MONTHSPP_SHORTDESC,
                               MONTHSPP_DESC = tb.MONTHSPP_DESC,
                               MONTHSPP_NUM = tb.MONTHSPP_NUM,
                               MONTHSPP_SEQNO = tb.MONTHSPP_SEQNO
                           };
                vReturn = oQRY.OrderBy(fld=>fld.MONTHSPP_SEQNO).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<YearlookupVM> getDatalist_lookup()
    } //End public class MonthsppDS
} //End namespace APPBASE.Models

