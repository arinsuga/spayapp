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
    public class ReceiptDS
    {
        //Constructor
        public ReceiptDS() { } //End public ReceiptDS
        public List<ReceiptdetailVM> getDatalist()
        {
            List<ReceiptdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Receipts
                           select new ReceiptdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               RECEIPT_NO = tb.RECEIPT_NO,
                               RECEIPT_DT = tb.RECEIPT_DT,
                               RECEIPT_AMOUNT = tb.RECEIPT_AMOUNT,
                               RECEIPT_TERBILANG = tb.RECEIPT_TERBILANG,
                               RECEIPT_DESC = tb.RECEIPT_DESC,
                               PAIDBY = tb.PAIDBY,
                               RECEIVEDBY = tb.RECEIVEDBY,
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<ReceiptlistVM> getDatalist()
        public ReceiptdetailVM getData(int? id = null)
        {
            ReceiptdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Receipts
                           where tb.ID == id
                           select new ReceiptdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               RECEIPT_NO = tb.RECEIPT_NO,
                               RECEIPT_DT = tb.RECEIPT_DT,
                               RECEIPT_AMOUNT = tb.RECEIPT_AMOUNT,
                               RECEIPT_TERBILANG = tb.RECEIPT_TERBILANG,
                               RECEIPT_DESC = tb.RECEIPT_DESC,
                               PAIDBY = tb.PAIDBY,
                               RECEIVEDBY = tb.RECEIVEDBY,
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public ReceiptdetailVM getData(int? id = null)


        public List<ReceiptdetailVM> getDatalist_lookup()
        {
            List<ReceiptdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Receipts
                           select new ReceiptdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               RECEIPT_NO = tb.RECEIPT_NO,
                               RECEIPT_DT = tb.RECEIPT_DT,
                               RECEIPT_AMOUNT = tb.RECEIPT_AMOUNT,
                               RECEIPT_TERBILANG = tb.RECEIPT_TERBILANG,
                               RECEIPT_DESC = tb.RECEIPT_DESC,
                               PAIDBY = tb.PAIDBY,
                               RECEIVEDBY = tb.RECEIVEDBY,
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<ReceiptlookupVM> getDatalist_lookup()
    } //End public class ReceiptDS
} //End namespace APPBASE.Models
