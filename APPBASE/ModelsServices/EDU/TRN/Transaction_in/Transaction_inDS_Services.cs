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
    public class Transaction_inDS
    {
        //Constructor
        public Transaction_inDS() { } //End public Transaction_inDS
        public List<Transaction_indetailVM> getDatalist()
        {
            List<Transaction_indetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Transaction_ins
                           select new Transaction_indetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               TRN_DT = tb.TRN_DT,
                               TRN_STS = tb.TRN_STS,
                               TRN_AMOUNT = tb.TRN_AMOUNT,
                               TRN_TERBILANG = tb.TRN_TERBILANG,
                               TRN_DESC = tb.TRN_DESC,
                               STUDENT_ID = tb.STUDENT_ID,
                               RECEIPT_NO = tb.RECEIPT_NO,
                               CACHE_YEAR_CODE = tb.CACHE_YEAR_CODE,
                               CACHE_YEAR_SHORTDESC = tb.CACHE_YEAR_SHORTDESC,
                               CACHE_YEAR_DESC = tb.CACHE_YEAR_DESC,
                               CACHE_YEAR_FROM = tb.CACHE_YEAR_FROM,
                               CACHE_YEAR_TO = tb.CACHE_YEAR_TO
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Transaction_inlistVM> getDatalist()
        public Transaction_indetailVM getData(int? id = null, int? pnCREATEBY=null)
        {
            Transaction_indetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Transaction_in_infos
                           where tb.ID == id
                           select new Transaction_indetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSLEVEL_ID = tb.CLASSLEVEL_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               CLASSMAJOR_ID = tb.CLASSMAJOR_ID,
                               TRN_DT = tb.TRN_DT,
                               TRN_STS = tb.TRN_STS,
                               TRN_AMOUNT = tb.TRN_AMOUNT,
                               TRN_TERBILANG = tb.TRN_TERBILANG,
                               TRN_DESC = tb.TRN_DESC,
                               STUDENT_ID = tb.STUDENT_ID,
                               RECEIPT_NO = tb.RECEIPT_NO,
                               RECEIPT_PRINTDT = tb.RECEIPT_PRINTDT,
                               RECEIPT_PAIDBY = tb.RECEIPT_PAIDBY,
                               RECEIPT_RECEIVEDBY = tb.RECEIPT_RECEIVEDBY,
                               CACHE_YEAR_CODE = tb.CACHE_YEAR_CODE,
                               CACHE_YEAR_SHORTDESC = tb.CACHE_YEAR_SHORTDESC,
                               CACHE_YEAR_DESC = tb.CACHE_YEAR_DESC,
                               CACHE_YEAR_FROM = tb.CACHE_YEAR_FROM,
                               CACHE_YEAR_TO = tb.CACHE_YEAR_TO,
                               BRANCH_TYPE = tb.BRANCH_TYPE,
                               BRANCH_CODE = tb.BRANCH_CODE,
                               BRANCH_SHORTDESC = tb.BRANCH_SHORTDESC,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               YEAR_CODE = tb.YEAR_CODE,
                               YEAR_SHORTDESC = tb.YEAR_SHORTDESC,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO,
                               SEMESTER_CODE = tb.SEMESTER_CODE,
                               SEMESTER_SHORTDESC = tb.SEMESTER_SHORTDESC,
                               SEMESTER_DESC = tb.SEMESTER_DESC,
                               SEMESTER_NUM = tb.SEMESTER_NUM,
                               CLASSTYPE_CODE = tb.CLASSTYPE_CODE,
                               CLASSTYPE_SHORTDESC = tb.CLASSTYPE_SHORTDESC,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               CLASSTYPE_NUM = tb.CLASSTYPE_NUM,
                               CLASSLEVEL_CODE = tb.CLASSLEVEL_CODE,
                               CLASSLEVEL_SHORTDESC = tb.CLASSLEVEL_SHORTDESC,
                               CLASSLEVEL_DESC = tb.CLASSLEVEL_DESC,
                               CLASSLEVEL_NUM = tb.CLASSLEVEL_NUM,
                               CLASSLEVEL_SEQNO = tb.CLASSLEVEL_SEQNO,
                               CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_SHORTDESC = tb.CLASSROOM_SHORTDESC,
                               CLASSROOM_DESC = tb.CLASSROOM_DESC,
                               CLASSROOM_SEQNO = tb.CLASSROOM_SEQNO,
                               CLASSMAJOR_CODE = tb.CLASSMAJOR_CODE,
                               CLASSMAJOR_SHORTDESC = tb.CLASSMAJOR_SHORTDESC,
                               CLASSMAJOR_DESC = tb.CLASSMAJOR_DESC,
                               CLASSMAJOR_NUM = tb.CLASSMAJOR_NUM,
                               CLASSMAJOR_SEQNO = tb.CLASSMAJOR_SEQNO,
                               STUDENT_NAME = tb.STUDENT_NAME,
                               STUDENT_NICKNAME = tb.STUDENT_NICKNAME,
                               STUDENT_NIS = tb.STUDENT_NIS,
                               STUDENT_NISN = tb.STUDENT_NISN,
                               STUDENT_CLASSTYPE_ID = tb.STUDENT_CLASSTYPE_ID,
                               STUDENT_CLASSTYPE_CODE = tb.STUDENT_CLASSTYPE_CODE,
                               STUDENT_CLASSTYPE_SHORTDESC = tb.STUDENT_CLASSTYPE_SHORTDESC,
                               STUDENT_CLASSROOM_ID = tb.STUDENT_CLASSROOM_ID,
                               STUDENT_CLASSROOM_CODE = tb.STUDENT_CLASSROOM_CODE,
                               STUDENT_CLASSROOM_SHORTDESC = tb.STUDENT_CLASSROOM_SHORTDESC,
                               STUDENT_CLASSLEVEL_ID = tb.STUDENT_CLASSLEVEL_ID,
                               STUDENT_CLASSLEVEL_CODE = tb.STUDENT_CLASSLEVEL_CODE,
                               STUDENT_CLASSLEVEL_SHORTDESC = tb.STUDENT_CLASSLEVEL_SHORTDESC,
                               STUDENT_CLASSLEVEL_NUM = tb.STUDENT_CLASSLEVEL_NUM,
                               IS_PINDAHAN = tb.STUDENT_IS_PINDAHAN,
                               SPP_AMOUNT = tb.STUDENT_SPP_AMOUNT
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Transaction_indetailVM getData(int? id = null)

        public Transaction_indetailVM getData_last()
        {
            Transaction_indetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Transaction_in_infos
                           select new Transaction_indetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSLEVEL_ID = tb.CLASSLEVEL_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               CLASSMAJOR_ID = tb.CLASSMAJOR_ID,
                               TRN_DT = tb.TRN_DT,
                               TRN_STS = tb.TRN_STS,
                               TRN_AMOUNT = tb.TRN_AMOUNT,
                               TRN_TERBILANG = tb.TRN_TERBILANG,
                               TRN_DESC = tb.TRN_DESC,
                               STUDENT_ID = tb.STUDENT_ID,
                               RECEIPT_NO = tb.RECEIPT_NO,
                               RECEIPT_PRINTDT = tb.RECEIPT_PRINTDT,
                               RECEIPT_PAIDBY = tb.RECEIPT_PAIDBY,
                               RECEIPT_RECEIVEDBY = tb.RECEIPT_RECEIVEDBY,
                               CACHE_YEAR_CODE = tb.CACHE_YEAR_CODE,
                               CACHE_YEAR_SHORTDESC = tb.CACHE_YEAR_SHORTDESC,
                               CACHE_YEAR_DESC = tb.CACHE_YEAR_DESC,
                               CACHE_YEAR_FROM = tb.CACHE_YEAR_FROM,
                               CACHE_YEAR_TO = tb.CACHE_YEAR_TO,
                               BRANCH_TYPE = tb.BRANCH_TYPE,
                               BRANCH_CODE = tb.BRANCH_CODE,
                               BRANCH_SHORTDESC = tb.BRANCH_SHORTDESC,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               YEAR_CODE = tb.YEAR_CODE,
                               YEAR_SHORTDESC = tb.YEAR_SHORTDESC,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO,
                               SEMESTER_CODE = tb.SEMESTER_CODE,
                               SEMESTER_SHORTDESC = tb.SEMESTER_SHORTDESC,
                               SEMESTER_DESC = tb.SEMESTER_DESC,
                               SEMESTER_NUM = tb.SEMESTER_NUM,
                               CLASSTYPE_CODE = tb.CLASSTYPE_CODE,
                               CLASSTYPE_SHORTDESC = tb.CLASSTYPE_SHORTDESC,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               CLASSTYPE_NUM = tb.CLASSTYPE_NUM,
                               CLASSLEVEL_CODE = tb.CLASSLEVEL_CODE,
                               CLASSLEVEL_SHORTDESC = tb.CLASSLEVEL_SHORTDESC,
                               CLASSLEVEL_DESC = tb.CLASSLEVEL_DESC,
                               CLASSLEVEL_NUM = tb.CLASSLEVEL_NUM,
                               CLASSLEVEL_SEQNO = tb.CLASSLEVEL_SEQNO,
                               CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_SHORTDESC = tb.CLASSROOM_SHORTDESC,
                               CLASSROOM_DESC = tb.CLASSROOM_DESC,
                               CLASSROOM_SEQNO = tb.CLASSROOM_SEQNO,
                               CLASSMAJOR_CODE = tb.CLASSMAJOR_CODE,
                               CLASSMAJOR_SHORTDESC = tb.CLASSMAJOR_SHORTDESC,
                               CLASSMAJOR_DESC = tb.CLASSMAJOR_DESC,
                               CLASSMAJOR_NUM = tb.CLASSMAJOR_NUM,
                               CLASSMAJOR_SEQNO = tb.CLASSMAJOR_SEQNO,
                               STUDENT_NAME = tb.STUDENT_NAME,
                               STUDENT_NICKNAME = tb.STUDENT_NICKNAME,
                               STUDENT_NIS = tb.STUDENT_NIS,
                               STUDENT_NISN = tb.STUDENT_NISN,
                               STUDENT_CLASSTYPE_ID = tb.STUDENT_CLASSTYPE_ID,
                               STUDENT_CLASSTYPE_CODE = tb.STUDENT_CLASSTYPE_CODE,
                               STUDENT_CLASSTYPE_SHORTDESC = tb.STUDENT_CLASSTYPE_SHORTDESC,
                               STUDENT_CLASSROOM_ID = tb.STUDENT_CLASSROOM_ID,
                               STUDENT_CLASSROOM_CODE = tb.STUDENT_CLASSROOM_CODE,
                               STUDENT_CLASSROOM_SHORTDESC = tb.STUDENT_CLASSROOM_SHORTDESC,
                               STUDENT_CLASSLEVEL_ID = tb.STUDENT_CLASSLEVEL_ID,
                               STUDENT_CLASSLEVEL_CODE = tb.STUDENT_CLASSLEVEL_CODE,
                               STUDENT_CLASSLEVEL_SHORTDESC = tb.STUDENT_CLASSLEVEL_SHORTDESC,
                               STUDENT_CLASSLEVEL_NUM = tb.STUDENT_CLASSLEVEL_NUM,
                               IS_PINDAHAN = tb.STUDENT_IS_PINDAHAN,
                               SPP_AMOUNT = tb.STUDENT_SPP_AMOUNT
                           };
                oReturn = oQRY.OrderByDescending(fld => fld.ID).FirstOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Transaction_indetailVM getData_last()

        public List<Transaction_indetailVM> getDatalist_lookup()
        {
            List<Transaction_indetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Transaction_ins
                           select new Transaction_indetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               TRN_DT = tb.TRN_DT,
                               TRN_STS = tb.TRN_STS,
                               TRN_AMOUNT = tb.TRN_AMOUNT,
                               TRN_TERBILANG = tb.TRN_TERBILANG,
                               TRN_DESC = tb.TRN_DESC,
                               STUDENT_ID = tb.STUDENT_ID,
                               RECEIPT_NO = tb.RECEIPT_NO,
                               CACHE_YEAR_CODE = tb.CACHE_YEAR_CODE,
                               CACHE_YEAR_SHORTDESC = tb.CACHE_YEAR_SHORTDESC,
                               CACHE_YEAR_DESC = tb.CACHE_YEAR_DESC,
                               CACHE_YEAR_FROM = tb.CACHE_YEAR_FROM,
                               CACHE_YEAR_TO = tb.CACHE_YEAR_TO
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Transaction_inlookupVM> getDatalist_lookup()
    } //End public class Transaction_inDS
} //End namespace APPBASE.Models
