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
using APPBASE;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public partial class User_Validation
    {
        private void Validate_USERNAMENEW()
        {
            Boolean bIsvalid = true;
            //[Username] - Required
            if ((oViewModel.USERNAME == "") || (oViewModel.USERNAME == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USERNAME1";
                oMSG.VAL_ERRMSG = "Username harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[USERNAME] - Unique
            if (oDS.isExists_Username(oViewModel.USERNAME))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USERNAME2";
                oMSG.VAL_ERRMSG = "Username " + oViewModel.ID + " sudah digunakan";
                aValidationMSG.Add(oMSG);
            } //End if

            //[ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USERNAME0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_USERNAMENEW()
        private void Validate_USERNAMEEDIT()
        {
            Boolean bIsvalid = true;
            //[Username] - Required
            if ((oViewModel.USERNAME == "") || (oViewModel.USERNAME == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USERNAME1";
                oMSG.VAL_ERRMSG = "Username harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USERNAME0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_USERNAMEEDIT()
        private void Validate_PASSWORD()
        {
            Boolean bIsvalid = true;
            //[Password] - Required
            if ((oViewModel.PASSWORD == "") || (oViewModel.PASSWORD == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PASSWORD1";
                oMSG.VAL_ERRMSG = "Password harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PASSWORD0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_PASSWORD()
        private void Validate_DISPLAY_NAME()
        {
            Boolean bIsvalid = true;
            //[Password] - Required
            if ((oViewModel.DISPLAY_NAME == "") || (oViewModel.DISPLAY_NAME == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "DISPLAY_NAME1";
                oMSG.VAL_ERRMSG = "Nama Alias harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "DISPLAY_NAME0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_PASSWORD()
        private void Validate_EMAIL()
        {
            Boolean bIsvalid = true;
            //[Password] - Required
            if ((oViewModel.EMAIL != "") && (oViewModel.EMAIL != null))
            {
                if (!hlpValidation.isValidEmail(oViewModel.EMAIL)) {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "EMAIL1";
                    oMSG.VAL_ERRMSG = "Format email tidak sesuai (contoh yang benar : example@email.com)";
                    aValidationMSG.Add(oMSG);
                } //End if (!hlpValidation.isValidEmail(oViewModel.EMAIL))
            } //End if
            //[ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "EMAIL0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_PASSWORD()
        private void Validate_ROLE_ID()
        {
            Boolean bIsvalid = true;
            //[Password] - Required
            if (oViewModel.ROLE_ID == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "ROLE_ID1";
                oMSG.VAL_ERRMSG = "Hak akses harus ditentukan";
                aValidationMSG.Add(oMSG);
            } //End if
            //[ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "ROLE_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_ROLE_ID()
        private void Validate_RES_ID()
        {
            Boolean bIsvalid = true;
            //[Password] - Required
            if (oViewModel.RES_ID == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "RES_ID1";
                oMSG.VAL_ERRMSG = "Harap pilih karyawan";
                aValidationMSG.Add(oMSG);
            } //End if
            //[ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "RES_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_RES_ID()

        private void Validate_CHANGEPASSWORD()
        {
            Boolean bIsvalid = true;

            /*USERNAME ----------------------------------------------------------*/
            //[USERNAME] - Required
            if ((oViewModel_CHANGEPASSWORD.USERNAME == "") || (oViewModel_CHANGEPASSWORD.USERNAME == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USERNAME1";
                oMSG.VAL_ERRMSG = "Username harus diisi";
                aValidationMSG.Add(oMSG);
            }
            else {
                if (oViewModel_CHANGEPASSWORD.USERNAME.ToUpper() != oViewModel_CHANGEPASSWORD.USERNAME_DB.ToUpper())
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "USERNAME2";
                    oMSG.VAL_ERRMSG = "Username Salah";
                    aValidationMSG.Add(oMSG);
                }
            }//End if
            //[ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USERNAME0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if


            /*PASSWORD----------------------------------------------------------*/
            bIsvalid = true;
            //[PASSWORD] - Required
            if ((oViewModel_CHANGEPASSWORD.PASSWORD == "") || (oViewModel_CHANGEPASSWORD.PASSWORD == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PASSWORD1";
                oMSG.VAL_ERRMSG = "Password harus diisi";
                aValidationMSG.Add(oMSG);
            }
            else {
                if (oViewModel_CHANGEPASSWORD.PASSWORD != oViewModel_CHANGEPASSWORD.PASSWORD_DB) {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "PASSWORD2";
                    oMSG.VAL_ERRMSG = "Password lama salah";
                    aValidationMSG.Add(oMSG);
                }
            } //End if
            //[ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PASSWORD0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if


            /*PASSWORD_NEW----------------------------------------------------------*/
            //[PASSWORD_NEW] - Required
            if ((oViewModel_CHANGEPASSWORD.PASSWORD_NEW == "") || (oViewModel_CHANGEPASSWORD.PASSWORD_NEW == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PASSWORD_NEW1";
                oMSG.VAL_ERRMSG = "Password baru harus diisi";
                aValidationMSG.Add(oMSG);
            }
            else {
                if (oViewModel_CHANGEPASSWORD.PASSWORD == oViewModel_CHANGEPASSWORD.PASSWORD_NEW)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "PASSWORD_NEW2";
                    oMSG.VAL_ERRMSG = "Password baru harus beda dengan password lama";
                    aValidationMSG.Add(oMSG);
                }
            } //End if
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PASSWORD_NEW0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if


            /*PASSWORD_RETYPENEW----------------------------------------------------------*/
            //[PASSWORD_RETYPENEW] - Required
            if ((oViewModel_CHANGEPASSWORD.PASSWORD_RETYPENEW == "") || (oViewModel_CHANGEPASSWORD.PASSWORD_RETYPENEW == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PASSWORD_RETYPENEW1";
                oMSG.VAL_ERRMSG = "Password harus diketik ulang";
                aValidationMSG.Add(oMSG);
            }
            else
            {
                if (oViewModel_CHANGEPASSWORD.PASSWORD_NEW != oViewModel_CHANGEPASSWORD.PASSWORD_RETYPENEW)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "PASSWORD_RETYPENEW2";
                    oMSG.VAL_ERRMSG = "Password baru harus diketik ulang";
                    aValidationMSG.Add(oMSG);
                }
            } //End if
            //[ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PASSWORD_RETYPENEW0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_PASSWORD()
    } //End public partial class User_Validation
} //End namespace APPBASE.Models

