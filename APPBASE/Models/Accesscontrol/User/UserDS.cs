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
    [Table("VWAC01USR_INFO")]
    public class User_info
    {
        public int? CREATEBY { get; set; }
        public int? UPDATEBY { get; set; }
        public DateTime? CREATEDT { get; set; }
        public DateTime? UPDATEDT { get; set; }
        [Key]
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public int? RES_ID { get; set; }
        public int? ROLE_ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string DISPLAY_NAME { get; set; }
        public string EMAIL { get; set; }
        public int? USER_STS { get; set; }
        public string USER_IMG { get; set; }
        public int? BRANCH_ID { get; set; }
        public int? MDLE_ID { get; set; }
        public string ROLE_CD { get; set; }
        public string ROLE_DISPLAY_NAME { get; set; }
        public Byte? BRANCH_TYPE { get; set; }
        public string BRANCH_DESC { get; set; }
        public string RES_NIP { get; set; }
        public string RES_NAME { get; set; }
        public int? SENTRA_ID { get; set; }
        public string SENTRA_CODE { get; set; }
        public string SENTRA_NAME { get; set; }
    } //End public class User_info
    [Table("VWAC01USR_HQ_INFO")]
    public class UserHQ_info
    {
        public int? CREATEBY { get; set; }
        public int? UPDATEBY { get; set; }
        public DateTime? CREATEDT { get; set; }
        public DateTime? UPDATEDT { get; set; }
        [Key]
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public int? RES_ID { get; set; }
        public int? ROLE_ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string DISPLAY_NAME { get; set; }
        public string EMAIL { get; set; }
        public int? USER_STS { get; set; }
        public string USER_IMG { get; set; }
        public int? BRANCH_ID { get; set; }
        public int? MDLE_ID { get; set; }
        public string ROLE_CD { get; set; }
        public string ROLE_DISPLAY_NAME { get; set; }
        public Byte? BRANCH_TYPE { get; set; }
        public string BRANCH_DESC { get; set; }
        public string RES_NAME { get; set; }
        public string RES_NIP { get; set; }
        public Byte? RES_JOBTITLE_ID { get; set; }
        public string JOBTITLE_CODE { get; set; }
        public string JOBTITLE_DESC { get; set; }
    } //End public class UserHQ_info
    [Table("VWAC01USR_BRANCH_INFO")]
    public class UserBRANCH_info
    {
        public int? CREATEBY { get; set; }
        public int? UPDATEBY { get; set; }
        public DateTime? CREATEDT { get; set; }
        public DateTime? UPDATEDT { get; set; }
        [Key]
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public int? RES_ID { get; set; }
        public int? ROLE_ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string DISPLAY_NAME { get; set; }
        public string EMAIL { get; set; }
        public int? USER_STS { get; set; }
        public string USER_IMG { get; set; }
        public int? BRANCH_ID { get; set; }
        public int? MDLE_ID { get; set; }
        public string ROLE_CD { get; set; }
        public string ROLE_DISPLAY_NAME { get; set; }
        public Byte? BRANCH_TYPE { get; set; }
        public string BRANCH_DESC { get; set; }
        public string RES_NAME { get; set; }
        public string RES_NIP { get; set; }
        public Byte? RES_JOBTITLE_ID { get; set; }
        public string JOBTITLE_CODE { get; set; }
        public string JOBTITLE_DESC { get; set; }
    } //End public class UserBRANCH_info
    [Table("VWAC01USR_PARENT_INFO")]
    public class UserPARENT_info
    {
        public int? CREATEBY { get; set; }
        public int? UPDATEBY { get; set; }
        public DateTime? CREATEDT { get; set; }
        public DateTime? UPDATEDT { get; set; }
        [Key]
        public int? ID { get; set; }
        public Byte? DTA_STS { get; set; }
        public int? RES_ID { get; set; }
        public int? ROLE_ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string DISPLAY_NAME { get; set; }
        public string EMAIL { get; set; }
        public int? USER_STS { get; set; }
        public string USER_IMG { get; set; }
        public int? BRANCH_ID { get; set; }
        public int? MDLE_ID { get; set; }
        public string ROLE_CD { get; set; }
        public string ROLE_DISPLAY_NAME { get; set; }
        public string RES_NAME { get; set; }
        public string RES_NIS { get; set; }
        public int? RES_YEAR_ID { get; set; }
        public Byte? RES_SEMESTER_ID { get; set; }
        public Byte? RES_CLASSTYPE_ID { get; set; }
        public string RES_YEAR_DESC { get; set; }
        public string RES_SEMESTER_DESC { get; set; }
        public string RES_CLASSTYPE_DESC { get; set; }
    } //End public class UserBRANCH_info
} //End namespace APPBASE.Models

