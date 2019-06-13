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
    public class ClassmajorDS
    {
        //Constructor
        public ClassmajorDS() { } //End public ClassmajorDS
        public List<ClassmajordetailVM> getDatalist()
        {
            List<ClassmajordetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Classmajor_infos
                           select new ClassmajordetailVM
                           {
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<ClassmajorlistVM> getDatalist()
        public ClassmajordetailVM getData(int? id = null)
        {
            ClassmajordetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Classmajor_infos
                           where tb.ID == id
                           select new ClassmajordetailVM
                           {
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public ClassmajordetailVM getData(int? id = null)


        public List<ClassmajordetailVM> getDatalist_lookup()
        {
            List<ClassmajordetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Classmajor_infos
                           select new ClassmajordetailVM
                           {
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<ClassmajorlookupVM> getDatalist_lookup()
    } //End public class ClassmajorDS
} //End namespace APPBASE.Models
