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
    public class SemesterDS
    {
        //Constructor
        public SemesterDS() { } //End public SemesterDS
        public List<SemesterdetailVM> getDatalist()
        {
            List<SemesterdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Semesters
                           select new SemesterdetailVM
                           {
                               ID = tb.ID,
                               SEMESTER_SHORTDESC = tb.SEMESTER_SHORTDESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SemesterlistVM> getDatalist()
        public SemesterdetailVM getData(int? id = null)
        {
            SemesterdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Semesters
                           where tb.ID == id
                           select new SemesterdetailVM
                           {
                               ID = tb.ID,
                               SEMESTER_CODE = tb.SEMESTER_CODE,
                               SEMESTER_SHORTDESC = tb.SEMESTER_SHORTDESC,
                               SEMESTER_DESC = tb.SEMESTER_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public SemesterdetailVM getData(int? id = null)

        public List<SemesterdetailVM> getDatalist_lookup()
        {
            List<SemesterdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Semesters
                           select new SemesterdetailVM
                           {
                               ID = tb.ID,
                               SEMESTER_SHORTDESC = tb.SEMESTER_SHORTDESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<SemesterlistVM> getDatalist()

        public Byte? getData_currentSemesterID()
        {
            SysinfoDS oDSSysinfo = new SysinfoDS();
            //Semester 1 / Semeseter 2
            return getData_SemesterID(oDSSysinfo.getData().SYSDATE);
        } //End public int? getData_currentSemesterID()
        public Byte? getData_SemesterID(DateTime? pdDatetime = null)
        {
            Byte? vReturn = null;

            if (pdDatetime != null)
            {
                int nMonth = pdDatetime.Value.Month;
                //Semester 1 / Semeseter 2
                if ((nMonth >= 7) && (nMonth <= 12)) vReturn = 1; else vReturn = 2;
            } //End if (pdDatetime != null)

            return vReturn;
        } //End public int? getData_currentSemesterID()
    } //End public class SemesterDS
} //End namespace APPBASE.Models

