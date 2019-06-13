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
    public class AboutusDS
    {
        //Constructor
        public AboutusDS() { } //End public AboutusDS
        public List<AboutuslistVM> getDatalist()
        {
            List<AboutuslistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Aboutuss
                           select new AboutuslistVM
                           {
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<AboutuslistVM> getDatalist()
        public AboutusdetailVM getData()
        {
            AboutusdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Aboutuss
                           select new AboutusdetailVM
                           {
                               ID = tb.ID,
                               SHORT_DESC = tb.SHORT_DESC,
                               FULL_DESC = tb.FULL_DESC
                           };
                oReturn = oQRY.FirstOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public AboutusdetailVM getData(int? id = null)


        public List<AboutuslookupVM> getDatalist_lookup()
        {
            List<AboutuslookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Aboutuss
                           select new AboutuslookupVM
                           {
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<AboutuslookupVM> getDatalist_lookup()
    } //End public class AboutusDS
} //End namespace APPBASE.Models
