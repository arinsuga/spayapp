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
    public class YearDS
    {
        //Constructor
        public YearDS() { } //End public YearDS
        public List<YeardetailVM> getDatalist()
        {
            List<YeardetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Years
                           select new YeardetailVM
                           {
                               ID = tb.ID,
                               YEAR_CODE = tb.YEAR_CODE,
                               YEAR_SHORTDESC = tb.YEAR_SHORTDESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<YearlistVM> getDatalist()
        public YeardetailVM getData(int? id = null)
        {
            YeardetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Years
                           where tb.DTA_STS !=3 && tb.ID == id
                           select new YeardetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               YEAR_CODE = tb.YEAR_CODE,
                               YEAR_SHORTDESC = tb.YEAR_SHORTDESC,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO
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
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               YEAR_CODE = tb.YEAR_CODE,
                               YEAR_SHORTDESC = tb.YEAR_SHORTDESC,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO
                           };
                oQRY = oQRY.Where(fld => dDate >= fld.YEAR_FROM &&
                                         dDate <= fld.YEAR_TO);

                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public YeardetailVM getData(int? id = null)

        public List<YeardetailVM> getDatalist_lookup()
        {
            List<YeardetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Years
                           select new YeardetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               YEAR_CODE = tb.YEAR_CODE,
                               YEAR_SHORTDESC = tb.YEAR_SHORTDESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<YearlookupVM> getDatalist_lookup()

        public YeardetailVM getData_byPeriod(DateTime? pdDatefrom, DateTime? pdDateto)
        {
            YeardetailVM oReturn;

            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Years
                           select new YeardetailVM
                           {
                               ID = tb.ID,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO
                           };
                oQRY = oQRY.Where(fld => pdDatefrom == fld.YEAR_FROM &&
                                         pdDateto == fld.YEAR_TO);

                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public YeardetailVM getData(int? id = null)
        public int? getData_currentYearID()
        {
            SysinfoDS oDSSysinfo = new SysinfoDS();
            return getData_YearID(oDSSysinfo.getSYSDATE());
        } //End public int? getData_currentYearID()
        public int? getData_YearID(DateTime? pdDatetime = null)
        {
            return this.getData(pdDatetime).ID;
        } //End public int? getData_YearID(DateTime? pdDatetime = null)
        public YeardetailVM getData_currentYear()
        {
            SysinfoDS oDSSysinfo = new SysinfoDS();
            return this.getData(oDSSysinfo.getSYSDATE());
        } //End public int? getData_currentYearID()
        public YeardetailVM getData(DateTime? pdDatetime)
        {
            YeardetailVM vReturn = null;
            DateTime? dDate = null;

            if (pdDatetime != null)
            {
                dDate = pdDatetime.Value.Date;
                using (var db = new DBMAINContext())
                {
                    var oQRY = from tb in db.Years
                               where tb.DTA_STS != 3
                               select new YeardetailVM
                               {
                                   ID = tb.ID,
                                   DTA_STS = tb.DTA_STS,
                                   YEAR_CODE = tb.YEAR_CODE,
                                   YEAR_SHORTDESC = tb.YEAR_SHORTDESC,
                                   YEAR_DESC = tb.YEAR_DESC,
                                   YEAR_FROM = tb.YEAR_FROM,
                                   YEAR_TO = tb.YEAR_TO
                               };
                    vReturn = oQRY.Where(fld => dDate >= fld.YEAR_FROM &&
                                             dDate <= fld.YEAR_TO).SingleOrDefault();
                } //End using (var = new DbContext())
            } //End if (pdDatetime != null)

            return vReturn;
        } //End public int? getData_YearID(DateTime? pdDatetime = null)
    } //End public class YearDS
} //End namespace APPBASE.Models

