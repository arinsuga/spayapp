using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APPBASE.Models;
using APPBASE.Helpers;
using APPBASE.Filters;
using APPBASE.Svcbiz;
using Omu.ValueInjecter;

namespace APPBASE.Controllers
{
    public partial class Transaction_inController : Controller
    {
        //=issue#1, issue#2
        private Transaction_indetailVM CREATEInitspp_ViewModel(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = poViewModel;
            //Get INST MONTHLY
            oViewModel.MONTHLY_INST = this.getINST_SPP(oViewModel);
            oViewModel.MONTHLY_INST_SPP = oViewModel.MONTHLY_INST;

            if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE) {
                //EXTRA CUSTOM-TRANSACTIONDETAIL BASE
                oViewModel.TRND_PRICEBASE = oViewModel.MONTHLY_INST.INST_PRICEBASE;
                oViewModel.TRND_AMOUNTBASE = oViewModel.MONTHLY_INST.INST_PRICEBASE;
            } //End if
            //Detail MONTHS
            oViewModel.MONTHLY_MONTHS = oDSMonthspp.getDatalist_lookup();

            return oViewModel;
        } //End private Transaction_indetailVM CREATEInitspp_ViewModel(Transaction_indetailVM poViewModel)
        private Transaction_indetailVM CREATEMapspp_ViewModel(Transaction_indetailVM poViewModel, Transaction_indetailVM poViewModel_posted)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = poViewModel;
            Transaction_indetailVM oViewModel_posted = poViewModel_posted;

            oViewModel.MONTHSPP2 = oViewModel_posted.MONTHSPP2;
            oViewModel.MONTHSPP3 = oViewModel_posted.MONTHSPP3;
            oViewModel.IGNOREDENDA = oViewModel_posted.IGNOREDENDA;
            //Patch denda
            oViewModel.IGNOREDENDA = 1;

            //RESET DETAIL TRANSACTION BY TRINTYPE: SPP/DENDA SPP/MID GANJIL, DLL
            if (oViewModel.DETAIL != null) {
                //DELETE SPP
                oViewModel.DETAIL = this.removeItem(oViewModel, valFLAG.FLAG_TRINTYPE_SPP);
                if (oViewModel.IGNOREDENDA != 1) {
                    //DELETE DENDA SPP
                    oViewModel.DETAIL = this.removeItem(oViewModel, valFLAG.FLAG_TRINTYPE_SPPDENDA);
                } //End if
            } //End if

            //Add Transaction Detail
            oViewModel.MONTHSPP_COUNT = 0;
            foreach (var item in oViewModel.MONTHLY_MONTHS)
            {
                //addDetailSPP_first
                if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE) {
                    oViewModel.MONTHSPP_COUNT = oViewModel.MONTHSPP3;
                    //Add Transaction Detail SPP+Denda if exist
                    oViewModel = this.addDetailSPP_first(oViewModel, item);
                } //End if

                //addDetailSPP_next
                if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
                {
                    //Add Transaction Detail SPP+Denda if exist
                    oViewModel = this.addDetailSPP_next(oViewModel, item);
                } //End if
            } //End foreach

            return oViewModel;
        } //End method
        private Transaction_indetailVM CREATEMapspp_ViewModelINST(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = poViewModel;

            oViewModel.MONTHLY_INST.BRANCH_ID = oViewModel.BRANCH_ID;
            oViewModel.MONTHLY_INST.YEAR_ID = oViewModel.YEAR_ID;
            oViewModel.SEMESTER_ID = oViewModel.SEMESTER_ID;
            oViewModel.MONTHLY_INST.CLASSTYPE_ID = oViewModel.CLASSTYPE_ID;
            oViewModel.MONTHLY_INST.CLASSLEVEL_ID = oViewModel.CLASSLEVEL_ID;
            oViewModel.MONTHLY_INST.CLASSROOM_ID = oViewModel.CLASSROOM_ID;
            oViewModel.MONTHLY_INST.CLASSMAJOR_ID = oViewModel.CLASSMAJOR_ID;
            oViewModel.MONTHLY_INST.INST_DT = oViewModel.TRN_DT;

            //if (oViewModel.MONTHLY_INST.INST_QTY < 12) oViewModel.MONTHLY_INST.INST_STS = 1;
            //else oViewModel.MONTHLY_INST.INST_STS = 2;

            if (oViewModel.MONTHSPP2 < 12) oViewModel.MONTHLY_INST.INST_STS = 1;
            else oViewModel.MONTHLY_INST.INST_STS = 2;

            oViewModel.MONTHLY_INST.INST_STARTDT = hlpConvertionAndFormating.ConvertStringToDate("01/01/" + oViewModel.YEAR_FROM.Value.Year.ToString().Trim(), "dd/MM/yyyy");
            oViewModel.MONTHLY_INST.INST_ENDDT = hlpConvertionAndFormating.ConvertStringToDate("31/12/" + oViewModel.YEAR_TO.Value.Year.ToString().Trim(), "dd/MM/yyyy");
            oViewModel.MONTHLY_INST.INST_TYPEID = (Byte?)oViewModel.TRINTYPE_ID;
            //oViewModel.MONTHLY_INST.INST_SUBTYPEID = null;



            //addDetailSPP_first
            Byte? nMONTH1 = oViewModel.MONTHSPP2;
            Byte? nMONTH2 = oViewModel.MONTHSPP3;
            Byte? nMONTH2b = (Byte?)((nMONTH1 + nMONTH2) - 1);
            nMONTH2 = nMONTH2b;
            if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
            {
                oViewModel.MONTHLY_INST.INST_QTY = nMONTH2;
                //BASE VALUE
                oViewModel.MONTHLY_INST.INST_PRICEBASE = oViewModel.TRND_AMOUNTBASE;
                oViewModel.MONTHLY_INST.INST_AMOUNTBASE = 12 * oViewModel.TRND_AMOUNTBASE;
            }
            else {
                oViewModel.MONTHLY_INST.INST_QTY = oViewModel.MONTHSPP2;
            } ////End if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
            if (oViewModel.MONTHLY_INST.INST_AMOUNT == null) oViewModel.MONTHLY_INST.INST_AMOUNT = 0;
            oViewModel.MONTHLY_INST.INST_AMOUNT = oViewModel.MONTHLY_INST.INST_AMOUNT + (oViewModel.TRND_AMOUNT*oViewModel.MONTHSPP_COUNT);

            oViewModel.MONTHLY_INST.INST_DESC = "SPP Tahun Ajaran " + oViewModel.YEAR_SHORTDESC;
            oViewModel.MONTHLY_INST.STUDENT_ID = oViewModel.STUDENT_ID;
            //oViewModel.MONTHLY_INST.INSTD_ID = null;
            
            //CACHE - YEAR
            oViewModel.MONTHLY_INST.CACHE_YEAR_CODE = oViewModel.YEAR_CODE;
            oViewModel.MONTHLY_INST.CACHE_YEAR_SHORTDESC = oViewModel.YEAR_SHORTDESC;
            oViewModel.MONTHLY_INST.CACHE_YEAR_DESC = oViewModel.YEAR_DESC;
            oViewModel.MONTHLY_INST.CACHE_YEAR_FROM = oViewModel.YEAR_FROM;
            oViewModel.MONTHLY_INST.CACHE_YEAR_TO = oViewModel.YEAR_TO;

            //SET MAP TO SPP-MODEL
            oViewModel.MONTHLY_INST_SPP = oViewModel.MONTHLY_INST;
            return oViewModel;
        } //End private Transaction_indetailVM CREATEMapspp_ViewModel(Transaction_indetailVM poViewModel, Transaction_indetailVM poViewModel_par)


        private Transaction_indetailVM addDetail_SPP(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        {
            Transaction_indetailVM oViewModel = poViewModel;
            MonthsppVM item = poItem;
            MonthsppVM oMonthitem = oViewModel.MONTHLY_MONTHS.Where(fld => fld.ID == item.ID).FirstOrDefault();

            //Add Transaction Detail
            if (oViewModel.DETAIL == null) { oViewModel.DETAIL = new List<Transaction_inddetailVM>(); }
            Transaction_inddetailVM oViewModelDETAIL = getItem_SPP(oMonthitem, oViewModel);
            oViewModel.DETAIL.Add(oViewModelDETAIL);

            return oViewModel;
        } //End private Transaction_indetailVM addDetail_SPP(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        private Transaction_indetailVM addDetailSPP_first(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        {
            Transaction_indetailVM oViewModel = poViewModel;
            MonthsppVM item = poItem;
            Byte? nMONTH1 = oViewModel.MONTHSPP2;
            Byte? nMONTH2 = oViewModel.MONTHSPP3;
            Byte? nMONTH2b = (Byte?)((nMONTH1 + nMONTH2)-1);
            nMONTH2 = nMONTH2b;
            if (nMONTH2 > 12) nMONTH2 = 12;


            if ((item.MONTHSPP_SEQNO >= nMONTH1) &&
                  (item.MONTHSPP_SEQNO <= nMONTH2)) {
                      //Add Transaction Detail
                      oViewModel = this.addDetail_SPP(oViewModel, item);
                      //Add Transaction Detail-DENDA
                      oViewModel = this.addDetail_SPPdenda_first(oViewModel, item);
            } //End if ((item.MONTHSPP_SEQNO >= oViewModel.MONTHSPP1.MONTHSPP_SEQNO) &&


            return oViewModel;
        } //End private Transaction_indetailVM addDetailSPP_first(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        private Transaction_indetailVM addDetailSPP_next(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        {
            Transaction_indetailVM oViewModel = poViewModel;
            MonthsppVM item = poItem;
            Byte? nMONTH1 = oViewModel.MONTHSPP2;
            Byte? nMONTH2 = oViewModel.MONTHSPP3;
            Byte? nMONTH2b = (Byte?)((nMONTH1 + nMONTH2) - 1);
            nMONTH2 = nMONTH2b;
            if (nMONTH2 > 12) nMONTH2 = 12;


            if ((item.MONTHSPP_SEQNO >= nMONTH1) &&
                  (item.MONTHSPP_SEQNO <= nMONTH2))
            {
                //Add Transaction Detail
                oViewModel = this.addDetail_SPP(oViewModel, item);
                //Add Transaction Detail-DENDA
                oViewModel = this.addDetail_SPPdenda_first(oViewModel, item);
            } //End if ((item.MONTHSPP_SEQNO >= oViewModel.MONTHSPP1.MONTHSPP_SEQNO) &&


            return oViewModel;
        } //End private Transaction_indetailVM addDetailSPP_first(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        //-issue#1, issue#2
        private Transaction_indetailVM addDetailSPP_next_BACKUP(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        {
            Transaction_indetailVM oViewModel = poViewModel;
            MonthsppVM item = poItem;

            if ((item.MONTHSPP_SEQNO >= oViewModel.MONTHSPP1.MONTHSPP_SEQNO) &&
                  (item.MONTHSPP_SEQNO <= oViewModel.MONTHSPP2))
            {
                oViewModel.MONTHSPP_COUNT = (byte?)(oViewModel.MONTHSPP_COUNT + 1);
                //Add Transaction Detail
                oViewModel = this.addDetail_SPP(oViewModel, item);
                //Add Transaction Detail-DENDA
                oViewModel = this.addDetail_SPPdenda_next(oViewModel, item);
            } //End if ((item.MONTHSPP_SEQNO >= oViewModel.MONTHSPP1.MONTHSPP_SEQNO) &&

            return oViewModel;
        } //End private Transaction_indetailVM addDetailSPP_next(Transaction_indetailVM poViewModel, MonthsppVM poItem)

        private Transaction_indetailVM addDetail_SPPdenda(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        {
            Transaction_indetailVM oViewModel = poViewModel;
            MonthsppVM item = poItem;
            MonthsppVM oMonthitem = oViewModel.MONTHLY_MONTHS.Where(fld => fld.ID == item.ID).FirstOrDefault();

            //Add Transaction Detail
            if (oViewModel.DETAIL == null) { oViewModel.DETAIL = new List<Transaction_inddetailVM>(); }
            //Add Transaction Detail-DENDA
            Transaction_inddetailVM oViewModelDETAIL_DENDA = null;
            oViewModelDETAIL_DENDA = this.getItem_DendaSPP(oMonthitem, oViewModel);
            if (oViewModelDETAIL_DENDA != null) oViewModel.DETAIL.Add(oViewModelDETAIL_DENDA);


            return oViewModel;
        } //End private Transaction_indetailVM addDetail_SPPdenda(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        private Transaction_indetailVM addDetail_SPPdenda_first(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        {
            Transaction_indetailVM oViewModel = poViewModel;
            MonthsppVM item = poItem;
            Byte? nMONTH1 = oViewModel.MONTHSPP2;
            Byte? nMONTH2 = oViewModel.MONTHSPP3;
            Byte? nMONTH2b = (Byte?)((nMONTH1 + nMONTH2) - 1);
            nMONTH2 = nMONTH2b;
            if (nMONTH2 > 12) nMONTH2 = 12;

            if (oViewModel.IGNOREDENDA != 1) {
                if ((item.MONTHSPP_SEQNO >= nMONTH1) &&
                      (item.MONTHSPP_SEQNO <= nMONTH2))
                {
                    //Add Transaction Detail-DENDA
                    oViewModel = this.addDetail_SPPdenda(oViewModel, item);
                } //End if ((item.MONTHSPP_SEQNO >= oViewModel.MONTHSPP1.MONTHSPP_SEQNO) &&
            } //End if (oViewModel.IGNOREDENDA == 1)

            return oViewModel;
        } //End private Transaction_indetailVM addDetail_SPPdenda_first(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        private Transaction_indetailVM addDetail_SPPdenda_next(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        {
            Transaction_indetailVM oViewModel = poViewModel;
            MonthsppVM item = poItem;
            Byte? nMONTH1 = oViewModel.MONTHSPP2;
            Byte? nMONTH2 = oViewModel.MONTHSPP3;
            Byte? nMONTH2b = (Byte?)((nMONTH1 + nMONTH2) - 1);
            nMONTH2 = nMONTH2b;
            if (nMONTH2 > 12) nMONTH2 = 12;

            if (oViewModel.IGNOREDENDA != 1)
            {
                if ((item.MONTHSPP_SEQNO >= nMONTH1) &&
                      (item.MONTHSPP_SEQNO <= nMONTH2)) {
                    //Add Transaction Detail-DENDA
                    oViewModel = this.addDetail_SPPdenda(oViewModel, item);
                } //End if ((item.MONTHSPP_SEQNO >= oViewModel.MONTHSPP1.MONTHSPP_SEQNO) &&
            } //End if (oViewModel.IGNOREDENDA == 1)

            return oViewModel;
        } //End private Transaction_indetailVM addDetail_SPPdenda_next(Transaction_indetailVM poViewModel, MonthsppVM poItem)

        private Installment_indetailVM getINST_SPP(Transaction_indetailVM poViewModel)
        {
            //Installment_indetailVM vReturn = oDSInstallment.getData(poViewModel.STUDENT_ID, poViewModel.TRINTYPE_ID, poViewModel.CACHE_YEAR_FROM, poViewModel.CACHE_YEAR_TO);
            //Installment_indetailVM vReturn = oDSInstallment.getData(poViewModel.STUDENT_ID, poViewModel.TRINTYPE_ID, poViewModel.YEAR_FROM, poViewModel.YEAR_TO);
            Installment_indetailVM vReturn = oDSInstallment.getData(poViewModel.STUDENT_ID, 1, poViewModel.YEAR_FROM, poViewModel.YEAR_TO);
            if (vReturn == null)
            {
                vReturn = new Installment_indetailVM();
                vReturn.DTA_STS = valFLAG.FLAG_DTA_STS_CREATE;
            }
            else
            {
                vReturn.DTA_STS = valFLAG.FLAG_DTA_STS_UPDATE;
            }
            
            vReturn.INST_QTYBASE = 12;
            if (vReturn.INST_QTY == null) { vReturn.INST_QTY = 1; }
            else vReturn.INST_QTY = vReturn.INST_QTY + 1;
            return vReturn;
        } //End private Installment_indetailVM getINST_SPP(Transaction_indetailVM poViewModel)
        private Transaction_inddetailVM getItem_SPP(MonthsppVM poMonthitem, Transaction_indetailVM poViewModel) {
            Transaction_inddetailVM vReturn = new Transaction_inddetailVM();
            Transaction_indetailVM oViewModel = poViewModel;

            //Add Transaction Detail
            vReturn.TRINTYPE_ID = oViewModel.TRINTYPE_ID;
            vReturn.TRND_METHODID = oViewModel.TRINMETHOD_ID;
            vReturn.TRND_TYPEID = oViewModel.TRINTYPE_ID;
            vReturn.TRINTYPE_CODE = oViewModel.TRINTYPE_CODE;
            vReturn.TRINTYPE_SHORTDESC = oViewModel.TRINTYPE_SHORTDESC;
            vReturn.TRINTYPE_DESC = oViewModel.TRINTYPE_DESC;

            vReturn.TRND_QTY = 1;
            vReturn.TRND_PRICE = oViewModel.TRND_AMOUNT;
            vReturn.TRND_AMOUNT = oViewModel.TRND_AMOUNT;

            //vReturn.TRND_PRICEBASE = oViewModel.TRND_AMOUNT;
            //vReturn.TRND_QTYBASE = 1;
            //vReturn.TRND_AMOUNTBASE = oViewModel.TRND_AMOUNT;

            vReturn.TRND_PRICEBASE = oViewModel.TRND_AMOUNTBASE;
            vReturn.TRND_QTYBASE = 1;
            vReturn.TRND_AMOUNTBASE = oViewModel.TRND_AMOUNTBASE;
            

            vReturn.TRND_DESC = "SPP Bulan " + poMonthitem.MONTHSPP_SHORTDESC + " " + oViewModel.YEAR_SHORTDESC;
            vReturn.INSTD_SEQNO = poMonthitem.MONTHSPP_SEQNO;

            return vReturn;
        } //End private Transaction_inddetailVM getItem_SPP(MonthsppVM poMonthitem, Transaction_indetailVM poViewModel)
        private Transaction_inddetailVM getItem_DendaSPP(MonthsppVM poMonthitem, Transaction_indetailVM poViewModel)
        {
            Transaction_inddetailVM vReturn = null;
            Transaction_indetailVM oViewModel = poViewModel;
            //Fill TRINTYPE
            var oDataTrinttype = oDSTrintype.getData(valFLAG.FLAG_TRINTYPE_SPPDENDA);

            vReturn = new Transaction_inddetailVM();
            //Add Transaction Detail
            vReturn.TRINTYPE_ID = oViewModel.TRINTYPE_ID;
            vReturn.TRND_METHODID = oDataTrinttype.TRINMETHOD_ID;
            vReturn.TRND_TYPEID = oDataTrinttype.ID;
            vReturn.TRINTYPE_CODE = oDataTrinttype.TRINTYPE_CODE;
            vReturn.TRINTYPE_SHORTDESC = oDataTrinttype.TRINTYPE_SHORTDESC;
            vReturn.TRINTYPE_DESC = oDataTrinttype.TRINTYPE_DESC;

            vReturn.TRND_QTY = 1;

            vReturn.TRND_PRICE = oViewModel.TRND_AMOUNT; //oViewModel.TRND_AMOUNT_DENDA;
            vReturn.TRND_AMOUNT = oViewModel.TRND_AMOUNT; //oViewModel.TRND_AMOUNT_DENDA;
            vReturn.TRND_PRICEBASE = oViewModel.TRND_AMOUNT; //oViewModel.TRND_AMOUNT_DENDA;
            vReturn.TRND_QTYBASE = 1;
            vReturn.TRND_AMOUNTBASE = oViewModel.TRND_AMOUNT; //oViewModel.TRND_AMOUNT_DENDA;

            vReturn.TRND_DESC = "Denda SPP Bulan " + poMonthitem.MONTHSPP_SHORTDESC + " " + oViewModel.YEAR_SHORTDESC;
            vReturn.INSTD_SEQNO = poMonthitem.MONTHSPP_SEQNO;

            return vReturn;
        } //End private Transaction_inddetailVM getItem_DendaSPP(MonthsppVM poMonthitem, Transaction_indetailVM poViewModel)


        private Transaction_inddetailVM getItem_DendaSPP_BAKSTOPIFLUNAS(MonthsppVM poMonthitem, Transaction_indetailVM poViewModel)
        {
            Transaction_inddetailVM vReturn = null;
            Transaction_indetailVM oViewModel = poViewModel;
            //Fill TRINTYPE
            var oDataTrinttype = oDSTrintype.getData(valFLAG.FLAG_TRINTYPE_SPPDENDA);

            Byte? nMonth = poMonthitem.MONTHSPP_SEQNO;
            Byte? nSysmonth = oViewModel.MONTHS.Where(fld => fld.MONTHSPP_NUM == oViewModel.SYSDATE.Value.Month).FirstOrDefault().MONTHSPP_SEQNO;
            if (nMonth < nSysmonth)
            {
                vReturn = new Transaction_inddetailVM();
                //Add Transaction Detail
                vReturn.TRINTYPE_ID = oViewModel.TRINTYPE_ID;
                vReturn.TRND_METHODID = oDataTrinttype.TRINMETHOD_ID;
                vReturn.TRND_TYPEID = oDataTrinttype.ID;
                vReturn.TRINTYPE_CODE = oDataTrinttype.TRINTYPE_CODE;
                vReturn.TRINTYPE_SHORTDESC = oDataTrinttype.TRINTYPE_SHORTDESC;
                vReturn.TRINTYPE_DESC = oDataTrinttype.TRINTYPE_DESC;

                vReturn.TRND_QTY = 1;

                vReturn.TRND_PRICE = oViewModel.TRND_AMOUNT; //oViewModel.TRND_AMOUNT_DENDA;
                vReturn.TRND_AMOUNT = oViewModel.TRND_AMOUNT; //oViewModel.TRND_AMOUNT_DENDA;
                vReturn.TRND_PRICEBASE = oViewModel.TRND_AMOUNT; //oViewModel.TRND_AMOUNT_DENDA;
                vReturn.TRND_QTYBASE = 1;
                vReturn.TRND_AMOUNTBASE = oViewModel.TRND_AMOUNT; //oViewModel.TRND_AMOUNT_DENDA;

                //vReturn.TRND_DESC = "Denda SPP Bulan " + poMonthitem.MONTHSPP_SHORTDESC + " " + oViewModel.YEAR_SHORTDESC;
                vReturn.TRND_DESC = "Denda SPP Bulan " + poMonthitem.MONTHSPP_SHORTDESC + " " + oViewModel.YEAR_SHORTDESC;
                vReturn.INSTD_SEQNO = nMonth;
            } //End if (nMonth < nSysmonth)
            return vReturn;
        } //End private Transaction_inddetailVM getItem_DendaSPP_BAKSTOPIFLUNAS(MonthsppVM poMonthitem, Transaction_indetailVM poViewModel)
        private Transaction_indetailVM addDetail_SPPdenda_first_BAKSTOPIFLUNAS(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        {
            Transaction_indetailVM oViewModel = poViewModel;
            MonthsppVM item = poItem;
            Byte? nMONTH1 = oViewModel.MONTHSPP2;
            Byte? nMONTH2 = oViewModel.MONTHSPP3;
            Byte? nMONTH2b = (Byte?)((nMONTH1 + nMONTH2) - 1);
            nMONTH2 = nMONTH2b;
            if (nMONTH2 > 12) nMONTH2 = 12;

            if (oViewModel.IGNOREDENDA != 1)
            {
                if ((item.MONTHSPP_SEQNO >= nMONTH1) &&
                      (item.MONTHSPP_SEQNO <= nMONTH2))
                {
                    //Add Transaction Detail-DENDA
                    oViewModel = this.addDetail_SPPdenda(oViewModel, item);
                } //End if ((item.MONTHSPP_SEQNO >= oViewModel.MONTHSPP1.MONTHSPP_SEQNO) &&
            } //End if (oViewModel.IGNOREDENDA == 1)

            return oViewModel;
        } //End private Transaction_indetailVM addDetail_SPPdenda_first_BAKSTOPIFLUNAS(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        private Transaction_indetailVM addDetail_SPPdenda_next_BAKSTOPIFLUNAS(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        {
            Transaction_indetailVM oViewModel = poViewModel;
            MonthsppVM item = poItem;
            Byte? nMONTH1 = oViewModel.MONTHSPP2;
            Byte? nMONTH2 = oViewModel.MONTHSPP3;
            Byte? nMONTH2b = (Byte?)((nMONTH1 + nMONTH2) - 1);
            nMONTH2 = nMONTH2b;
            if (nMONTH2 > 12) nMONTH2 = 12;

            if (oViewModel.IGNOREDENDA != 1)
            {
                if ((item.MONTHSPP_SEQNO >= nMONTH1) &&
                      (item.MONTHSPP_SEQNO <= nMONTH2))
                {
                    //Add Transaction Detail-DENDA
                    oViewModel = this.addDetail_SPPdenda(oViewModel, item);
                } //End if ((item.MONTHSPP_SEQNO >= oViewModel.MONTHSPP1.MONTHSPP_SEQNO) &&
            } //End if (oViewModel.IGNOREDENDA == 1)

            return oViewModel;
        } //End private Transaction_indetailVM addDetail_SPPdenda_next_BAKSTOPIFLUNAS(Transaction_indetailVM poViewModel, MonthsppVM poItem)


        //-issue#1, issue#2
        private Transaction_indetailVM CREATEInitspp_ViewModel_BACKUP(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = poViewModel;
            //Get INST MONTHLY
            oViewModel.MONTHLY_INST = this.getINST_SPP(oViewModel);
            oViewModel.MONTHLY_INST_SPP = oViewModel.MONTHLY_INST;

            if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
            {
                //EXTRA CUSTOM-TRANSACTIONDETAIL BASE
                oViewModel.TRND_PRICEBASE = oViewModel.MONTHLY_INST.INST_PRICEBASE;
                oViewModel.TRND_AMOUNTBASE = oViewModel.MONTHLY_INST.INST_PRICEBASE;
            } //End if

            //Detail MONTHS
            oViewModel.MONTHLY_MONTHS = new List<MonthsppVM>();
            if (oViewModel.MONTHLY_INST.INST_QTY <= 12)
            {
                oViewModel.MONTHS = oDSMonthspp.getDatalist_lookup();
                oViewModel.MONTHSPP1 = oViewModel.MONTHS.Where(fld => fld.MONTHSPP_SEQNO == (Byte?)oViewModel.MONTHLY_INST.INST_QTY).FirstOrDefault();
                foreach (var item in oViewModel.MONTHS)
                {
                    if (item.MONTHSPP_SEQNO >= oViewModel.MONTHSPP1.MONTHSPP_SEQNO)
                    {
                        MonthsppVM oVM = new MonthsppVM();
                        oVM = item;
                        oViewModel.MONTHLY_MONTHS.Add(item);
                    } //End if (item.MONTHSPP_SEQNO == oViewModel.MONTHSPP1.MONTHSPP_SEQNO)
                } //End foreach (var item in oSPP)
            } //End if (oViewModel.MONTHLY_INST.INST_QTY <= 12)

            return oViewModel;
        } //End private Transaction_indetailVM CREATEInitspp_ViewModel(Transaction_indetailVM poViewModel)
    
    } //End public partial class Transaction_inController : Controller
} //End namespace APPBASE.Controllers
