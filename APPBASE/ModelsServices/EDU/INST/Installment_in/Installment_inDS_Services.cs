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
    public class Installment_inDS
    {
        //Constructor
        public Installment_inDS() { } //End public Installment_inDS
        public List<Installment_indetailVM> getDatalist()
        {
            List<Installment_indetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Installment_in_infos
                           select new Installment_indetailVM
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
                               INST_DT = tb.INST_DT,
                               INST_STS = tb.INST_STS,
                               INST_STARTDT = tb.INST_STARTDT,
                               INST_ENDDT = tb.INST_ENDDT,
                               INST_TYPEID = tb.INST_TYPEID,
                               INST_SUBTYPEID = tb.INST_SUBTYPEID,
                               INST_QTYBASE = tb.INST_QTYBASE,
                               INST_PRICEBASE = tb.INST_PRICEBASE,
                               INST_AMOUNTBASE = tb.INST_AMOUNTBASE,
                               INST_QTY = tb.INST_QTY,
                               INST_AMOUNT = tb.INST_AMOUNT,
                               INST_DESC = tb.INST_DESC,
                               INSTD_ID = tb.INSTD_ID,
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
                               INSTD_STS = tb.INSTD_STS,
                               INSTD_STARTDT = tb.INSTD_STARTDT,
                               INSTD_ENDDT = tb.INSTD_ENDDT,
                               INSTD_PAYDT = tb.INSTD_PAYDT,
                               INSTD_TYPEID = tb.INSTD_TYPEID,
                               INSTD_SUBTYPEID = tb.INSTD_SUBTYPEID,
                               INSTD_AMOUNTBASE = tb.INSTD_AMOUNTBASE,
                               INSTD_AMOUNT = tb.INSTD_AMOUNT,
                               INSTD_DESC = tb.INSTD_DESC,
                               INSTD_SEQNO = tb.INSTD_SEQNO,
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Installment_inlistVM> getDatalist()
        public Installment_indetailVM getData(int? id = null)
        {
            Installment_indetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Installment_in_infos
                           where tb.ID == id
                           select new Installment_indetailVM
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
                               INST_DT = tb.INST_DT,
                               INST_STS = tb.INST_STS,
                               INST_STARTDT = tb.INST_STARTDT,
                               INST_ENDDT = tb.INST_ENDDT,
                               INST_TYPEID = tb.INST_TYPEID,
                               INST_SUBTYPEID = tb.INST_SUBTYPEID,
                               INST_QTYBASE = tb.INST_QTYBASE,
                               INST_PRICEBASE = tb.INST_PRICEBASE,
                               INST_AMOUNTBASE = tb.INST_AMOUNTBASE,
                               INST_QTY = tb.INST_QTY,
                               INST_AMOUNT = tb.INST_AMOUNT,
                               INST_DESC = tb.INST_DESC,
                               INSTD_ID = tb.INSTD_ID,
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
                               INSTD_STS = tb.INSTD_STS,
                               INSTD_STARTDT = tb.INSTD_STARTDT,
                               INSTD_ENDDT = tb.INSTD_ENDDT,
                               INSTD_PAYDT = tb.INSTD_PAYDT,
                               INSTD_TYPEID = tb.INSTD_TYPEID,
                               INSTD_SUBTYPEID = tb.INSTD_SUBTYPEID,
                               INSTD_AMOUNTBASE = tb.INSTD_AMOUNTBASE,
                               INSTD_AMOUNT = tb.INSTD_AMOUNT,
                               INSTD_DESC = tb.INSTD_DESC,
                               INSTD_SEQNO = tb.INSTD_SEQNO,
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Installment_indetailVM getData(int? id = null)



        public List<Installment_indetailVM> getDatalist_report(Installment_indetailVM poViewModel=null)
        {
            List<Installment_indetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Installment_in_infos
                           select new Installment_indetailVM
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
                               INST_DT = tb.INST_DT,
                               INST_STS = tb.INST_STS,
                               INST_STARTDT = tb.INST_STARTDT,
                               INST_ENDDT = tb.INST_ENDDT,
                               INST_TYPEID = tb.INST_TYPEID,
                               INST_SUBTYPEID = tb.INST_SUBTYPEID,
                               INST_QTYBASE = tb.INST_QTYBASE,
                               INST_PRICEBASE = tb.INST_PRICEBASE,
                               INST_AMOUNTBASE = tb.INST_AMOUNTBASE,
                               INST_QTY = tb.INST_QTY,
                               INST_AMOUNT = tb.INST_AMOUNT,
                               INST_DESC = tb.INST_DESC,
                               STUDENT_ID = tb.STUDENT_ID,
                               INSTD_ID = tb.INSTD_ID,
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
                               INSTD_STS = tb.INSTD_STS,
                               INSTD_STARTDT = tb.INSTD_STARTDT,
                               INSTD_ENDDT = tb.INSTD_ENDDT,
                               INSTD_PAYDT = tb.INSTD_PAYDT,
                               INSTD_TYPEID = tb.INSTD_TYPEID,
                               INSTD_SUBTYPEID = tb.INSTD_SUBTYPEID,
                               INSTD_AMOUNTBASE = tb.INSTD_AMOUNTBASE,
                               INSTD_AMOUNT = tb.INSTD_AMOUNT,
                               INSTD_DESC = tb.INSTD_DESC,
                               INSTD_SEQNO = tb.INSTD_SEQNO,
                           };
                //YEAR
                if ((poViewModel.YEAR_FROM != null) && (poViewModel.YEAR_TO != null)) {
                    oQRY = oQRY.Where(fld => fld.CACHE_YEAR_FROM == poViewModel.YEAR_FROM &&
                            fld.CACHE_YEAR_TO == poViewModel.YEAR_TO);
                } //End YEAR
                //STUDENT_ID
                if (poViewModel.STUDENT_ID != null) {
                    oQRY = oQRY.Where(fld => fld.STUDENT_ID == poViewModel.STUDENT_ID);
                } //End STUDENT_ID
                //CLASSTYPE_ID
                if (poViewModel.CLASSTYPE_ID != null)
                {
                    oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.CLASSTYPE_ID);
                } //End CLASSTYPE_ID
                //CLASSLEVEL_ID
                if (poViewModel.CLASSLEVEL_ID != null)
                {
                    oQRY = oQRY.Where(fld => fld.CLASSLEVEL_ID == poViewModel.CLASSLEVEL_ID);
                } //End CLASSLEVEL_ID
                //CLASSROOM_ID
                if (poViewModel.CLASSROOM_ID != null)
                {
                    oQRY = oQRY.Where(fld => fld.CLASSROOM_ID == poViewModel.CLASSROOM_ID);
                } //End CLASSROOM_ID
                //CLASSMAJOR_ID
                if (poViewModel.CLASSMAJOR_ID != null)
                {
                    oQRY = oQRY.Where(fld => fld.CLASSMAJOR_ID == poViewModel.CLASSMAJOR_ID);
                } //End CLASSMAJOR_ID

                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Installment_inlistVM> getDatalist()



        public Installment_indetailVM getData(
            int? pnSTUDENT_ID = null, int? pnTRINTYPE_ID=null,
            DateTime? pdYEAR_FROM = null, DateTime? pdYEAR_TO = null)
        {
            Installment_indetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Installment_in_infos
                           select new Installment_indetailVM
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
                               INST_DT = tb.INST_DT,
                               INST_STS = tb.INST_STS,
                               INST_STARTDT = tb.INST_STARTDT,
                               INST_ENDDT = tb.INST_ENDDT,
                               INST_TYPEID = tb.INST_TYPEID,
                               INST_SUBTYPEID = tb.INST_SUBTYPEID,
                               INST_QTYBASE = tb.INST_QTYBASE,
                               INST_PRICEBASE = tb.INST_PRICEBASE,
                               INST_AMOUNTBASE = tb.INST_AMOUNTBASE,
                               INST_QTY = tb.INST_QTY,
                               INST_AMOUNT = tb.INST_AMOUNT,
                               INST_DESC = tb.INST_DESC,
                               STUDENT_ID = tb.STUDENT_ID,
                               INSTD_ID = tb.INSTD_ID,
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
                               INSTD_STS = tb.INSTD_STS,
                               INSTD_STARTDT = tb.INSTD_STARTDT,
                               INSTD_ENDDT = tb.INSTD_ENDDT,
                               INSTD_PAYDT = tb.INSTD_PAYDT,
                               INSTD_TYPEID = tb.INSTD_TYPEID,
                               INSTD_SUBTYPEID = tb.INSTD_SUBTYPEID,
                               INSTD_AMOUNTBASE = tb.INSTD_AMOUNTBASE,
                               INSTD_AMOUNT = tb.INSTD_AMOUNT,
                               INSTD_DESC = tb.INSTD_DESC,
                               INSTD_SEQNO = tb.INSTD_SEQNO,
                           };
                if (pnSTUDENT_ID != null) oQRY = oQRY.Where(fld => fld.STUDENT_ID == pnSTUDENT_ID);
                if (pnTRINTYPE_ID != null) oQRY = oQRY.Where(fld => fld.INST_TYPEID == pnTRINTYPE_ID);
                if ((pdYEAR_FROM != null) && (pdYEAR_TO != null))
                    oQRY = oQRY.Where(fld => fld.YEAR_FROM == pdYEAR_FROM && fld.YEAR_TO == pdYEAR_TO);
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Installment_indetailVM getData

        public List<Installment_indetailVM> getDatalist_lookup()
        {
            List<Installment_indetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Installment_in_infos
                           select new Installment_indetailVM
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
                               INST_DT = tb.INST_DT,
                               INST_STS = tb.INST_STS,
                               INST_STARTDT = tb.INST_STARTDT,
                               INST_ENDDT = tb.INST_ENDDT,
                               INST_TYPEID = tb.INST_TYPEID,
                               INST_SUBTYPEID = tb.INST_SUBTYPEID,
                               INST_QTYBASE = tb.INST_QTYBASE,
                               INST_PRICEBASE = tb.INST_PRICEBASE,
                               INST_AMOUNTBASE = tb.INST_AMOUNTBASE,
                               INST_QTY = tb.INST_QTY,
                               INST_AMOUNT = tb.INST_AMOUNT,
                               INST_DESC = tb.INST_DESC,
                               INSTD_ID = tb.INSTD_ID,
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
                               INSTD_STS = tb.INSTD_STS,
                               INSTD_STARTDT = tb.INSTD_STARTDT,
                               INSTD_ENDDT = tb.INSTD_ENDDT,
                               INSTD_PAYDT = tb.INSTD_PAYDT,
                               INSTD_TYPEID = tb.INSTD_TYPEID,
                               INSTD_SUBTYPEID = tb.INSTD_SUBTYPEID,
                               INSTD_AMOUNTBASE = tb.INSTD_AMOUNTBASE,
                               INSTD_AMOUNT = tb.INSTD_AMOUNT,
                               INSTD_DESC = tb.INSTD_DESC,
                               INSTD_SEQNO = tb.INSTD_SEQNO,
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Installment_inlookupVM> getDatalist_lookup()
    } //End public class Installment_inDS
} //End namespace APPBASE.Models
