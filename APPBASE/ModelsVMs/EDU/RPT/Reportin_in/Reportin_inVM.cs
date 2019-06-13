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
    public partial class ReportinVM {
        public DateTime? TRN_DT { get; set; }
        public decimal? TRN_AMOUNT { get; set; }

        //SYSINFO
        public SysinfodetailVM SYSINFO { get; set; }

        //YEAR
        public int? YEAR_ID { get; set; }
        public string YEAR_CODE { get; set; }
        public string YEAR_SHORTDESC { get; set; }
        public string YEAR_DESC { get; set; }
        public DateTime? YEAR_FROM { get; set; }
        public DateTime? YEAR_TO { get; set; }
        //YEAR CACHE
        public string CACHE_YEAR_CODE { get; set; }
        public string CACHE_YEAR_SHORTDESC { get; set; }
        public string CACHE_YEAR_DESC { get; set; }
        public DateTime? CACHE_YEAR_FROM { get; set; }
        public DateTime? CACHE_YEAR_TO { get; set; }
        //CLASSTYPE
        public int? CLASSTYPE_ID { get; set; }
        public string CLASSTYPE_CODE { get; set; }
        public string CLASSTYPE_SHORTDESC { get; set; }
        public string CLASSTYPE_DESC { get; set; }
        public int? CLASSTYPE_NUM { get; set; }
        //CLASSLEVEL
        public int? CLASSLEVEL_ID { get; set; }
        public string CLASSLEVEL_CODE { get; set; }
        public string CLASSLEVEL_SHORTDESC { get; set; }
        public string CLASSLEVEL_DESC { get; set; }
        public int? CLASSLEVEL_NUM { get; set; }
        public int? CLASSLEVEL_SEQNO { get; set; }
        //MONTHS
        public int? MONTHSPP_ID { get; set; }
        public string MONTHSPP_CODE { get; set; }
        public string MONTHSPP_SHORTDESC { get; set; }
        public string MONTHSPP_DESC { get; set; }
        //Nomor bulan sebenarnya (cth:1=Januari;2=Februari)
        public Byte? MONTHSPP_NUM { get; set; }
        //Nomor bulan sesuai Tahun Ajaran (cth:1-6=Juli-Desember;7-12=Januari-Juni)
        public Byte? MONTHSPP_SEQNO { get; set; }
        //1=sudah bayar; 0/null=belum bayar
        public Byte? ISPAYED { get; set; }
        //STUDENT
        public int? STUDENT_ID { get; set; }
        public string NAME { get; set; }
        public string NIS { get; set; }

        //LIST-TRINTYPE
        public List<TrintypedetailVM> TRINTYPES { get; set; }
        //LIST-CLASSLEVEL
        public List<ClassleveldetailVM> CLASSLEVELS { get; set; }
        //LIST-MONTHS
        public List<MonthVM> MONTHS { get; set; }
        //LIST-STUDENT
        public List<StudentdetailVM> STUDENTS { get; set; }
        //LIST-REPORTS - DATA
        public List<Reportin_indetailVM> RECAP { get; set; }
        public List<Transaction_inddetailVM> RECAP2 { get; set; }
        public List<Transaction_inddetailVM> DETAIL { get; set; }

        //METHOD-MAP
        public void MapfromRECAP()
        {
            if (this.DETAIL.Count > 0)
            {
                //YEAR
                this.CACHE_YEAR_CODE = this.RECAP[0].CACHE_YEAR_CODE;
                this.CACHE_YEAR_SHORTDESC = this.RECAP[0].CACHE_YEAR_SHORTDESC;
                this.CACHE_YEAR_DESC = this.RECAP[0].CACHE_YEAR_DESC;
                this.CACHE_YEAR_FROM = this.RECAP[0].CACHE_YEAR_FROM;
                this.CACHE_YEAR_TO = this.RECAP[0].CACHE_YEAR_TO;
                //CLASSTYPE
                //this.CLASSTYPE_ID = this.RECAP[0].CLASSTYPE_ID;
                //this.CLASSTYPE_CODE = this.RECAP[0].CLASSTYPE_CODE;
                //this.CLASSTYPE_SHORTDESC = this.RECAP[0].CLASSTYPE_SHORTDESC;
                //this.CLASSTYPE_DESC = this.RECAP[0].CLASSTYPE_DESC;
                //this.CLASSTYPE_NUM = this.RECAP[0].CLASSTYPE_NUM;
            } //End if (oViewmodel.DETAIL.Count > 0)
        } //End public void MapfromRECAP()
        public void MapfromDETAIL()
        {
            if (this.DETAIL.Count > 0)
            {
                //YEAR
                this.CACHE_YEAR_CODE = this.DETAIL[0].CACHE_YEAR_CODE;
                this.CACHE_YEAR_SHORTDESC = this.DETAIL[0].CACHE_YEAR_SHORTDESC;
                this.CACHE_YEAR_DESC = this.DETAIL[0].CACHE_YEAR_DESC;
                this.CACHE_YEAR_FROM = this.DETAIL[0].CACHE_YEAR_FROM;
                this.CACHE_YEAR_TO = this.DETAIL[0].CACHE_YEAR_TO;
                //CLASSTYPE
                this.CLASSTYPE_ID = this.DETAIL[0].CLASSTYPE_ID;
                this.CLASSTYPE_CODE = this.DETAIL[0].CLASSTYPE_CODE;
                this.CLASSTYPE_SHORTDESC = this.DETAIL[0].CLASSTYPE_SHORTDESC;
                this.CLASSTYPE_DESC = this.DETAIL[0].CLASSTYPE_DESC;
                this.CLASSTYPE_NUM = this.DETAIL[0].CLASSTYPE_NUM;
            } //End if (oViewmodel.DETAIL.Count > 0)
        } //End public void MapfromDETAIL()
    } //End public partial class ReportinVM


    public partial class Reportin_indetailVM
    {
        public int? ID { get; set; }
        public string CACHE_YEAR_CODE { get; set; }
        public string CACHE_YEAR_SHORTDESC { get; set; }
        public string CACHE_YEAR_DESC { get; set; }
        public DateTime? CACHE_YEAR_FROM { get; set; }
        public DateTime? CACHE_YEAR_TO { get; set; }
        public DateTime? TRN_DT { get; set; }
        public int? TRINTYPE_TYPEID { get; set; }
        public string TRINTYPE_CODE { get; set; }
        public string TRINTYPE_SHORTDESC { get; set; }
        public string TRINTYPE_DESC { get; set; }
        public int? TRINTYPE_SEQNO { get; set; }
        public decimal? TRN_AMOUNT_SD { get; set; }
        public decimal? TRN_AMOUNT_SMP { get; set; }
        public decimal? TRN_AMOUNT_SMA { get; set; }
        public decimal? TRN_AMOUNT_SMK { get; set; }
        public decimal? TRN_AMOUNT { get; set; }
    } //End public partial class Reportin_indetailVM

    public partial class Reportin_tunggakanVM
    {
        public int? ID { get; set; }
        public int? STUDENT_ID { get; set; }
        public string NAME { get; set; }
        public string NIS { get; set; }

        
        
        public decimal? TRN_AMOUNT_SPP { get; set; }
        public decimal? TRN_AMOUNT_EKSKUL { get; set; }

        public decimal? TRN_AMOUNT_MIDGANJIL { get; set; }
        public decimal? TRN_AMOUNT_MIDGENAP { get; set; }
        public decimal? TRN_AMOUNT_SEMGANJIL { get; set; }
        public decimal? TRN_AMOUNT_SEMGENAP { get; set; }
        public decimal? TRN_AMOUNT_DU { get; set; }
        public decimal? TRN_AMOUNT_UAT { get; set; }
        public decimal? TRN_AMOUNT_UPANGKAL { get; set; }

        public decimal? TRN_AMOUNT_PRAKERIN { get; set; }
        public decimal? TRN_AMOUNT { get; set; }
    } //End public partial class Reportin_tunggakanVM
} //End namespace APPBASE.Models
