using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcapp;
using APPBASE.Svcutil;

namespace APPBASE.Helpers
{
    public class hlpCredentialInfo
    {
        //public static Boolean
        public static void isValidCredential(ActionExecutedContext context)
        {
            Boolean isValidtocheck = true;
            //Validate DB and APP sysdate
            isValidtocheck = isValidSYSDATE(context);
            //Validate Is User logged in
            if (isValidtocheck) { isValidtocheck = isLoggedin(context); } //End if (isValidtocheck)
            //Validate user access control
            if (isValidtocheck) { isValidtocheck = isValidRole(context); } //End if (isValidtocheck)
            //Validate Tahun Ajaran
            if (isValidtocheck) { AutocreateYear(context); } //End if (isValidtocheck)
        } //End public static string isValidCredential

        public static Boolean isLoggedin(ActionExecutedContext context) {
            Boolean vReturn = true;
            if ((hlpConfig.SessionInfo.getAppUsername() == "") ||
                (hlpConfig.SessionInfo.getAppUsername() == null)) {
                vReturn = false;
                context.Result = new RedirectToRouteResult(new RouteValueDictionary 
                { 
                    { "controller", "Account" }, 
                    { "action", "Login" }
                });
            } //End if ((hlpConfig.SessionInfo.getAppUsername() == "") ||

            return vReturn;
        } //End public static Boolean isLoggedin(ActionExecutedContext context)
        public static Boolean isValidSYSDATE(ActionExecutedContext context)
        {
            Boolean vReturn = true;

            try
            {
                DateTime? DBSysdate = new SysinfoDS().getData().SYSDATE.Value.Date;
                DateTime? APPSysdate = DateTime.Now.Date;
                if (DBSysdate != APPSysdate) {
                    vReturn = false;
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary 
                    { 
                        { "controller", "Error" }, 
                        { "action", "ErrorSYSDATE" } 
                    }); //End context.Result = new RedirectToRouteResult(new RouteValueDictionary 
                } //End if (DBSysdate != APPSysdate)
            } //End try
            catch (Exception e) { }

            return vReturn;
        } //End public static Boolean isValidSYSDATE(ActionExecutedContext context)
        public static void AutocreateYear(ActionExecutedContext context)
        {

            try {
                SysinfoDS oDSSysinfo = new SysinfoDS();
                YearDS oDSYear = new YearDS();
                var oData = oDSYear.getData_byPeriod(oDSSysinfo.getSYSDATE());



                if (oData == null)
                {
                    YearCRUD oCRUD = new YearCRUD();
                    oCRUD.Create();
                }
                else if (oData.ID == null)
                {
                    YearCRUD oCRUD = new YearCRUD();
                    oCRUD.Create();
                } //End if (oData.ID == null)
            } //End try
            catch (Exception e) { }
        } //End public static void AutocreateYear(ActionExecutedContext context)

        public static Boolean isValidDBLogin(string psUsername, string psPassword, int? pnMdleId)
        {
            UserloginVM oVM = new UserloginVM(); ;


            //if Ultimate User
            if ((psUsername.ToUpper() == valDFLT.SYSADMIN_USER) && (psPassword == valDFLT.SYSADMIN_PASSWORD)) {
                setValidCredential(psUsername, valDFLT.SYSADMIN_USER, null, null, hlpConfig.ConstantaInfo.MDLE_ID);
                return true;
            } //End if ((psUsername.ToUpper() == "SYSADMIN") && (psPassword == "kuy4bulu5"))
            
            //if selain Ultimate User
            UserDS oDS = new UserDS();
            var oQRY = oDS.getData_Usercredential(psUsername);
            if (oQRY != null) {
                string stes = hlpObf.randomDecrypt(oQRY.PASSWORD);
                if ((psUsername.ToUpper() == oQRY.USERNAME.ToUpper()) &&
                    (psPassword == hlpObf.randomDecrypt(oQRY.PASSWORD)))
                {
                    //setValidCredential(psUsername, oQRY.DISPLAY_NAME, oQRY.ID, oQRY.ROLE_ID, hlpConfig.ConstantaInfo.MDLE_ID);
                    setValidCredential(psUsername, oQRY, hlpConfig.ConstantaInfo.MDLE_ID);
                    return true;
                } //End if ((psUsername.ToUpper() == oQRY.USERNAME) &&
            } //End if (oQRY != null)
            return false;
        } //End public static Boolean isValidDBLogin
        public static void setValidCredential(string psUsername = null, string psUserdisplayname = null, int? pnUserId = null, int? pnRoleId = null, int? pnMdleId = null)
        {
            hlpConfig.SessionInfo.setAppUsername(psUsername);
            hlpConfig.SessionInfo.setAppUserdisplayname(psUserdisplayname);
            hlpConfig.SessionInfo.setAppUserId(pnUserId);
            hlpConfig.SessionInfo.setAppRoleId(pnRoleId);
            hlpConfig.SessionInfo.setAppMdleId(pnMdleId);
        } //End public static void setValidCredential()
        public static void setValidCredential(string psUsername = null, UsercredentialVM poViewmodel = null, int? pnMdleId = null)
        {
            hlpConfig.SessionInfo.setAppUsername(psUsername);
            hlpConfig.SessionInfo.setAppUserdisplayname(poViewmodel.DISPLAY_NAME);
            hlpConfig.SessionInfo.setAppUserId(poViewmodel.ID);
            hlpConfig.SessionInfo.setAppRoleId(poViewmodel.ROLE_ID);
            hlpConfig.SessionInfo.setAppResId(poViewmodel.RES_ID);
            hlpConfig.SessionInfo.setAppMdleId(pnMdleId);
            hlpConfig.SessionInfo.setAppUserIMG(poViewmodel.USER_IMG);
        } //End public static void setValidCredential()
        public static Boolean isValidRole_menu(string psUsername, int? pnRoleId = null, int? pnMenuId = null)
        {
            if (psUsername.ToUpper() == valDFLT.SYSADMIN_USER) return true;
            //UserDS oDS = new UserDS();
            RolemenuDS oDS = new RolemenuDS();
            return oDS.isGranted_menu(pnRoleId, pnMenuId);
        } //End public static Boolean isValidRole_menu(string psUsername, int? pnRoleId = null, int? pnMenuId = null)
        public static Boolean isValidRole(ActionExecutedContext context)
        {
            Boolean vReturn = true;
            string sUsername = hlpConfig.SessionInfo.getAppUsername();
            int? nRoleId = hlpConfig.SessionInfo.getAppRoleId();
            int? nMenuId = context.Controller.ViewBag.AC_MENU_ID;

            if ((nMenuId != null) && (sUsername != "")) {

                vReturn = isValidRole_menu(sUsername, nRoleId, nMenuId);

                if (!vReturn)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary 
                    { 
                        { "controller", "Error" }, 
                        { "action", "Error403" } 
                    }); //End context.Result = new RedirectToRouteResult(new RouteValueDictionary
                } //End if (!vReturn)
            } //End if (sAC_MENU_RUID != null)

            return vReturn;
        } //End public static Boolean isValidRole(ActionExecutedContext context)
    } //End public class CredentialInfo
} //End namespace APPBASE.Helper
