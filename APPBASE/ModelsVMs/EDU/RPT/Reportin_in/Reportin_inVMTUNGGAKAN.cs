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
        //LIST-REPORTS - DATA
        public List<Reportin_tunggakanVM> TUNGGAKAN { get; set; }
        //LIST-INST
        public List<Installment_indetailVM> INSTALLMENTS_TUNGGAKAN { get; set; }

        //METHOD-REPORT
        public void prepareReport_TUNGGAKAN() {
            this.TUNGGAKAN = new List<Reportin_tunggakanVM>();

            this.setSYSINFO_TUNGGAKAN();
            this.setMONTHS_TUNGGAKAN();
            this.SYSINFO.SYSMONTH_SEQNO = this.MONTHS.Where(fld => fld.MONTH_NUM == this.SYSINFO.SYSMONTH).FirstOrDefault().MONTH_SEQNO;
            

            this.setSTUDENTS_TUNGGAKAN();
            this.setCLASSLEVELS_TUNGGAKAN();
            this.setTRINTYPES_TUNGGAKAN();
            this.setINSTALLMENTS_TUNGGAKAN();
        } //End public void prepareReport_TUNGGAKAN()
        public void executeReport_TUNGGAKAN() {
            //PREPARE REPORT
            this.prepareReport_TUNGGAKAN();
            //INIT CLASSLEVEL FOR CALCULATION DATA
            ClassleveldetailVM itemCLASSLEVEL = null;

            //START LOOP REPORTS
            Boolean isNEW = true;
            foreach (var itemSTUDENT in this.STUDENTS)
            {
                if (itemSTUDENT.ID == 1696)
                    isNEW = true;

                //RESET FOR STUDENT LOOP
                isNEW = true;
                //INIT itemTUNGGAKAN
                Reportin_tunggakanVM itemTUNGGAKAN = null;
                //GET CLASSLEVEL BY STUDENT (TODO: REFACTOR BY MODIFY DBVIEW 
                itemCLASSLEVEL = CLASSLEVELS.Where(fld => fld.ID == itemSTUDENT.CLASSLEVEL_ID).SingleOrDefault();
                foreach (var itemTRINTYPE in this.TRINTYPES) {
                    if (isNEW) {
                        isNEW = false;
                        itemTUNGGAKAN = new Reportin_tunggakanVM();
                        itemTUNGGAKAN = initMAP(itemSTUDENT);
                    } //End if (isNEW)

                    itemTUNGGAKAN = this.calcTUNGGAKAN(itemTUNGGAKAN, itemSTUDENT, itemCLASSLEVEL, itemTRINTYPE);
                } //End foreach (var item2 in this.TRINTYPES)
                itemTUNGGAKAN = this.sumTUNGGAKAN(itemTUNGGAKAN);

                if (itemTUNGGAKAN.TRN_AMOUNT > 0) TUNGGAKAN.Add(itemTUNGGAKAN);
            } //End foreach (var item in this.STUDENTS)
        } //End public void executeReport_TUNGGAKAN()

        //METHOD-CALC
        private Reportin_tunggakanVM calcTUNGGAKAN
        (Reportin_tunggakanVM poTUNGGAKAN, StudentdetailVM poSTUDENT, ClassleveldetailVM poCLASSLEVEL, TrintypedetailVM poTRINTYPES)
        {
            Boolean isCheck = true;
            Reportin_tunggakanVM vReturn = new Reportin_tunggakanVM();
            vReturn = poTUNGGAKAN;
            Installment_indetailVM oINST = this.INSTALLMENTS_TUNGGAKAN.
                Where(fld => fld.INST_TYPEID == poTRINTYPES.ID &&
                    fld.STUDENT_ID == poSTUDENT.ID).SingleOrDefault();

            //SPP
            if ((poTRINTYPES.ID == valFLAG.FLAG_TRINTYPE_SPP) && (isCheck))
            {
                isCheck = false;
                //Map Tunggakan
                vReturn = mapMONTHLY_SPP(poTUNGGAKAN, poCLASSLEVEL, oINST);
            } //End if (poTRINTYPES.ID == valFLAG.FLAG_TRINTYPE_SPP)
            //EKSKUL
            if ((poTRINTYPES.ID == valFLAG.FLAG_TRINTYPE_EKSKUL) && (isCheck))
            {
                isCheck = false;
                //Map Tunggakan
                vReturn = mapMONTHLY_EKSKUL(poTUNGGAKAN, oINST);
            } //End if (poTRINTYPES.ID == valFLAG.FLAG_TRINTYPE_EKSKUL)
            //SCLUB
            if ((poTRINTYPES.ID == valFLAG.FLAG_TRINTYPE_SCLUB) && (isCheck))
            {
                isCheck = false;
                //Map Tunggakan
                vReturn = mapMONTHLY_SCLUB(poTUNGGAKAN, oINST);
            } //End if (poTRINTYPES.ID == valFLAG.FLAG_TRINTYPE_SCLUB)
            //OTHER
            if (isCheck) {
                isCheck = false;
                //Map Tunggakan
                vReturn = mapMONTHLY_OTHER(poTUNGGAKAN, oINST);
            } //End if (isCheck)


            return vReturn;
        } //End private Reportin_tunggakanVM calcTUNGGAKAN(StudentdetailVM poSTUDENT, TrintypedetailVM poTRINTYPES)
        private Reportin_tunggakanVM sumTUNGGAKAN(Reportin_tunggakanVM poTUNGGAKAN)
        {
            Reportin_tunggakanVM vReturn = poTUNGGAKAN;


            vReturn.TRN_AMOUNT =
                vReturn.TRN_AMOUNT_SPP +
                vReturn.TRN_AMOUNT_EKSKUL +
                vReturn.TRN_AMOUNT_MIDGANJIL +
                vReturn.TRN_AMOUNT_MIDGENAP +
                vReturn.TRN_AMOUNT_SEMGANJIL +
                vReturn.TRN_AMOUNT_SEMGENAP +
                vReturn.TRN_AMOUNT_DU +
                vReturn.TRN_AMOUNT_UAT +
                vReturn.TRN_AMOUNT_UPANGKAL +
                vReturn.TRN_AMOUNT_PRAKERIN;

            return vReturn;
        } //End private Reportin_tunggakanVM sumTUNGGAKAN(Reportin_tunggakanVM poTUNGGAKAN)

        //METHOD-MAP-INIT
        private Reportin_tunggakanVM initMAP(StudentdetailVM poSTUDENT)
        {
            Reportin_tunggakanVM vReturn = new Reportin_tunggakanVM();

            vReturn.ID = poSTUDENT.ID;
            vReturn.STUDENT_ID = poSTUDENT.ID;
            vReturn.NAME = poSTUDENT.NAME;
            vReturn.NIS = poSTUDENT.NIS;

            vReturn.TRN_AMOUNT_SPP = 0;
            vReturn.TRN_AMOUNT_EKSKUL = 0;
            vReturn.TRN_AMOUNT_MIDGANJIL = 0;
            vReturn.TRN_AMOUNT_MIDGENAP = 0;
            vReturn.TRN_AMOUNT_SEMGANJIL = 0;
            vReturn.TRN_AMOUNT_SEMGENAP = 0;
            vReturn.TRN_AMOUNT_DU = 0;
            vReturn.TRN_AMOUNT_UAT = 0;
            vReturn.TRN_AMOUNT_UPANGKAL = 0;
            vReturn.TRN_AMOUNT_PRAKERIN = 0;
            vReturn.TRN_AMOUNT = 0;

            return vReturn;
        } //End private Reportin_tunggakanVM mapMONTHLY(StudentdetailVM poSTUDENT, TrintypedetailVM poTRINTYPES, Installment_indetailVM poINST)
        //METHOD-MAP-MONTHLY
        private decimal? mapMONTHLY_CALC(Installment_indetailVM poINST, decimal? pnTRN_QTY, decimal? pnTRN_PRICE)
        {
            decimal? vReturn = 0;

            //Init Calc Variable
            decimal? nTRN_QTY = pnTRN_QTY;
            decimal? nTRN_PRICE = pnTRN_PRICE;
            Byte? nCURRENT_MONTH = this.SYSINFO.SYSMONTH_SEQNO;
            //poINST
            if (poINST != null)
            {
                //TRN_QTY
                if (poINST.INST_QTY != null)
                {
                    decimal? nMONTH_TUNGGAKAN = (decimal?)(nCURRENT_MONTH - 1) - poINST.INST_QTY;
                    if (nMONTH_TUNGGAKAN > 0) nTRN_QTY = nMONTH_TUNGGAKAN;
                } //End if (oINST.INST_QTY != null)
                //TRN_PRICE
                if (poINST.INST_PRICEBASE != null) nTRN_PRICE = poINST.INST_PRICEBASE;
            } //End if (oINST != null)
            //CALC QTY X PRICE
            vReturn = nTRN_QTY * nTRN_PRICE;

            return vReturn;
        } //End private decimal? mapMONTHLY_CALC(Installment_indetailVM poINST, decimal? pnTRN_QTY, decimal? pnTRN_PRICE)
        private Reportin_tunggakanVM mapMONTHLY_SPP(Reportin_tunggakanVM poTUNGGAKAN, ClassleveldetailVM poCLASSLEVEL, Installment_indetailVM poINST)
        {
            Reportin_tunggakanVM vReturn = new Reportin_tunggakanVM();
            vReturn = poTUNGGAKAN;

            //Init Calc Variable
            decimal? nTRN_QTY = 12;
            decimal? nTRN_PRICE = poCLASSLEVEL.CLASSLEVEL_SPP;
            decimal? nTRN_AMOUNT = mapMONTHLY_CALC(poINST, nTRN_QTY, nTRN_PRICE);

            vReturn.TRN_AMOUNT_SPP = nTRN_AMOUNT;
            return vReturn;
        } //End private Reportin_tunggakanVM mapMONTHLY_SPP(StudentdetailVM poSTUDENT, TrintypedetailVM poTRINTYPES, Installment_indetailVM poINST)
        private Reportin_tunggakanVM mapMONTHLY(Reportin_tunggakanVM poTUNGGAKAN, Installment_indetailVM poINST)
        {
            Reportin_tunggakanVM vReturn = new Reportin_tunggakanVM();
            vReturn = poTUNGGAKAN;

            //Init Calc Variable
            decimal? nTRN_QTY = 0;
            decimal? nTRN_PRICE = 0;
            decimal? nTRN_AMOUNT = mapMONTHLY_CALC(poINST, nTRN_QTY, nTRN_PRICE);

            vReturn.TRN_AMOUNT_SPP = nTRN_AMOUNT;
            return vReturn;
        } //End private Reportin_tunggakanVM mapMONTHLY(Reportin_tunggakanVM poTUNGGAKAN, Installment_indetailVM poINST)
        private Reportin_tunggakanVM mapMONTHLY_EKSKUL(Reportin_tunggakanVM poTUNGGAKAN, Installment_indetailVM poINST)
        {
            Reportin_tunggakanVM vReturn = new Reportin_tunggakanVM();
            vReturn = mapMONTHLY(poTUNGGAKAN, poINST);
            return vReturn;
        } //End private Reportin_tunggakanVM mapMONTHLY_EKSKUL(Reportin_tunggakanVM poTUNGGAKAN, StudentdetailVM poSTUDENT, ClassleveldetailVM poCLASSLEVEL, TrintypedetailVM poTRINTYPES)
        private Reportin_tunggakanVM mapMONTHLY_SCLUB(Reportin_tunggakanVM poTUNGGAKAN, Installment_indetailVM poINST)
        {
            Reportin_tunggakanVM vReturn = new Reportin_tunggakanVM();
            vReturn = mapMONTHLY(poTUNGGAKAN, poINST);
            return vReturn;
        } //End private Reportin_tunggakanVM mapMONTHLY_SCLUB(Reportin_tunggakanVM poTUNGGAKAN, StudentdetailVM poSTUDENT, ClassleveldetailVM poCLASSLEVEL, TrintypedetailVM poTRINTYPES)
        private Reportin_tunggakanVM mapMONTHLY_OTHER(Reportin_tunggakanVM poTUNGGAKAN, Installment_indetailVM poINST)
        {
            Reportin_tunggakanVM vReturn = new Reportin_tunggakanVM();
            vReturn = mapMONTHLY(poTUNGGAKAN, poINST);
            return vReturn;
        } //End private Reportin_tunggakanVM mapMONTHLY_OTHER(Reportin_tunggakanVM poTUNGGAKAN, Installment_indetailVM poINST)
        //METHOD-MAP-OTHER
        private Reportin_tunggakanVM mapOTHER(StudentdetailVM poSTUDENT, TrintypedetailVM poTRINTYPES, Installment_indetailVM poINST)
        {
            Reportin_tunggakanVM vReturn = null;

            return vReturn;
        } //End private Reportin_tunggakanVM mapOTHER(StudentdetailVM poSTUDENT, TrintypedetailVM poTRINTYPES, Installment_indetailVM poINST)

        //METHOD-SET
        public void setSTUDENTS_TUNGGAKAN()
        {
            StudentDS oDS = new StudentDS();
            StudentVM oFilter = new StudentVM();

            //Init Filter
            if (this.CLASSTYPE_ID != null)
                oFilter.FILTER_CLASSTYPE_ID = (Byte?)this.CLASSTYPE_ID;
            if (this.CLASSLEVEL_ID != null)
                oFilter.FILTER_CLASSLEVEL_ID = (Byte?)this.CLASSLEVEL_ID;
            if (this.NIS != null)
                oFilter.FILTER_NIS = this.NIS;

            //Set Students
            this.STUDENTS = oDS.getDatalist(oFilter);
            if ((this.NIS != null) && (this.STUDENTS != null) && (this.STUDENTS.Count > 0)) this.STUDENT_ID = this.STUDENTS.FirstOrDefault().ID;

        } //End public void setSTUDENTS_TUNGGAKAN()
        public void setCLASSLEVELS_TUNGGAKAN()
        {
            ClasslevelDS oDS = new ClasslevelDS();
            //Set Students
            this.CLASSLEVELS = oDS.getDatalist();
        } //End public void setCLASSLEVELS_TUNGGAKAN()
        public void setTRINTYPES_TUNGGAKAN()
        {
            TrintypeDS oDS = new TrintypeDS();
            List<int?> aTunggakan = new List<int?>() {
                        1,  //SPP
                        3,  //MID GANJIL
                        4,  //MID GENAP
                        5,  //SMT GANJIL
                        6,  //SMT GENAP
                        7,  //DU
                        8,  //UAT
                        9,  //EKSKUL
                        11, //PRAKERIN
                        13  //U.PANGKAL
                    };

            var oData = oDS.getDatalist(aTunggakan);

            //Set TRINTYPE
            this.TRINTYPES = oData;
        } //End public void setTRINTYPES_TUNGGAKAN()
        public void setINSTALLMENTS_TUNGGAKAN()
        {
            Installment_inDS oDS = new Installment_inDS();
            Installment_indetailVM oFilter = new Installment_indetailVM();

            //Init Filter
            oFilter.CACHE_YEAR_FROM = this.YEAR_FROM;
            oFilter.CACHE_YEAR_TO = this.YEAR_TO;
            if (this.CLASSTYPE_ID != null)
                oFilter.CLASSTYPE_ID = (Byte?)this.CLASSTYPE_ID;
            if (this.CLASSLEVEL_ID != null)
                oFilter.CLASSLEVEL_ID = (Byte?)this.CLASSLEVEL_ID;
            if (this.NIS != null)
                oFilter.STUDENT_ID = this.STUDENT_ID;

            //Set Students
            this.INSTALLMENTS_TUNGGAKAN = oDS.getDatalist_report(oFilter);
        } //End public void setINSTALLMENTS_TUNGGAKAN()
        public void setMONTHS_TUNGGAKAN()
        {
            MonthDS oDS = new MonthDS();

            //Set Months
            this.MONTHS = oDS.getDatalist();
        } //End public void setMONTHS_TUNGGAKAN()
        public void setSYSINFO_TUNGGAKAN()
        {
            SysinfoDS oDS = new SysinfoDS();

            //Set Sysinfo
            this.SYSINFO = oDS.getSYSDATEVM();

        } //End public void setMONTHS_TUNGGAKAN()


        private Reportin_tunggakanVM mapMONTHLY_SPP_BACKUP(Reportin_tunggakanVM poTUNGGAKAN, ClassleveldetailVM poCLASSLEVEL, Installment_indetailVM poINST)
        {
            Reportin_tunggakanVM vReturn = new Reportin_tunggakanVM();
            vReturn = poTUNGGAKAN;

            //Init Calc Variable
            decimal? nTRN_QTY = 12;
            decimal? nTRN_PRICE = poCLASSLEVEL.CLASSLEVEL_SPP;
            decimal? nTRN_AMOUNT = 0;
            Byte? nCURRENT_MONTH = this.SYSINFO.SYSMONTH_SEQNO;

            if (poINST != null)
            {
                //QTY
                if (poINST.INST_QTY != null)
                {
                    decimal? nMONTH_TUNGGAKAN = (decimal?)(nCURRENT_MONTH - 1) - poINST.INST_QTY;
                    if (nMONTH_TUNGGAKAN > 0) nTRN_QTY = nMONTH_TUNGGAKAN;
                } //End if (oINST.INST_QTY != null)
                //PRICE
                if (poINST.INST_PRICEBASE != null) nTRN_PRICE = poINST.INST_PRICEBASE;
            } //End if (oINST != null)
            //CALC QTY X PRICE
            nTRN_AMOUNT = nTRN_QTY * nTRN_PRICE;

            vReturn.TRN_AMOUNT_SPP = nTRN_AMOUNT;
            return vReturn;
        } //End private Reportin_tunggakanVM mapMONTHLY_SPP(StudentdetailVM poSTUDENT, TrintypedetailVM poTRINTYPES, Installment_indetailVM poINST)
    } //End public partial class ReportinVM
} //End namespace APPBASE.Models
