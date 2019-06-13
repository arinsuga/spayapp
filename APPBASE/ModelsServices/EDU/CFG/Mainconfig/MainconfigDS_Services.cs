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
    public class MainconfigDS
    {
        public int? RECEIPT_NO { get; set; }
        public string RECEIPT_FORMAT { get; set; }

        public int? YEAR_ID { get; set; }
        public string CACHE_YEAR_CODE { get; set; }
        public string CACHE_YEAR_SHORTDESC { get; set; }
        public string CACHE_YEAR_DESC { get; set; }
        public DateTime? CACHE_YEAR_FROM { get; set; }
        public DateTime? CACHE_YEAR_TO { get; set; }

        public int? SEMESTER_ID { get; set; }
        
        public int? HQBRANCH_ID { get; set; }
        public int? DEFBRANCH_ID { get; set; }
        public DateTime? TRN_DT { get; set; }


        private SysinfoDS oDSSysinfo = new SysinfoDS();
        private YearDS oDSYear = new YearDS();
        private SemesterDS oDSSemester = new SemesterDS();

        //Constructor 1
        public MainconfigDS() {
            //MAIN
            var oData = this.getData();
            this.RECEIPT_NO = oData.RECEIPT_NO;
            this.RECEIPT_FORMAT = oData.RECEIPT_FORMAT;
            this.HQBRANCH_ID = oData.HQBRANCH_ID;
            this.DEFBRANCH_ID = oData.DEFBRANCH_ID;
            //YEAR
            var oDataYear = oDSYear.getData_currentYear();
            this.YEAR_ID = oDataYear.ID;
            this.CACHE_YEAR_CODE = oDataYear.YEAR_CODE;
            this.CACHE_YEAR_SHORTDESC = oDataYear.YEAR_SHORTDESC;
            this.CACHE_YEAR_DESC = oDataYear.YEAR_DESC;
            this.CACHE_YEAR_FROM = oDataYear.YEAR_FROM;
            this.CACHE_YEAR_TO = oDataYear.YEAR_TO;
            //SEMSETER
            this.SEMESTER_ID = oDSSemester.getData_currentSemesterID();
            //TRN
            this.TRN_DT = oDSSysinfo.getSYSDATE();
        } //End public MainconfigDS
        //Constructor 2
        public MainconfigDS(DateTime? pdDatetime)
        {
            //MAIN
            var oData = this.getData();
            this.RECEIPT_NO = oData.RECEIPT_NO;
            this.RECEIPT_FORMAT = oData.RECEIPT_FORMAT;
            this.HQBRANCH_ID = oData.HQBRANCH_ID;
            this.DEFBRANCH_ID = oData.DEFBRANCH_ID;
            //YEAR
            var oDataYear = oDSYear.getData(pdDatetime);
            this.YEAR_ID = oDataYear.ID;
            this.CACHE_YEAR_CODE = oDataYear.YEAR_CODE;
            this.CACHE_YEAR_SHORTDESC = oDataYear.YEAR_SHORTDESC;
            this.CACHE_YEAR_DESC = oDataYear.YEAR_DESC;
            this.CACHE_YEAR_FROM = oDataYear.YEAR_FROM;
            this.CACHE_YEAR_TO = oDataYear.YEAR_TO;

            //SEMESTER
            this.SEMESTER_ID = oDSSemester.getData_SemesterID(pdDatetime);
            //TRN
            this.TRN_DT = pdDatetime.Value.Date;
        } //End public MainconfigDS
        public List<MainconfigdetailVM> getDatalist()
        {
            List<MainconfigdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Mainconfig_infos
                           select new MainconfigdetailVM
                           {
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<MainconfiglistVM> getDatalist()
        public MainconfigdetailVM getData(int? id)
        {
            MainconfigdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Mainconfig_infos
                           where tb.ID == id
                           select new MainconfigdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               COMPANY_NAME = tb.COMPANY_NAME,
                               RECEIPT_NO = tb.RECEIPT_NO,
                               RECEIPT_FORMAT = tb.RECEIPT_FORMAT,
                               YEAR_ID = tb.YEAR_ID,
                               HQBRANCH_ID = tb.HQBRANCH_ID,
                               DEFBRANCH_ID = tb.DEFBRANCH_ID,
                               YEAR_CODE = tb.YEAR_CODE,
                               YEAR_SHORTDESC = tb.YEAR_SHORTDESC,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO,
                               HQBRANCH_TYPE = tb.HQBRANCH_TYPE,
                               HQBRANCH_CODE = tb.HQBRANCH_CODE,
                               HQBRANCH_SHORTDESC = tb.HQBRANCH_SHORTDESC,
                               HQBRANCH_DESC = tb.HQBRANCH_DESC,
                               HQADDR_CITY = tb.HQADDR_CITY,
                               HQADDR_KEC = tb.HQADDR_KEC,
                               HQADDR_KEL = tb.HQADDR_KEL,
                               HQADDR_ZIP = tb.HQADDR_ZIP,
                               HQADDR_STREET1 = tb.HQADDR_STREET1,
                               HQADDR_STREET2 = tb.HQADDR_STREET2,
                               HQPHONE = tb.HQPHONE,
                               HQFAX = tb.HQFAX,
                               HQEMAIL = tb.HQEMAIL,
                               DEFBRANCH_TYPE = tb.DEFBRANCH_TYPE,
                               DEFBRANCH_CODE = tb.DEFBRANCH_CODE,
                               DEFBRANCH_SHORTDESC = tb.DEFBRANCH_SHORTDESC,
                               DEFBRANCH_DESC = tb.DEFBRANCH_DESC,
                               DEFADDR_CITY = tb.DEFADDR_CITY,
                               DEFADDR_KEC = tb.DEFADDR_KEC,
                               DEFADDR_KEL = tb.DEFADDR_KEL,
                               DEFADDR_ZIP = tb.DEFADDR_ZIP,
                               DEFADDR_STREET1 = tb.DEFADDR_STREET1,
                               DEFADDR_STREET2 = tb.DEFADDR_STREET2,
                               DEFPHONE = tb.DEFPHONE,
                               DEFFAX = tb.DEFFAX,
                               DEFEMAIL = tb.DEFEMAIL
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public MainconfigdetailVM getData(int? id = null)
        public MainconfigdetailVM getData()
        {
            MainconfigdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Mainconfigs
                           select new MainconfigdetailVM
                           {
                               ID = tb.ID,
                               RECEIPT_NO = tb.RECEIPT_NO,
                               RECEIPT_FORMAT = tb.RECEIPT_FORMAT,
                               YEAR_ID = tb.YEAR_ID,
                               HQBRANCH_ID = tb.HQBRANCH_ID,
                               DEFBRANCH_ID = tb.DEFBRANCH_ID
                           };
                oReturn = oQRY.FirstOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public MainconfigdetailVM getData(int? id = null)


        public List<MainconfigdetailVM> getDatalist_lookup()
        {
            List<MainconfigdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Mainconfig_infos
                           select new MainconfigdetailVM
                           {

                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<MainconfiglookupVM> getDatalist_lookup()
        public int? getData_defBranchID(int? id = null)
        {
            int? vReturn=null;
            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Mainconfigs
                           where tb.ID == id
                           select new MainconfigdetailVM
                           { DEFBRANCH_ID = tb.DEFBRANCH_ID };
                var oData = oQRY.FirstOrDefault();
                vReturn = oData.DEFBRANCH_ID;
            } //End using (var = new DbContext())
            return vReturn;
        } //End public int? getData_defBranchID(int? id = null)
    } //End public class MainconfigDS
} //End namespace APPBASE.Models
