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
    public class StudentstsDS
    {
        //Constructor
        public StudentstsDS() { } //End public StudentstsDS
        public List<StudentstslistVM> getDatalist()
        {
            List<StudentstslistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Studentstss
                           select new StudentstslistVM
                           {
                               ID = tb.ID,
                               LOV_DESC = tb.LOV_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<StudentstslistVM> getDatalist()
        public StudentstsdetailVM getData(int? id = null)
        {
            StudentstsdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Studentstss
                           where tb.ID == id
                           select new StudentstsdetailVM
                           {
                               ID = tb.ID,
                               LOV_DESC = tb.LOV_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public StudentstsdetailVM getData(int? id = null)


        public List<StudentstslookupVM> getDatalist_lookup()
        {
            List<StudentstslookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Studentstss
                           select new StudentstslookupVM
                           {
                               ID = tb.ID,
                               LOV_DESC = tb.LOV_DESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<StudentstslookupVM> getDatalist_lookup()
    } //End public class StudentstsDS
} //End namespace APPBASE.Models
