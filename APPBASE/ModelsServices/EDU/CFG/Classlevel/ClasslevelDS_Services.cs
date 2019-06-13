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
    public class ClasslevelDS
    {
        public decimal? TRND_PRICEBASE { get; set; }
        public decimal? TRND_QTYBASE { get; set; }
        public decimal? TRND_AMOUNTBASE { get; set; }

        public decimal? TRND_PRICEBASE_DENDA { get; set; }
        public decimal? TRND_QTYBASE_DENDA { get; set; }
        public decimal? TRND_AMOUNTBASE_DENDA { get; set; }

        //Constructor
        public ClasslevelDS() { } //End public ClasslevelDS
        public List<ClassleveldetailVM> getDatalist()
        {
            List<ClassleveldetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Classlevel_infos
                           select new ClassleveldetailVM
                           {
                               ID = tb.ID,
                               CLASSLEVEL_CODE = tb.CLASSLEVEL_CODE,
                               CLASSLEVEL_SHORTDESC = tb.CLASSLEVEL_SHORTDESC,
                               CLASSTYPE_NUM = tb.CLASSTYPE_NUM,

                               CLASSLEVEL_SPP = tb.CLASSLEVEL_SPP,
                               CLASSLEVEL_SPPDENDA = tb.CLASSLEVEL_SPPDENDA,
                               CLASSLEVEL_SPPPINDAH = tb.CLASSLEVEL_SPPPINDAH,
                               CLASSLEVEL_SPPPINDAHDENDA = tb.CLASSLEVEL_SPPPINDAHDENDA,
                               CLASSLEVEL_SEMESTER = tb.CLASSLEVEL_SEMESTER,
                               CLASSLEVEL_SEMESTER2 = tb.CLASSLEVEL_SEMESTER2,
                               CLASSLEVEL_MIDSEMESTER = tb.CLASSLEVEL_MIDSEMESTER,
                               CLASSLEVEL_MIDSEMESTER2 = tb.CLASSLEVEL_MIDSEMESTER2,
                               CLASSLEVEL_DFTULANG = tb.CLASSLEVEL_DFTULANG,
                               CLASSLEVEL_AKHIRTAHUN = tb.CLASSLEVEL_AKHIRTAHUN,
                               CLASSLEVEL_FORMULIR = tb.CLASSLEVEL_FORMULIR,
                               CLASSLEVEL_PANGKAL = tb.CLASSLEVEL_PANGKAL,
                               CLASSLEVEL_PRAKERIN = tb.CLASSLEVEL_PRAKERIN,
                               CLASSLEVEL_EKSKUL = tb.CLASSLEVEL_EKSKUL,
                               CLASSLEVEL_STUDI = tb.CLASSLEVEL_STUDI,
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<ClasslevellistVM> getDatalist()
        public ClassleveldetailVM getData(int? id = null)
        {
            ClassleveldetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Classlevel_infos
                           where tb.ID == id
                           select new ClassleveldetailVM
                           {
                               ID = tb.ID,
                               DTA_STS = tb.DTA_STS,
                               CLASSLEVEL_CODE = tb.CLASSLEVEL_CODE,
                               CLASSLEVEL_SHORTDESC = tb.CLASSLEVEL_SHORTDESC,
                               CLASSLEVEL_DESC = tb.CLASSLEVEL_DESC,
                               CLASSLEVEL_NUM = tb.CLASSLEVEL_NUM,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID,
                               CLASSTYPE_CODE = tb.CLASSTYPE_CODE,
                               CLASSTYPE_SHORTDESC = tb.CLASSTYPE_SHORTDESC,
                               CLASSTYPE_NUM = tb.CLASSTYPE_NUM,
                               
                               CLASSLEVEL_SPP = tb.CLASSLEVEL_SPP,
                               CLASSLEVEL_SPPDENDA = tb.CLASSLEVEL_SPPDENDA,
                               CLASSLEVEL_SPPPINDAH = tb.CLASSLEVEL_SPPPINDAH,
                               CLASSLEVEL_SPPPINDAHDENDA = tb.CLASSLEVEL_SPPPINDAHDENDA,
                               CLASSLEVEL_SEMESTER = tb.CLASSLEVEL_SEMESTER,
                               CLASSLEVEL_SEMESTER2 = tb.CLASSLEVEL_SEMESTER2,
                               CLASSLEVEL_MIDSEMESTER = tb.CLASSLEVEL_MIDSEMESTER,
                               CLASSLEVEL_MIDSEMESTER2 = tb.CLASSLEVEL_MIDSEMESTER2,
                               CLASSLEVEL_DFTULANG = tb.CLASSLEVEL_DFTULANG,
                               CLASSLEVEL_AKHIRTAHUN = tb.CLASSLEVEL_AKHIRTAHUN,
                               CLASSLEVEL_FORMULIR = tb.CLASSLEVEL_FORMULIR,
                               CLASSLEVEL_PANGKAL = tb.CLASSLEVEL_PANGKAL,
                               CLASSLEVEL_PRAKERIN = tb.CLASSLEVEL_PRAKERIN,
                               CLASSLEVEL_EKSKUL = tb.CLASSLEVEL_EKSKUL,
                               CLASSLEVEL_STUDI = tb.CLASSLEVEL_STUDI,
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public ClassleveldetailVM getData(int? id = null)
        public void getData(int? idClasslevel, int? idTrntype, int? IS_PINDAHAN)
        {
            ClassleveldetailVM oData = getData(idClasslevel);
            Boolean isSiswaPindah = false;
            if (IS_PINDAHAN == 1) isSiswaPindah = true;

            //SPP
            if (idTrntype == 1) {
                if (!isSiswaPindah)
                {
                    //BASE
                    this.TRND_PRICEBASE = oData.CLASSLEVEL_SPP;
                    this.TRND_QTYBASE = 1;
                    this.TRND_AMOUNTBASE = oData.CLASSLEVEL_SPP;
                    //DENDA (%)
                    this.TRND_PRICEBASE_DENDA = oData.CLASSLEVEL_SPPDENDA;
                    this.TRND_QTYBASE_DENDA = 1;
                    this.TRND_AMOUNTBASE_DENDA = (oData.CLASSLEVEL_SPPDENDA / 100) * oData.CLASSLEVEL_SPP;

                }
                else {
                    //BASE
                    this.TRND_PRICEBASE = oData.CLASSLEVEL_SPPPINDAH;
                    this.TRND_QTYBASE = 1;
                    this.TRND_AMOUNTBASE = oData.CLASSLEVEL_SPPPINDAH;
                    //DENDA (%)
                    this.TRND_PRICEBASE_DENDA = oData.CLASSLEVEL_SPPPINDAHDENDA;
                    this.TRND_QTYBASE_DENDA = 1;
                    this.TRND_AMOUNTBASE_DENDA = (oData.CLASSLEVEL_SPPPINDAHDENDA / 100) * oData.CLASSLEVEL_SPPPINDAH;
                }
            } //End if (idTrntype == 1)

            //SPP-Denda
            if (idTrntype == 2)
            {
                if (!isSiswaPindah)
                {
                    //BASE
                    this.TRND_PRICEBASE = oData.CLASSLEVEL_SPPDENDA;
                    this.TRND_QTYBASE = 1;
                    this.TRND_AMOUNTBASE = (oData.CLASSLEVEL_SPPDENDA / 100) * oData.CLASSLEVEL_SPP;
                    //DENDA (%)
                    this.TRND_PRICEBASE_DENDA = this.TRND_PRICEBASE;
                    this.TRND_QTYBASE_DENDA = 1;
                    this.TRND_AMOUNTBASE_DENDA = this.TRND_AMOUNTBASE;

                }
                else
                {
                    //BASE
                    this.TRND_PRICEBASE = (oData.CLASSLEVEL_SPPPINDAHDENDA / 100) * oData.CLASSLEVEL_SPPPINDAH;
                    this.TRND_QTYBASE = 1;
                    this.TRND_AMOUNTBASE = (oData.CLASSLEVEL_SPPPINDAHDENDA / 100) * oData.CLASSLEVEL_SPPPINDAH;
                    //DENDA (%)
                    this.TRND_PRICEBASE_DENDA = this.TRND_PRICEBASE;
                    this.TRND_QTYBASE_DENDA = 1;
                    this.TRND_AMOUNTBASE_DENDA = this.TRND_AMOUNTBASE;
                }
            } //End if (idTrntype == 2)
            
            
            //Mid Ganjil
            if (idTrntype == 3)
            {
                this.TRND_PRICEBASE = oData.CLASSLEVEL_MIDSEMESTER;
                this.TRND_QTYBASE = 1;
                this.TRND_AMOUNTBASE = oData.CLASSLEVEL_MIDSEMESTER;
            } //End if (idTrntype == 3)
            //Mid Genap
            if (idTrntype == 4)
            {
                this.TRND_PRICEBASE = oData.CLASSLEVEL_MIDSEMESTER2;
                this.TRND_QTYBASE = 1;
                this.TRND_AMOUNTBASE = oData.CLASSLEVEL_MIDSEMESTER2;
            } //End if (idTrntype == 4)
            //Semester Ganjil
            if (idTrntype == 5)
            {
                this.TRND_PRICEBASE = oData.CLASSLEVEL_SEMESTER;
                this.TRND_QTYBASE = 1;
                this.TRND_AMOUNTBASE = oData.CLASSLEVEL_SEMESTER;
            } //End if (idTrntype == 5)
            //Semester genap
            if (idTrntype == 6)
            {
                this.TRND_PRICEBASE = oData.CLASSLEVEL_SEMESTER2;
                this.TRND_QTYBASE = 1;
                this.TRND_AMOUNTBASE = oData.CLASSLEVEL_SEMESTER2;
            } //End if (idTrntype == 6)
            //Daftar Ulang
            if (idTrntype == 7)
            {
                this.TRND_PRICEBASE = oData.CLASSLEVEL_DFTULANG;
                this.TRND_QTYBASE = 1;
                this.TRND_AMOUNTBASE = oData.CLASSLEVEL_DFTULANG;
            } //End if (idTrntype == 7)
            //Uang Akhir Tahun
            if (idTrntype == 8)
            {
                this.TRND_PRICEBASE = oData.CLASSLEVEL_AKHIRTAHUN;
                this.TRND_QTYBASE = 1;
                this.TRND_AMOUNTBASE = oData.CLASSLEVEL_AKHIRTAHUN;
            } //End if (idTrntype == 8)
            //Ekstrakulikuler
            if (idTrntype == 9)
            {
                this.TRND_PRICEBASE = oData.CLASSLEVEL_EKSKUL;
                this.TRND_QTYBASE = 1;
                this.TRND_AMOUNTBASE = oData.CLASSLEVEL_EKSKUL;
            } //End if (idTrntype == 9)
            //Studi Klub
            if (idTrntype == 10)
            {
                this.TRND_PRICEBASE = oData.CLASSLEVEL_STUDI;
                this.TRND_QTYBASE = 1;
                this.TRND_AMOUNTBASE = oData.CLASSLEVEL_STUDI;
            } //End if (idTrntype == 10)
            //Prakerin
            if (idTrntype == 11)
            {
                this.TRND_PRICEBASE = oData.CLASSLEVEL_PRAKERIN;
                this.TRND_QTYBASE = 1;
                this.TRND_AMOUNTBASE = oData.CLASSLEVEL_PRAKERIN;
            } //End if (idTrntype == 11)
            //Formulir
            if (idTrntype == 12)
            {
                this.TRND_PRICEBASE = oData.CLASSLEVEL_FORMULIR;
                this.TRND_QTYBASE = 1;
                this.TRND_AMOUNTBASE = oData.CLASSLEVEL_FORMULIR;
            } //End if (idTrntype == 12)
            //Uang Pangkal
            if (idTrntype == 13)
            {
                this.TRND_PRICEBASE = oData.CLASSLEVEL_PANGKAL;
                this.TRND_QTYBASE = 1;
                this.TRND_AMOUNTBASE = oData.CLASSLEVEL_PANGKAL;
            } //End if (idTrntype == 13)
        } //End public ClassleveldetailVM getData(int? id = null)


        public int? getData_ClasstypeID(int? id)
        {
            int? vReturn = null;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Classlevels
                           where tb.ID == id
                           select new ClassleveldetailVM
                           {
                               ID = tb.ID,
                               CLASSTYPE_ID = tb.CLASSTYPE_ID
                           };
                var oData = oQRY.SingleOrDefault();
                vReturn = oData.CLASSTYPE_ID;
            } //End using (var = new DbContext())
            return vReturn;
        } //End public Byte? getData_ClasstypeID(int? id)

        public List<ClassleveldetailVM> getDatalist_lookup()
        {
            List<ClassleveldetailVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Classlevel_infos
                           select new ClassleveldetailVM
                           {
                               ID = tb.ID,
                               CLASSLEVEL_CODE = tb.CLASSLEVEL_CODE,
                               CLASSLEVEL_SHORTDESC = tb.CLASSLEVEL_SHORTDESC,
                               CLASSTYPE_NUM = tb.CLASSTYPE_NUM
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<ClasslevellookupVM> getDatalist_lookup()
    } //End public class ClasslevelDS
} //End namespace APPBASE.Models
