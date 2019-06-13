﻿using System;
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
    public class BranchDS
    {
        //Constructor
        public BranchDS() { } //End public BranchDS
        public List<BranchdetailVM> getDatalist()
        {
            List<BranchdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Branch_infos
                           select new BranchdetailVM
                           {
                               ID = tb.ID,
                               BRANCH_TYPE = tb.BRANCH_TYPE,
                               BRANCH_CODE = tb.BRANCH_CODE,
                               BRANCH_SHORTDESC = tb.BRANCH_SHORTDESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<BranchlistVM> getDatalist()
        public BranchdetailVM getData(int? id = null)
        {
            BranchdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Branch_infos
                           where tb.ID == id
                           select new BranchdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               BRANCH_TYPE = tb.BRANCH_TYPE,
                               BRANCH_CODE = tb.BRANCH_CODE,
                               BRANCH_SHORTDESC = tb.BRANCH_SHORTDESC,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               ADDR_CITY = tb.ADDR_CITY,
                               ADDR_KEC = tb.ADDR_KEC,
                               ADDR_KEL = tb.ADDR_KEL,
                               ADDR_ZIP = tb.ADDR_ZIP,
                               ADDR_STREET1 = tb.ADDR_STREET1,
                               ADDR_STREET2 = tb.ADDR_STREET2,
                               PHONE = tb.PHONE,
                               FAX = tb.FAX,
                               EMAIL = tb.EMAIL
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public BranchdetailVM getData(int? id = null)
        public List<BranchdetailVM> getDatalist_lookup()
        {
            List<BranchdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Branch_infos
                           select new BranchdetailVM
                           {
                               ID = tb.ID,
                               BRANCH_TYPE = tb.BRANCH_TYPE,
                               BRANCH_CODE = tb.BRANCH_CODE,
                               BRANCH_SHORTDESC = tb.BRANCH_SHORTDESC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CitylookupVM> getDatalist_lookup()
    } //End public class BranchDS
} //End namespace APPBASE.Models

