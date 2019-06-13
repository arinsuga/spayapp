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
    public class ClasstypeDS
    {
        //Constructor
        public ClasstypeDS() { } //End public ClasstypeDS
        public List<ClasstypedetailVM> getDatalist()
        {
            List<ClasstypedetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Classtypes
                           select new ClasstypedetailVM
                           {
                               ID = tb.ID,
                               CLASSTYPE_CODE = tb.CLASSTYPE_CODE,
                               CLASSTYPE_SHORTDESC = tb.CLASSTYPE_SHORTDESC,
                               CLASSTYPE_NUM = tb.CLASSTYPE_NUM
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<ClasstypelistVM> getDatalist()
        public ClasstypedetailVM getData(int? id = null)
        {
            ClasstypedetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Classtypes
                           where tb.ID == id
                           select new ClasstypedetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               CLASSTYPE_CODE = tb.CLASSTYPE_CODE,
                               CLASSTYPE_SHORTDESC = tb.CLASSTYPE_SHORTDESC,
                               CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               CLASSTYPE_NUM = tb.CLASSTYPE_NUM
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public ClasstypedetailVM getData(int? id = null)
        public List<ClasstypedetailVM> getDatalist_lookup()
        {
            List<ClasstypedetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Classtypes
                           select new ClasstypedetailVM
                           {
                               ID = tb.ID,
                               CLASSTYPE_CODE = tb.CLASSTYPE_CODE,
                               CLASSTYPE_SHORTDESC = tb.CLASSTYPE_SHORTDESC,
                               CLASSTYPE_NUM = tb.CLASSTYPE_NUM
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<ClasstypelookupVM> getDatalist_lookup()

    } //End public class ClasstypeDS
} //End namespace APPBASE.Models

