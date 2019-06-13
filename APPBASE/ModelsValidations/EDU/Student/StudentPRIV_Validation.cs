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
    public partial class Student_Validation
    {
        private void Validate_ID()
        {
            Boolean bIsvalid = true;
            ////[ID] - Required
            //if ((oViewModel.ID == "") || (oViewModel.ID == null))
            //{
            //    bIsvalid = false;
            //    ValidationMSG_VM oMSG = new ValidationMSG_VM();
            //    oMSG.VAL_ERRID = "ID1";
            //    oMSG.VAL_ERRMSG = "ID harus diisi";
            //    aValidationMSG.Add(oMSG);
            //} //End if

            ////[ID] - Unique
            //if (oDS.isExists_ID(oViewModel.ID))
            //{
            //    bIsvalid = false;
            //    ValidationMSG_VM oMSG = new ValidationMSG_VM();
            //    oMSG.VAL_ERRID = "ID2";
            //    oMSG.VAL_ERRMSG = "ID " + oViewModel.ID + " sudah digunakan";
            //    aValidationMSG.Add(oMSG);
            //} //End if

            //[ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_ID()
        private void Validate_CLASSROOM_ID()
        {
            Boolean bIsvalid = true;
            //[CLASSROOM_ID] - Required
            if (oViewModel.CLASSROOM_ID == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CLASSROOM_ID1";
                oMSG.VAL_ERRMSG = "Kelas harus dipilih";
                aValidationMSG.Add(oMSG);
            } //End if
            //[CLASSROOM_ID] - Unique
            //if (oDS.isExists_CLASSROOM_ID(oViewModel.CLASSROOM_ID))
            //{
            //    bIsvalid = false;
            //    ValidationMSG_VM oMSG = new ValidationMSG_VM();
            //    oMSG.VAL_ERRID = "CLASSROOM_ID2";
            //    oMSG.VAL_ERRMSG = "CLASSROOM_ID " + oViewModel.CLASSROOM_ID + " sudah digunakan";
            //    aValidationMSG.Add(oMSG);
            //} //End if

            //[CLASSROOM_ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CLASSROOM_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_CLASSROOM_ID()
        private void Validate_NIS()
        {
            Boolean bIsvalid = true;
            //[NIS] - Required
            if ((oViewModel.NIS == "") || (oViewModel.NIS == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "NIS1";
                oMSG.VAL_ERRMSG = "Nomor induk siswa harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[NIS] - Unique
            if (oDS.isExists_NIS(oViewModel.NIS))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "NIS2";
                oMSG.VAL_ERRMSG = "NIS " + oViewModel.NIS + " sudah digunakan";
                aValidationMSG.Add(oMSG);
            } //End if

            //[NIS] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "NIS0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_NIS()
        private void Validate_NIS_EDIT()
        {
            Boolean bIsvalid = true;
            //[NIS] - Required
            if ((oViewModel.NIS == "") || (oViewModel.NIS == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "NIS1";
                oMSG.VAL_ERRMSG = "Nomor induk siswa harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[NIS] - Unique
            if (oDS.isExists_NIS(oViewModel.ID, oViewModel.NIS))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "NIS2";
                oMSG.VAL_ERRMSG = "NIS " + oViewModel.NIS + " sudah digunakan";
                aValidationMSG.Add(oMSG);
            } //End if

            //[NIS] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "NIS0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_NIS()

        private void Validate_NAME()
        {
            Boolean bIsvalid = true;
            //[NAME] - Required
            if ((oViewModel.NAME == "") || (oViewModel.NAME == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "NAME1";
                oMSG.VAL_ERRMSG = "Nama siswa harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[NAME] - Unique
            //if (oDS.isExists_NAME(oViewModel.NAME))
            //{
            //    bIsvalid = false;
            //    ValidationMSG_VM oMSG = new ValidationMSG_VM();
            //    oMSG.VAL_ERRID = "NAME2";
            //    oMSG.VAL_ERRMSG = "NAME " + oViewModel.NAME + " sudah digunakan";
            //    aValidationMSG.Add(oMSG);
            //} //End if

            //[NAME] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "NAME0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_NAME()

        private void Validate_FILTER_YEAR_ID()
        {
            Boolean bIsvalid = true;
            //[FILTER_YEAR_ID] - Required
            if (oViewModelfilter.FILTER_YEAR_ID == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FILTER_YEAR_ID1";
                oMSG.VAL_ERRMSG = "Tahun ajaran harus dipilih";
                aValidationMSG.Add(oMSG);
            } //End if

            //[FILTER_YEAR_ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FILTER_YEAR_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_FILTER_YEAR_ID()
        private void Validate_FILTER_SEMESTER_ID()
        {
            Boolean bIsvalid = true;
            //[FILTER_SEMESTER_ID] - Required
            if (oViewModelfilter.FILTER_SEMESTER_ID == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FILTER_SEMESTER_ID1";
                oMSG.VAL_ERRMSG = "Semester harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[FILTER_SEMESTER_ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FILTER_SEMESTER_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_FILTER_SEMESTER_ID()
        private void Validate_FILTER_CLASSTYPE_ID()
        {
            Boolean bIsvalid = true;
            //[FILTER_CLASSTYPE_ID] - Required
            if (oViewModelfilter.FILTER_CLASSTYPE_ID == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FILTER_CLASSTYPE_ID1";
                oMSG.VAL_ERRMSG = "Kelas harus dipilih";
                aValidationMSG.Add(oMSG);
            } //End if

            //[FILTER_CLASSTYPE_ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FILTER_CLASSTYPE_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_FILTER_CLASSTYPE_ID()
        private void Validate_FILTER_BRANCH_ID()
        {
            Boolean bIsvalid = true;
            //[FILTER_BRANCH_ID] - Required
            if (oViewModelfilter.FILTER_BRANCH_ID == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FILTER_BRANCH_ID1";
                oMSG.VAL_ERRMSG = "Cabang/Pusat harus dipilih";
                aValidationMSG.Add(oMSG);
            } //End if

            //[FILTER_BRANCH_ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "FILTER_BRANCH_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_FILTER_BRANCH_ID()

    } //End public partial class Student_Validation
} //End namespace APPBASE.Models
