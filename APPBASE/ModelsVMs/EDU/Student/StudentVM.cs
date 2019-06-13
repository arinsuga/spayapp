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
//using APPBASE.Svcapp;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public partial class StudentVM : FilterdataVM
    {
        public List<StudentdetailVM> LIST { get; set; }
        public StudentdetailVM DETAIL { get; set; }
    } //End public partial class StudentVM
    public partial class StudentdetailVM
    {
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public string NAME { get; set; }
        public string NICKNAME { get; set; }
        public string NIS { get; set; }
        public string NISN { get; set; }
        public string PINREG { get; set; }
        public string REGNO { get; set; }
        public DateTime? REG_DT { get; set; }
        public int? BRANCH_ID { get; set; }
        public int? YEAR_ID { get; set; }
        public Byte? SEMESTER_ID { get; set; }
        public int? CLASSTYPE_ID { get; set; }
        public Byte? SEX_ID { get; set; }
        public string POB { get; set; }
        public DateTime? DOB { get; set; }
        public Byte? RELIGION_ID { get; set; }
        public Byte? NATIONALITY_ID { get; set; }
        public string LANGUAGE { get; set; }
        public string ETHNIC { get; set; }
        public Byte? CHILD_SEQ { get; set; }
        public Byte? CHILD_QTY { get; set; }
        public Byte? ADDR_COUNTRY_ID { get; set; }
        public string ADDR_CITY { get; set; }
        public string ADDR_ZIP { get; set; }
        public string ADDR_STREET1 { get; set; }
        public string ADDR_STREET2 { get; set; }
        public string HOME_PHONE { get; set; }
        public string CELL_PHONE { get; set; }
        public string EMAIL { get; set; }
        public string PREV_SCHOOL_NAME { get; set; }
        public string PREV_SCHOOL_ADDR { get; set; }
        public Byte? BLOOD_TYPE_ID { get; set; }
        public Byte? WEIGHT_KG { get; set; }
        public Byte? HEIGHT_CM { get; set; }
        public string MEDICAL_STORY1 { get; set; }
        public string MEDICAL_STORY2 { get; set; }
        public string FTHR_NAME { get; set; }
        public string FTHR_POB { get; set; }
        public DateTime? FTHR_DOB { get; set; }
        public Byte? FTHR_RELIGION_ID { get; set; }
        public Byte? FTHR_NATIONALITY_ID { get; set; }
        public Byte? FTHR_EDU_ID { get; set; }
        public Byte? FTHR_JOB_ID { get; set; }
        public string FTHR_JOB_COMPANY { get; set; }
        public string FTHR_JOB_ADDR1 { get; set; }
        public string FTHR_JOB_ADDR2 { get; set; }
        public int? FTHR_INCOME { get; set; }
        public string FTHR_EMAIL { get; set; }
        public string FTHR_HOMEPHONE { get; set; }
        public string FTHR_CELLPHONE { get; set; }
        public Byte? FTHR_ADDR_COUNTRY_ID { get; set; }
        public string FTHR_ADDR_CITY { get; set; }
        public string FTHR_ADDR_ZIP { get; set; }
        public string FTHR_ADDR_STREET1 { get; set; }
        public string FTHR_ADDR_STREET2 { get; set; }
        public string MTHR_NAME { get; set; }
        public string MTHR_POB { get; set; }
        public DateTime? MTHR_DOB { get; set; }
        public Byte? MTHR_RELIGION_ID { get; set; }
        public Byte? MTHR_NATIONALITY_ID { get; set; }
        public Byte? MTHR_EDU_ID { get; set; }
        public Byte? MTHR_JOB_ID { get; set; }
        public string MTHR_JOB_COMPANY { get; set; }
        public string MTHR_JOB_ADDR1 { get; set; }
        public string MTHR_JOB_ADDR2 { get; set; }
        public int? MTHR_INCOME { get; set; }
        public string MTHR_EMAIL { get; set; }
        public string MTHR_HOMEPHONE { get; set; }
        public string MTHR_CELLPHONE { get; set; }
        public Byte? MTHR_ADDR_COUNTRY_ID { get; set; }
        public string MTHR_ADDR_CITY { get; set; }
        public string MTHR_ADDR_ZIP { get; set; }
        public string MTHR_ADDR_STREET1 { get; set; }
        public string MTHR_ADDR_STREET2 { get; set; }
        public string STUDENT_IMG { get; set; }
        public string FTHR_IMG { get; set; }
        public string MTHR_IMG { get; set; }
        public int? CLASSROOM_ID { get; set; }
        public int? CLASSLEVEL_ID { get; set; }
        public int? STUDENTSTS_ID { get; set; }
        public string NEXT_SCHOOL_NAME { get; set; }
        public DateTime? NEXT_SCHOOL_DT { get; set; }
        public Byte? BRANCH_TYPE { get; set; }
        public string BRANCH_DESC { get; set; }
        public string YEAR_DESC { get; set; }
        public DateTime? YEAR_FROM { get; set; }
        public DateTime? YEAR_TO { get; set; }
        public string SEMESTER_DESC { get; set; }
        public Byte? SEMESTER_NUM { get; set; }
        public string CLASSTYPE_CODE { get; set; }
        public string CLASSTYPE_SHORTDESC { get; set; }
        public string SEX_CODE { get; set; }
        public string SEX_DESC { get; set; }
        public string RELIGION_CODE { get; set; }
        public string RELIGION_DESC { get; set; }
        public string BLOOD_TYPE_CODE { get; set; }
        public string BLOOD_TYPE_DESC { get; set; }
        public string FTHR_RELIGION_CODE { get; set; }
        public string FTHR_RELIGION_DESC { get; set; }
        public string FTHR_EDU_CODE { get; set; }
        public string FTHR_EDU_DESC { get; set; }
        public string FTHR_JOB_CODE { get; set; }
        public string FTHR_JOB_DESC { get; set; }
        public string MTHR_RELIGION_CODE { get; set; }
        public string MTHR_RELIGION_DESC { get; set; }
        public string MTHR_EDU_CODE { get; set; }
        public string MTHR_EDU_DESC { get; set; }
        public string MTHR_JOB_CODE { get; set; }
        public string MTHR_JOB_DESC { get; set; }
        public string CLASSROOM_CODE { get; set; }
        public string CLASSROOM_SHORTDESC { get; set; }
        public string STUDENTSTS_CODE { get; set; }
        public string STUDENTSTS_DESC { get; set; }
        public string CLASSLEVEL_CODE { get; set; }
        public string CLASSLEVEL_SHORTDESC { get; set; }
        public int? CLASSLEVEL_NUM { get; set; }

        public int? IS_PINDAHAN { get; set; }
        public decimal? SPP_AMOUNT { get; set; }
    } //End public partial class StudentdetailVM

    public partial class StudentlookupVM
    {
        public int? ID { get; set; }
        public string NAME { get; set; }
        public string NIS { get; set; }
        public string BRANCH_DESC { get; set; }
        public string CLASSTYPE_SHORTDESC { get; set; }
        public string CLASSROOM_CODE { get; set; }
        public string CLASSROOM_NAME { get; set; }
        public string STUDENT_IMG { get; set; }
        public int? IS_PINDAHAN { get; set; }
        public decimal? SPP_AMOUNT { get; set; }
    } //End public partial class StudentlookupVM
} //End namespace APPBASE.Models
