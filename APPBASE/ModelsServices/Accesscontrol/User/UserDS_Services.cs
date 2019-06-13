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
    public class UserDS
    {
        //Constructor
        public UserDS() { } //End public UserDS
        
        //Data List
        public List<UserlistVM> getDatalist()
        {
            List<UserlistVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.User_infos
                           select new UserlistVM
                           {
                               ID = tb.ID,
                               DISPLAY_NAME = tb.DISPLAY_NAME,
                               ROLE_DISPLAY_NAME = tb.ROLE_DISPLAY_NAME,
                               USER_STS = tb.USER_STS
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<User_ListVM> getDatalist()
        //Data List HQ
        public List<UserlistVM> getDatalist_HQ()
        {
            List<UserlistVM> vReturn;
            //SM-SA-PC
            var RoleID_list = new int?[] { 1, 2, 3 };

            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.User_infos
                           select new UserlistVM
                           {
                               ID = tb.ID,
                               ROLE_ID = tb.ROLE_ID,
                               DISPLAY_NAME = tb.DISPLAY_NAME,
                               ROLE_DISPLAY_NAME = tb.ROLE_DISPLAY_NAME,
                               USER_STS = tb.USER_STS
                           };
                vReturn = oQRY.Where(fld => RoleID_list.Contains(fld.ROLE_ID)).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<User_ListVM> getDatalist_HQ()
        //Data List Branch
        public List<UserlistVM> getDatalist_Branch()
        {
            List<UserlistVM> vReturn;
            //SC-CT-ADM
            var RoleID_list = new int?[] { 4, 5, 6 };

            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.User_infos
                           select new UserlistVM
                           {
                               ID = tb.ID,
                               ROLE_ID = tb.ROLE_ID,
                               DISPLAY_NAME = tb.DISPLAY_NAME,
                               ROLE_DISPLAY_NAME = tb.ROLE_DISPLAY_NAME,
                               USER_STS = tb.USER_STS
                           };
                vReturn = oQRY.Where(fld => RoleID_list.Contains(fld.ROLE_ID)).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<User_ListVM> getDatalist_Branch()
        //Data List Parent
        public List<UserlistVM> getDatalist_Parent()
        {
            List<UserlistVM> vReturn;

            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.User_infos
                           select new UserlistVM
                           {
                               ID = tb.ID,
                               ROLE_ID = tb.ROLE_ID,
                               DISPLAY_NAME = tb.DISPLAY_NAME,
                               ROLE_DISPLAY_NAME = tb.ROLE_DISPLAY_NAME,
                               USER_STS = tb.USER_STS
                           };
                vReturn = oQRY.Where(fld => fld.ROLE_ID==7).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<User_ListVM> getDatalist_Parent()
        
        //Data Single
        public UserdetailVM getData(int? id = null)
        {
            UserdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.User_infos
                           where tb.ID == id
                           select new UserdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               RES_ID = tb.RES_ID,
                               ROLE_ID = tb.ROLE_ID,
                               USERNAME = tb.USERNAME,
                               PASSWORD = tb.PASSWORD,
                               DISPLAY_NAME = tb.DISPLAY_NAME,
                               EMAIL = tb.EMAIL,
                               USER_STS = tb.USER_STS,
                               USER_IMG = tb.USER_IMG,
                               BRANCH_ID = tb.BRANCH_ID,
                               MDLE_ID = tb.MDLE_ID,
                               ROLE_CD = tb.ROLE_CD,
                               ROLE_DISPLAY_NAME = tb.ROLE_DISPLAY_NAME,
                               BRANCH_TYPE = tb.BRANCH_TYPE,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               RES_NIP = tb.RES_NIP,
                               RES_NAME = tb.RES_NAME
                           };
                oReturn = oQRY.SingleOrDefault();
                oReturn.PASSWORD = hlpObf.randomDecrypt(oReturn.PASSWORD);
            } //End using (var = new DbContext())
            return oReturn;
        } //End public User_DetailVM getData(string id = null)
        public UsercredentialVM getData_Usercredential(string psUsername = null)
        {
            UsercredentialVM oReturn;

            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Users
                           where tb.USERNAME.ToUpper() == psUsername.ToUpper()
                           select new UsercredentialVM
                           {
                               RES_ID = tb.RES_ID,
                               USERNAME = tb.USERNAME,
                               PASSWORD = tb.PASSWORD,
                               DISPLAY_NAME = tb.DISPLAY_NAME,
                               ID = tb.ID,
                               ROLE_ID = tb.ROLE_ID,
                               USER_IMG = tb.USER_IMG
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public User_DetailVM getData(string id = null)
        public UserdetailVM getData_RES_ID(int? id = null)
        {
            UserdetailVM oReturn;
            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.User_infos
                           where tb.ID == id
                           select new UserdetailVM
                           {RES_ID = tb.RES_ID};
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public UserdetailVM getData_RES_ID(int? id = null)

        public UserdetailHQVM getDataHQ(int? id = null)
        {
            UserdetailHQVM oReturn;
            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.UserHQ_infos
                           where tb.ID == id
                           select new UserdetailHQVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               RES_ID = tb.RES_ID,
                               ROLE_ID = tb.ROLE_ID,
                               USERNAME = tb.USERNAME,
                               PASSWORD = tb.PASSWORD,
                               DISPLAY_NAME = tb.DISPLAY_NAME,
                               EMAIL = tb.EMAIL,
                               USER_STS = tb.USER_STS,
                               USER_IMG = tb.USER_IMG,
                               BRANCH_ID = tb.BRANCH_ID,
                               MDLE_ID = tb.MDLE_ID,
                               ROLE_CD = tb.ROLE_CD,
                               ROLE_DISPLAY_NAME = tb.ROLE_DISPLAY_NAME,
                               BRANCH_TYPE = tb.BRANCH_TYPE,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               RES_NAME = tb.RES_NAME,
                               RES_NIP = tb.RES_NIP,
                               RES_JOBTITLE_ID = tb.RES_JOBTITLE_ID,
                               JOBTITLE_CODE = tb.JOBTITLE_CODE,
                               JOBTITLE_DESC = tb.JOBTITLE_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
                oReturn.PASSWORD = hlpObf.randomDecrypt(oReturn.PASSWORD);
            } //End using (var = new DbContext())
            return oReturn;
        } //End public User_DetailVM getDataHQ(int? id = null)
        public UserdetailBRANCHVM getDataBRANCH(int? id = null)
        {
            UserdetailBRANCHVM oReturn;
            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.UserBRANCH_infos
                           where tb.ID == id
                           select new UserdetailBRANCHVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               RES_ID = tb.RES_ID,
                               ROLE_ID = tb.ROLE_ID,
                               USERNAME = tb.USERNAME,
                               PASSWORD = tb.PASSWORD,
                               DISPLAY_NAME = tb.DISPLAY_NAME,
                               EMAIL = tb.EMAIL,
                               USER_STS = tb.USER_STS,
                               USER_IMG = tb.USER_IMG,
                               BRANCH_ID = tb.BRANCH_ID,
                               MDLE_ID = tb.MDLE_ID,
                               ROLE_CD = tb.ROLE_CD,
                               ROLE_DISPLAY_NAME = tb.ROLE_DISPLAY_NAME,
                               BRANCH_TYPE = tb.BRANCH_TYPE,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               RES_NAME = tb.RES_NAME,
                               RES_NIP = tb.RES_NIP,
                               RES_JOBTITLE_ID = tb.RES_JOBTITLE_ID,
                               JOBTITLE_CODE = tb.JOBTITLE_CODE,
                               JOBTITLE_DESC = tb.JOBTITLE_DESC
                           };
                oReturn = oQRY.SingleOrDefault();
                oReturn.PASSWORD = hlpObf.randomDecrypt(oReturn.PASSWORD);
            } //End using (var = new DbContext())
            return oReturn;
        } //End public User_DetailVM getDataBRANCH(int? id = null)
        public UserdetailPARENTVM getDataPARENT(int? id = null)
        {
            UserdetailPARENTVM oReturn;
            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.UserPARENT_infos
                           where tb.ID == id
                           select new UserdetailPARENTVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               RES_ID = tb.RES_ID,
                               ROLE_ID = tb.ROLE_ID,
                               USERNAME = tb.USERNAME,
                               PASSWORD = tb.PASSWORD,
                               DISPLAY_NAME = tb.DISPLAY_NAME,
                               EMAIL = tb.EMAIL,
                               USER_STS = tb.USER_STS,
                               USER_IMG = tb.USER_IMG,
                               BRANCH_ID = tb.BRANCH_ID,
                               MDLE_ID = tb.MDLE_ID,
                               ROLE_CD = tb.ROLE_CD,
                               ROLE_DISPLAY_NAME = tb.ROLE_DISPLAY_NAME,
                               RES_NAME = tb.RES_NAME,
                               RES_NIS = tb.RES_NIS,
                               RES_YEAR_ID = tb.RES_YEAR_ID,
                               RES_SEMESTER_ID = tb.RES_SEMESTER_ID,
                               RES_CLASSTYPE_ID = tb.RES_CLASSTYPE_ID,
                               RES_YEAR_DESC = tb.RES_YEAR_DESC,
                               RES_SEMESTER_DESC = tb.RES_SEMESTER_DESC,
                               RES_CLASSTYPE_DESC = tb.RES_CLASSTYPE_DESC

                           };
                oReturn = oQRY.SingleOrDefault();
                oReturn.PASSWORD = hlpObf.randomDecrypt(oReturn.PASSWORD);
            } //End using (var = new DbContext())
            return oReturn;
        } //End public User_DetailVM getDataPARENT(int? id = null)


        //Check Exists
        public Boolean isExists_Username(string psUsername = null)
        {


            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.User_infos
                            where tb.USERNAME == psUsername
                            select new { USERNAME = tb.USERNAME }).ToList();

                if (oQRY.Count > 0) { return true; }


            } //End using (var = new DbContext())
            return false;
        } //End public Boolean isExists_USR_ID(string id = null)
        //Check Granted user to menu
        public Boolean isGranted_menu(int? pnRoleId = null, int? pnMenuId = null)
        {
            Boolean vReturn = false;

            using (var db = new DBMAINContext())
            {
                //var oQRY = (from tb in db.Usermenus
                //            where tb.MNU_RUID == id && tb.MDLE_RUID == sMDLE_RUID && tb.USR_RUID == sUSR_RUID
                //            select new { MNU_RUID = tb.MNU_RUID }).ToList();

                //if (oQRY.Count > 0) { vReturn = true; }


            } //End using (var = new DbContext())
            return vReturn;
        } //End public Boolean isExists_USR_ID(string id = null)


        //Data List Branch
        public List<UseremployeelookupVM> getDatalistBranchTeacher_lookup()
        {
            List<UseremployeelookupVM> vReturn;

            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.UserBRANCH_infos
                           select new UseremployeelookupVM
                           {
                               ID = tb.ID,
                               ROLE_ID = tb.ROLE_ID,
                               DISPLAY_NAME = tb.DISPLAY_NAME,
                               ROLE_DISPLAY_NAME = tb.ROLE_DISPLAY_NAME,
                               USER_STS = tb.USER_STS,
                               RES_NAME = tb.RES_NAME,
                               RES_NIP = tb.RES_NIP,
                               JOBTITLE_DESC = tb.JOBTITLE_DESC
                           };
                vReturn = oQRY.Where(fld => fld.ROLE_ID == valFLAG.FLAG_ROLE_CT).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<User_ListVM> getDatalist_Branch()
    
    } //End public class UserDS
} //End namespace APPBASE.Models

