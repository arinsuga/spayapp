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
    public class Reportin_inDS
    {
        public decimal? TRN_AMOUNT { get; set; }

        //Constructor
        public Reportin_inDS() { } //End public Reportin_inDS
        public List<Reportin_indetailVM> getDatalist(DateTime? pdDate1 = null, DateTime? pdDate2 = null)
        {
            List<Reportin_indetailVM> vReturn;
            
            DateTime? dDate1 = null;
            if (pdDate1 != null) { dDate1 = pdDate1.Value.Date; } //End if (pdDate1 != null)
            DateTime? dDate2 = null;
            if (dDate2 != null) { dDate2 = pdDate2.Value.Date; } //End if (dDate2 != null)

            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Reportin_in_infos
                           select new Reportin_indetailVM
                           {
                               ID = tb.ID,
                               CACHE_YEAR_CODE = tb.CACHE_YEAR_CODE,
                               CACHE_YEAR_SHORTDESC = tb.CACHE_YEAR_SHORTDESC,
                               CACHE_YEAR_DESC = tb.CACHE_YEAR_DESC,
                               CACHE_YEAR_FROM = tb.CACHE_YEAR_FROM,
                               CACHE_YEAR_TO = tb.CACHE_YEAR_TO,
                               TRN_DT = tb.TRN_DT,
                               TRINTYPE_TYPEID = tb.TRINTYPE_TYPEID,
                               TRINTYPE_CODE = tb.TRINTYPE_CODE,
                               TRINTYPE_SHORTDESC = tb.TRINTYPE_SHORTDESC,
                               TRINTYPE_DESC = tb.TRINTYPE_DESC,
                               TRINTYPE_SEQNO = tb.TRINTYPE_SEQNO,
                               TRN_AMOUNT_SD = tb.TRN_AMOUNT_SD,
                               TRN_AMOUNT_SMP = tb.TRN_AMOUNT_SMP,
                               TRN_AMOUNT_SMA = tb.TRN_AMOUNT_SMA,
                               TRN_AMOUNT_SMK = tb.TRN_AMOUNT_SMK,
                               TRN_AMOUNT = tb.TRN_AMOUNT
                           };

                if ((dDate1 != null) && (dDate2 == null))
                {
                    oQRY = oQRY.Where(fld => fld.TRN_DT == dDate1);
                } //End if ((dDate1 != null) && (dDate2 == null))
                if ((dDate1 != null) && (dDate2 != null) && (dDate1 <= pdDate2))
                {
                    oQRY = oQRY.Where(fld => fld.TRN_DT >= dDate1 && fld.TRN_DT <= dDate2);
                } //End if ((dDate1 != null) && (dDate2 != null) && (dDate1 <= pdDate2))
                
                vReturn = oQRY.ToList();
                //Calculate TRN_AMOUNT
                this.TRN_AMOUNT = 0;
                foreach (var item in vReturn) { this.TRN_AMOUNT = this.TRN_AMOUNT + item.TRN_AMOUNT; }
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Reportin_inlistVM> getDatalist()
        public Reportin_indetailVM getData(int? id = null)
        {
            Reportin_indetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Reportin_in_infos
                           where tb.ID == id
                           select new Reportin_indetailVM
                           {
                               ID = tb.ID,
                               CACHE_YEAR_CODE = tb.CACHE_YEAR_CODE,
                               CACHE_YEAR_SHORTDESC = tb.CACHE_YEAR_SHORTDESC,
                               CACHE_YEAR_DESC = tb.CACHE_YEAR_DESC,
                               CACHE_YEAR_FROM = tb.CACHE_YEAR_FROM,
                               CACHE_YEAR_TO = tb.CACHE_YEAR_TO,
                               TRN_DT = tb.TRN_DT,
                               TRINTYPE_TYPEID = tb.TRINTYPE_TYPEID,
                               TRINTYPE_CODE = tb.TRINTYPE_CODE,
                               TRINTYPE_SHORTDESC = tb.TRINTYPE_SHORTDESC,
                               TRINTYPE_DESC = tb.TRINTYPE_DESC,
                               TRINTYPE_SEQNO = tb.TRINTYPE_SEQNO,
                               TRN_AMOUNT_SD = tb.TRN_AMOUNT_SD,
                               TRN_AMOUNT_SMP = tb.TRN_AMOUNT_SMP,
                               TRN_AMOUNT_SMA = tb.TRN_AMOUNT_SMA,
                               TRN_AMOUNT_SMK = tb.TRN_AMOUNT_SMK,
                               TRN_AMOUNT = tb.TRN_AMOUNT
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Reportin_indetailVM getData(int? id = null)


        public List<Reportin_indetailVM> getDatalist_lookup()
        {
            List<Reportin_indetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Reportin_in_infos
                           select new Reportin_indetailVM
                           {
                               ID = tb.ID,
                               CACHE_YEAR_CODE = tb.CACHE_YEAR_CODE,
                               CACHE_YEAR_SHORTDESC = tb.CACHE_YEAR_SHORTDESC,
                               CACHE_YEAR_DESC = tb.CACHE_YEAR_DESC,
                               CACHE_YEAR_FROM = tb.CACHE_YEAR_FROM,
                               CACHE_YEAR_TO = tb.CACHE_YEAR_TO,
                               TRN_DT = tb.TRN_DT,
                               TRINTYPE_TYPEID = tb.TRINTYPE_TYPEID,
                               TRINTYPE_CODE = tb.TRINTYPE_CODE,
                               TRINTYPE_SHORTDESC = tb.TRINTYPE_SHORTDESC,
                               TRINTYPE_DESC = tb.TRINTYPE_DESC,
                               TRINTYPE_SEQNO = tb.TRINTYPE_SEQNO,
                               TRN_AMOUNT_SD = tb.TRN_AMOUNT_SD,
                               TRN_AMOUNT_SMP = tb.TRN_AMOUNT_SMP,
                               TRN_AMOUNT_SMA = tb.TRN_AMOUNT_SMA,
                               TRN_AMOUNT_SMK = tb.TRN_AMOUNT_SMK,
                               TRN_AMOUNT = tb.TRN_AMOUNT
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Reportin_inlookupVM> getDatalist_lookup()
    } //End public class Reportin_inDS
} //End namespace APPBASE.Models
