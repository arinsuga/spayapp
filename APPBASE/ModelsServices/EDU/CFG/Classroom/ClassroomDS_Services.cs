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
    public class ClassroomDS
    {
        //Constructor
        public ClassroomDS() { } //End public ClassroomDS
        public List<ClassroomdetailVM> getDatalist()
        {
            List<ClassroomdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Classrooms
                           select new ClassroomdetailVM
                           {
                               ID = tb.ID,
                               CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_SHORTDESC = tb.CLASSROOM_SHORTDESC,
                               CLASSROOM_DESC = tb.CLASSROOM_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<ClassroomlistVM> getDatalist()
        public ClassroomdetailVM getData(int? id = null)
        {
            ClassroomdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Classroom_infos
                           where tb.ID == id
                           select new ClassroomdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_SHORTDESC = tb.CLASSROOM_SHORTDESC,
                               CLASSROOM_DESC = tb.CLASSROOM_DESC,
                               CLASSLEVEL_ID = tb.CLASSLEVEL_ID,
                               
                               CLASSLEVEL_SPP = tb.CLASSLEVEL_SPP,
                               CLASSLEVEL_SPPDENDA = tb.CLASSLEVEL_SPPDENDA,
                               CLASSLEVEL_SPPPINDAH = tb.CLASSLEVEL_SPPPINDAH,
                               CLASSLEVEL_SPPPINDAHDENDA = tb.CLASSLEVEL_SPPPINDAHDENDA,

                               CLASSLEVEL_SEMESTER = tb.CLASSLEVEL_SEMESTER,
                               CLASSLEVEL_SEMESTER2 = tb.CLASSLEVEL_SEMESTER2,
                               CLASSLEVEL_MIDSEMESTER = tb.CLASSLEVEL_MIDSEMESTER,
                               CLASSLEVEL_MIDSEMESTER2 = tb.CLASSLEVEL_MIDSEMESTER2,
                               CLASSLEVEL_DFTULANG = tb.CLASSLEVEL_DFTULANG,
                               CLASSLEVEL_AKHIRTAHUN = tb.CLASSLEVEL_AKHIRTAHUN,
                               CLASSLEVEL_FORMULIR = tb.CLASSLEVEL_FORMULIR,
                               CLASSLEVEL_PANGKAL = tb.CLASSLEVEL_PANGKAL,
                               CLASSLEVEL_PRAKERIN = tb.CLASSLEVEL_PRAKERIN,
                               CLASSLEVEL_EKSKUL = tb.CLASSLEVEL_EKSKUL,
                               CLASSLEVEL_STUDI = tb.CLASSLEVEL_STUDI,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public ClassroomdetailVM getData(int? id = null)


        public List<ClassroomdetailVM> getDatalist_lookup()
        {
            List<ClassroomdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Classrooms
                           select new ClassroomdetailVM
                           {
                               ID = tb.ID,
                               CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_SHORTDESC = tb.CLASSROOM_SHORTDESC,
                               CLASSROOM_DESC = tb.CLASSROOM_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<ClassroomlookupVM> getDatalist_lookup()
    } //End public class ClassroomDS
} //End namespace APPBASE.Models
