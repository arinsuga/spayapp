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
    public class TrintypeDS
    {
        //Constructor
        public TrintypeDS() { } //End public TrintypeDS
        public List<TrintypedetailVM> getDatalist(List<int?> idlist=null)
        {
            List<TrintypedetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Trintypes
                           select new TrintypedetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               TRINTYPE_CODE = tb.TRINTYPE_CODE,
                               TRINTYPE_SHORTDESC = tb.TRINTYPE_SHORTDESC,
                               TRINTYPE_DESC = tb.TRINTYPE_DESC,
                               TRINTYPE_MAIN = tb.TRINTYPE_MAIN,
                               TRINTYPE_SEQNO = tb.TRINTYPE_SEQNO,
                               TRINMETHOD_ID = tb.TRINMETHOD_ID
                           };
                //Where in
                if (idlist != null) oQRY = oQRY.Where(fld => idlist.Contains(fld.ID));
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<TrintypelistVM> getDatalist()
        public List<TrintypedetailVM> getDatalist()
        {
            List<TrintypedetailVM> vReturn = this.getDatalist();


            //using (var db = new DBMAINContext())
            //{
            //    var oQRY = from tb in db.Trintypes
            //               select new TrintypedetailVM
            //               {
            //                   ID = tb.ID,
            //                   DTA_STS = tb.DTA_STS,
            //                   TRINTYPE_CODE = tb.TRINTYPE_CODE,
            //                   TRINTYPE_SHORTDESC = tb.TRINTYPE_SHORTDESC,
            //                   TRINTYPE_DESC = tb.TRINTYPE_DESC,
            //                   TRINTYPE_MAIN = tb.TRINTYPE_MAIN,
            //                   TRINTYPE_SEQNO = tb.TRINTYPE_SEQNO,
            //                   TRINMETHOD_ID = tb.TRINMETHOD_ID
            //               };
            //    vReturn = oQRY.ToList();
            //} //End using (var = new DbContext())

            return vReturn;
        } //End public List<TrintypelistVM> getDatalist()
        public TrintypedetailVM getData(int? id = null)
        {
            TrintypedetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Trintypes
                           where tb.ID == id
                           select new TrintypedetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               TRINTYPE_CODE = tb.TRINTYPE_CODE,
                               TRINTYPE_SHORTDESC = tb.TRINTYPE_SHORTDESC,
                               TRINTYPE_DESC = tb.TRINTYPE_DESC,
                               TRINTYPE_MAIN = tb.TRINTYPE_MAIN,
                               TRINTYPE_SEQNO = tb.TRINTYPE_SEQNO,
                               TRINMETHOD_ID = tb.TRINMETHOD_ID
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public TrintypedetailVM getData(int? id = null)


        public List<TrintypedetailVM> getDatalist_lookup()
        {
            List<TrintypedetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Trintypes
                           select new TrintypedetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               TRINTYPE_CODE = tb.TRINTYPE_CODE,
                               TRINTYPE_SHORTDESC = tb.TRINTYPE_SHORTDESC,
                               TRINTYPE_DESC = tb.TRINTYPE_DESC,
                               TRINTYPE_MAIN = tb.TRINTYPE_MAIN,
                               TRINTYPE_SEQNO = tb.TRINTYPE_SEQNO,
                               TRINMETHOD_ID = tb.TRINMETHOD_ID
                           };
                //oQRY = oQRY.Where(fld => fld.TRINTYPE_MAIN == 1);

                vReturn = oQRY.OrderBy(fld=>fld.TRINTYPE_SEQNO).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<TrintypelookupVM> getDatalist_lookup()
    } //End public class TrintypeDS
} //End namespace APPBASE.Models
