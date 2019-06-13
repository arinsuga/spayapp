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
    public class StudentDS
    {
        //Constructor
        public StudentDS() { } //End public StudentDS
        public List<StudentdetailVM> getDatalist(StudentVM poViewModel = null)
        {
            List<StudentdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           select new StudentdetailVM
                           {
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSTYPE_CODE = tb.CLASSTYPE_CODE,
                               CLASSTYPE_SHORTDESC = tb.CLASSTYPE_SHORTDESC,

                               CLASSLEVEL_ID = tb.CLASSLEVEL_ID,
                               CLASSLEVEL_CODE = tb.CLASSLEVEL_CODE,
                               CLASSLEVEL_SHORTDESC = tb.CLASSLEVEL_SHORTDESC,

                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_SHORTDESC = tb.CLASSROOM_SHORTDESC,

                               ID = tb.ID,
                               NAME=tb.NAME,
                               NIS=tb.NIS,
                               STUDENT_IMG = tb.STUDENT_IMG,
                               IS_PINDAHAN = tb.IS_PINDAHAN,
                               SPP_AMOUNT = tb.SPP_AMOUNT
                           };
                if (poViewModel != null)
                {
                    if (poViewModel.FILTER_BRANCH_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.BRANCH_ID == poViewModel.FILTER_BRANCH_ID);
                    } //End if (poViewModel.YEAR_ID != null)
                    if (poViewModel.FILTER_YEAR_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.YEAR_ID == poViewModel.FILTER_YEAR_ID);
                    } //End if (poViewModel.YEAR_ID != null)
                    if (poViewModel.FILTER_SEMESTER_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.SEMESTER_ID == poViewModel.FILTER_SEMESTER_ID);
                    } //End if (poViewModel.SEMESTER_ID != null)
                    if (poViewModel.FILTER_CLASSTYPE_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                    if (poViewModel.FILTER_CLASSTYPE_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                    if (poViewModel.FILTER_CLASSLEVEL_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSLEVEL_ID == poViewModel.FILTER_CLASSLEVEL_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                    if (poViewModel.FILTER_CLASSROOM_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSROOM_ID == poViewModel.FILTER_CLASSROOM_ID);
                    } //End if (poViewModel.FILTER_CLASSROOM_ID != null)
                    if (poViewModel.FILTER_NIS != null)
                    {
                        oQRY = oQRY.Where(fld => fld.NIS == poViewModel.FILTER_NIS);
                    } //End if (poViewModel.FILTER_NIS != null)
                } //End if (poViewModel != null)
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Student_ListVM> getDatalist()
        public StudentdetailVM getData(int? id = null)
        {
            StudentdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           where tb.ID == id
                           select new StudentdetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               NAME = tb.NAME,
                               NICKNAME = tb.NICKNAME,
                               NIS = tb.NIS,
                               NISN = tb.NISN,
                               PINREG = tb.PINREG,
                               REGNO = tb.REGNO,
                               REG_DT = tb.REG_DT,
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               SEX_ID = tb.SEX_ID,
                               POB = tb.POB,
                               DOB = tb.DOB,
                               RELIGION_ID = tb.RELIGION_ID,
                               NATIONALITY_ID = tb.NATIONALITY_ID,
                               LANGUAGE = tb.LANGUAGE,
                               ETHNIC = tb.ETHNIC,
                               CHILD_SEQ = tb.CHILD_SEQ,
                               CHILD_QTY = tb.CHILD_QTY,
                               ADDR_COUNTRY_ID = tb.ADDR_COUNTRY_ID,
                               ADDR_CITY = tb.ADDR_CITY,
                               ADDR_ZIP = tb.ADDR_ZIP,
                               ADDR_STREET1 = tb.ADDR_STREET1,
                               ADDR_STREET2 = tb.ADDR_STREET2,
                               HOME_PHONE = tb.HOME_PHONE,
                               CELL_PHONE = tb.CELL_PHONE,
                               EMAIL = tb.EMAIL,
                               PREV_SCHOOL_NAME = tb.PREV_SCHOOL_NAME,
                               PREV_SCHOOL_ADDR = tb.PREV_SCHOOL_ADDR,
                               BLOOD_TYPE_ID = tb.BLOOD_TYPE_ID,
                               WEIGHT_KG = tb.WEIGHT_KG,
                               HEIGHT_CM = tb.HEIGHT_CM,
                               MEDICAL_STORY1 = tb.MEDICAL_STORY1,
                               MEDICAL_STORY2 = tb.MEDICAL_STORY2,
                               FTHR_NAME = tb.FTHR_NAME,
                               FTHR_POB = tb.FTHR_POB,
                               FTHR_DOB = tb.FTHR_DOB,
                               FTHR_RELIGION_ID = tb.FTHR_RELIGION_ID,
                               FTHR_NATIONALITY_ID = tb.FTHR_NATIONALITY_ID,
                               FTHR_EDU_ID = tb.FTHR_EDU_ID,
                               FTHR_JOB_ID = tb.FTHR_JOB_ID,
                               FTHR_JOB_COMPANY = tb.FTHR_JOB_COMPANY,
                               FTHR_JOB_ADDR1 = tb.FTHR_JOB_ADDR1,
                               FTHR_JOB_ADDR2 = tb.FTHR_JOB_ADDR2,
                               FTHR_INCOME = tb.FTHR_INCOME,
                               FTHR_EMAIL = tb.FTHR_EMAIL,
                               FTHR_HOMEPHONE = tb.FTHR_HOMEPHONE,
                               FTHR_CELLPHONE = tb.FTHR_CELLPHONE,
                               FTHR_ADDR_COUNTRY_ID = tb.FTHR_ADDR_COUNTRY_ID,
                               FTHR_ADDR_CITY = tb.FTHR_ADDR_CITY,
                               FTHR_ADDR_ZIP = tb.FTHR_ADDR_ZIP,
                               FTHR_ADDR_STREET1 = tb.FTHR_ADDR_STREET1,
                               FTHR_ADDR_STREET2 = tb.FTHR_ADDR_STREET2,
                               MTHR_NAME = tb.MTHR_NAME,
                               MTHR_POB = tb.MTHR_POB,
                               MTHR_DOB = tb.MTHR_DOB,
                               MTHR_RELIGION_ID = tb.MTHR_RELIGION_ID,
                               MTHR_NATIONALITY_ID = tb.MTHR_NATIONALITY_ID,
                               MTHR_EDU_ID = tb.MTHR_EDU_ID,
                               MTHR_JOB_ID = tb.MTHR_JOB_ID,
                               MTHR_JOB_COMPANY = tb.MTHR_JOB_COMPANY,
                               MTHR_JOB_ADDR1 = tb.MTHR_JOB_ADDR1,
                               MTHR_JOB_ADDR2 = tb.MTHR_JOB_ADDR2,
                               MTHR_INCOME = tb.MTHR_INCOME,
                               MTHR_EMAIL = tb.MTHR_EMAIL,
                               MTHR_HOMEPHONE = tb.MTHR_HOMEPHONE,
                               MTHR_CELLPHONE = tb.MTHR_CELLPHONE,
                               MTHR_ADDR_COUNTRY_ID = tb.MTHR_ADDR_COUNTRY_ID,
                               MTHR_ADDR_CITY = tb.MTHR_ADDR_CITY,
                               MTHR_ADDR_ZIP = tb.MTHR_ADDR_ZIP,
                               MTHR_ADDR_STREET1 = tb.MTHR_ADDR_STREET1,
                               MTHR_ADDR_STREET2 = tb.MTHR_ADDR_STREET2,
                               STUDENT_IMG = tb.STUDENT_IMG,
                               FTHR_IMG = tb.FTHR_IMG,
                               MTHR_IMG = tb.MTHR_IMG,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               STUDENTSTS_ID = tb.STUDENTSTS_ID,
                               NEXT_SCHOOL_NAME = tb.NEXT_SCHOOL_NAME,
                               NEXT_SCHOOL_DT = tb.NEXT_SCHOOL_DT,
                               BRANCH_TYPE = tb.BRANCH_TYPE,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               YEAR_DESC = tb.YEAR_DESC,
                               YEAR_FROM = tb.YEAR_FROM,
                               YEAR_TO = tb.YEAR_TO,
                               SEMESTER_DESC = tb.SEMESTER_DESC,
                               SEMESTER_NUM = tb.SEMESTER_NUM,
                               CLASSTYPE_CODE = tb.CLASSTYPE_CODE,
                               CLASSTYPE_SHORTDESC = tb.CLASSTYPE_SHORTDESC,
                               SEX_CODE = tb.SEX_CODE,
                               SEX_DESC = tb.SEX_DESC,
                               RELIGION_CODE = tb.RELIGION_CODE,
                               RELIGION_DESC = tb.RELIGION_DESC,
                               BLOOD_TYPE_CODE = tb.BLOOD_TYPE_CODE,
                               BLOOD_TYPE_DESC = tb.BLOOD_TYPE_DESC,
                               FTHR_RELIGION_CODE = tb.FTHR_RELIGION_CODE,
                               FTHR_RELIGION_DESC = tb.FTHR_RELIGION_DESC,
                               FTHR_EDU_CODE = tb.FTHR_EDU_CODE,
                               FTHR_EDU_DESC = tb.FTHR_EDU_DESC,
                               FTHR_JOB_CODE = tb.FTHR_JOB_CODE,
                               FTHR_JOB_DESC = tb.FTHR_JOB_DESC,
                               MTHR_RELIGION_CODE = tb.MTHR_RELIGION_CODE,
                               MTHR_RELIGION_DESC = tb.MTHR_RELIGION_DESC,
                               MTHR_EDU_CODE = tb.MTHR_EDU_CODE,
                               MTHR_EDU_DESC = tb.MTHR_EDU_DESC,
                               MTHR_JOB_CODE = tb.MTHR_JOB_CODE,
                               MTHR_JOB_DESC = tb.MTHR_JOB_DESC,
                               CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_SHORTDESC = tb.CLASSROOM_SHORTDESC,
                               STUDENTSTS_CODE = tb.STUDENTSTS_CODE,
                               STUDENTSTS_DESC = tb.STUDENTSTS_DESC,
                               CLASSLEVEL_ID = tb.CLASSLEVEL_ID,
                               CLASSLEVEL_NUM = tb.CLASSLEVEL_NUM,
                               CLASSLEVEL_CODE = tb.CLASSLEVEL_CODE,
                               CLASSLEVEL_SHORTDESC = tb.CLASSLEVEL_SHORTDESC,
                               IS_PINDAHAN = tb.IS_PINDAHAN,
                               SPP_AMOUNT = tb.SPP_AMOUNT
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Student_DetailVM getData(string id = null)
        public StudentdetailVM getData_IDbyUserID(int? id = null)
        {
            StudentdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           where tb.ID == id
                           select new StudentdetailVM
                           {ID = tb.ID};
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Student_DetailVM getData(string id = null)
        public StudentdetailVM getData_shortinfo(int? id = null)
        {
            StudentdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           where tb.ID == id
                           select new StudentdetailVM
                           {
                               ID = tb.ID,
                               STUDENT_IMG = tb.STUDENT_IMG,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSTYPE_SHORTDESC = tb.CLASSTYPE_SHORTDESC,
                               //CLASSTYPE_DESC = tb.CLASSTYPE_DESC,
                               //CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_SHORTDESC = tb.CLASSROOM_SHORTDESC,
                               IS_PINDAHAN = tb.IS_PINDAHAN,
                               SPP_AMOUNT = tb.SPP_AMOUNT
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Student_DetailVM getData(string id = null)

        public Boolean isExists_NIS(string id = null)
        {
            Boolean oReturn = false;
            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.Student_infos
                           where tb.NIS == id
                           select new StudentdetailVM { NIS = tb.NIS }).SingleOrDefault();
                if (oQRY != null) if (oQRY.NIS == id) oReturn = true;
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Boolean isExists_NIS(string id = null)
        public Boolean isExists_NIS(int? id, string psNIS)
        {
            Boolean oReturn = false;
            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.Student_infos
                            where tb.ID !=id && tb.NIS == psNIS
                            select new StudentdetailVM { NIS = tb.NIS }).SingleOrDefault();
                if (oQRY != null) if (oQRY.NIS == psNIS) oReturn = true;
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Boolean isExists_NIS(string id = null)

        public StudentdetailVM getData_lookup(int? id = null)
        {
            StudentdetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           where tb.ID == id
                           select new StudentdetailVM
                           {
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               ID = tb.ID,
                               NAME = tb.NAME,
                               NIS = tb.NIS,
                               STUDENT_IMG = tb.STUDENT_IMG,
                               IS_PINDAHAN = tb.IS_PINDAHAN,
                               SPP_AMOUNT = tb.SPP_AMOUNT
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Student_DetailVM getData(string id = null)

        public List<StudentlookupVM> getDatalist_lookup()
        {
            List<StudentlookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           select new StudentlookupVM
                           {
                               ID = tb.ID,
                               NAME = tb.NAME,
                               NIS = tb.NIS,
                               BRANCH_DESC = tb.BRANCH_DESC,
                               CLASSTYPE_SHORTDESC = tb.CLASSTYPE_SHORTDESC,
                               STUDENT_IMG = tb.STUDENT_IMG,
                               IS_PINDAHAN = tb.IS_PINDAHAN,
                               SPP_AMOUNT = tb.SPP_AMOUNT
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Student_ListVM> getDatalist()
        public List<StudentdetailVM> getDatalist_lookup2(StudentVM poViewModel = null)
        {
            List<StudentdetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Student_infos
                           select new StudentdetailVM
                           {
                               BRANCH_ID = tb.BRANCH_ID,
                               YEAR_ID = tb.YEAR_ID,
                               SEMESTER_ID = tb.SEMESTER_ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSTYPE_CODE = tb.CLASSTYPE_CODE,
                               CLASSTYPE_SHORTDESC = tb.CLASSTYPE_SHORTDESC,

                               CLASSLEVEL_ID = tb.CLASSLEVEL_ID,
                               CLASSLEVEL_CODE = tb.CLASSLEVEL_CODE,
                               CLASSLEVEL_SHORTDESC = tb.CLASSLEVEL_SHORTDESC,

                               CLASSROOM_ID = tb.CLASSROOM_ID,
                               CLASSROOM_CODE = tb.CLASSROOM_CODE,
                               CLASSROOM_SHORTDESC = tb.CLASSROOM_SHORTDESC,

                               ID = tb.ID,
                               NAME = tb.NAME,
                               NIS = tb.NIS,
                               STUDENT_IMG = tb.STUDENT_IMG,
                               IS_PINDAHAN = tb.IS_PINDAHAN,
                               SPP_AMOUNT = tb.SPP_AMOUNT
                           };
                if (poViewModel != null)
                {
                    if (poViewModel.FILTER_BRANCH_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.BRANCH_ID == poViewModel.FILTER_BRANCH_ID);
                    } //End if (poViewModel.YEAR_ID != null)
                    if (poViewModel.FILTER_YEAR_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.YEAR_ID == poViewModel.FILTER_YEAR_ID);
                    } //End if (poViewModel.YEAR_ID != null)
                    if (poViewModel.FILTER_SEMESTER_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.SEMESTER_ID == poViewModel.FILTER_SEMESTER_ID);
                    } //End if (poViewModel.SEMESTER_ID != null)
                    if (poViewModel.FILTER_CLASSTYPE_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                    if (poViewModel.FILTER_CLASSTYPE_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSTYPE_ID == poViewModel.FILTER_CLASSTYPE_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                    if (poViewModel.FILTER_CLASSLEVEL_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSLEVEL_ID == poViewModel.FILTER_CLASSLEVEL_ID);
                    } //End if (poViewModel.CLASSTYPE_ID != null)
                    if (poViewModel.FILTER_CLASSROOM_ID != null)
                    {
                        oQRY = oQRY.Where(fld => fld.CLASSROOM_ID == poViewModel.FILTER_CLASSROOM_ID);
                    } //End if (poViewModel.FILTER_CLASSROOM_ID != null)
                } //End if (poViewModel != null)
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Student_ListVM> getDatalist()
    } //End public class StudentDS
} //End namespace APPBASE.Models
