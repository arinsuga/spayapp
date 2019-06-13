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
        //MAP
        private Transaction_indetailVM CREATEInitsclub_ViewModel(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = poViewModel;
            //Get INST MONTHLY
            oViewModel.MONTHLY_INST = this.getINST_SCLUB(oViewModel);
            oViewModel.MONTHLY_INST_SCLUB = oViewModel.MONTHLY_INST;

            //Detail MONTHS
            oViewModel.MONTHLY_MONTHS = new List<MonthsppVM>();
            if (oViewModel.MONTHLY_INST.INST_QTY <= 12) {
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
        private Transaction_indetailVM CREATEMapsclub_ViewModel(Transaction_indetailVM poViewModel, Transaction_indetailVM poViewModel_posted)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = poViewModel;
            Transaction_indetailVM oViewModel_posted = poViewModel_posted;
            oViewModel.MONTHSPP2 = oViewModel_posted.MONTHSPP2;
            oViewModel.MONTHSPP3 = oViewModel_posted.MONTHSPP3;
            oViewModel.IGNOREDENDA = oViewModel_posted.IGNOREDENDA;

            //RESET DETAIL TRANSACTION BY TRINTYPE: SPP/DENDA SPP/MID GANJIL, DLL
            if (oViewModel.DETAIL != null) {
                //DELETE SPP
                oViewModel.DETAIL = this.removeItem(oViewModel, valFLAG.FLAG_TRINTYPE_SCLUB);
                //DELETE DENDA SPP : NOTUSE
            } //End if (oViewModel.DETAIL != null)

            //Add Transaction Detail
            oViewModel.MONTHSPP_COUNT = 0;
            foreach (var item in oViewModel.MONTHLY_MONTHS)
            {
                //addDetail_SCLUBfirst
                if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
                {
                    oViewModel.MONTHSPP_COUNT = oViewModel.MONTHSPP3;
                    //Add Transaction Detail Studiklub
                    oViewModel = this.addDetail_SCLUBfirst(oViewModel, item);
                } //End if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)

                //addDetail_SCLUBnext
                if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
                {
                    //Add Transaction Detail Studiklub
                    oViewModel = this.addDetail_SCLUBnext(oViewModel, item);
                } //End if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
            } //End foreach (var item in poViewModel_posted.MONTHLY_MONTHS)

            return oViewModel;
        } //End private Transaction_indetailVM CREATEMapspp_ViewModel(Transaction_indetailVM poViewModel, Transaction_indetailVM poViewModel_par)
        private Transaction_indetailVM CREATEMapsclub_ViewModelINST(Transaction_indetailVM poViewModel)
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
            //oViewModel.MONTHLY_INST.INST_DT = oViewModel.TRN_DT;

            //if (oViewModel.MONTHLY_INST.INST_QTY < 12) oViewModel.MONTHLY_INST.INST_STS = 1;
            //else oViewModel.MONTHLY_INST.INST_STS = 2;

            if (oViewModel.MONTHSPP2 < 12) oViewModel.MONTHLY_INST.INST_STS = 1;
            else oViewModel.MONTHLY_INST.INST_STS = 2;

            oViewModel.MONTHLY_INST.INST_STARTDT = hlpConvertionAndFormating.ConvertStringToDate("01/01/" + oViewModel.YEAR_FROM.Value.Year.ToString().Trim(), "dd/MM/yyyy");
            oViewModel.MONTHLY_INST.INST_ENDDT = hlpConvertionAndFormating.ConvertStringToDate("31/12/" + oViewModel.YEAR_TO.Value.Year.ToString().Trim(), "dd/MM/yyyy");
            oViewModel.MONTHLY_INST.INST_TYPEID = (Byte?)oViewModel.TRINTYPE_ID;
            //oViewModel.MONTHLY_INST.INST_SUBTYPEID = null;

            //BASE VALUE
            //addDetailSPP_first
            Byte? nMONTH1 = oViewModel.MONTHSPP2;
            Byte? nMONTH2 = oViewModel.MONTHSPP3;
            Byte? nMONTH2b = (Byte?)((nMONTH1 + nMONTH2) - 1);
            nMONTH2 = nMONTH2b;
            if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
            {
                //oViewModel.MONTHLY_INST.INST_DT = oViewModel.TRN_DT;

                oViewModel.MONTHLY_INST.INST_QTY = nMONTH2;
                //oViewModel.MONTHLY_INST.INST_QTYBASE = (12 - nMONTH1)+1;
                oViewModel.MONTHLY_INST.INST_QTYBASE = 12;
                //BASE VALUE
                oViewModel.MONTHLY_INST.INST_PRICEBASE = oViewModel.TRND_AMOUNTBASE;
                //oViewModel.MONTHLY_INST.INST_AMOUNTBASE = ((12 - nMONTH1) + 1) * oViewModel.TRND_AMOUNTBASE;
                oViewModel.MONTHLY_INST.INST_AMOUNTBASE = 12 * oViewModel.TRND_AMOUNTBASE;
            }
            else
            {
                oViewModel.MONTHLY_INST.INST_QTY = oViewModel.MONTHSPP2;
            } ////End if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
            if (oViewModel.MONTHLY_INST.INST_AMOUNT == null) oViewModel.MONTHLY_INST.INST_AMOUNT = 0;
            oViewModel.MONTHLY_INST.INST_AMOUNT = oViewModel.MONTHLY_INST.INST_AMOUNT + (oViewModel.TRND_AMOUNT * oViewModel.MONTHSPP_COUNT);

            oViewModel.MONTHLY_INST.INST_DESC = "Studi Klub Tahun Ajaran " + oViewModel.YEAR_SHORTDESC;
            oViewModel.MONTHLY_INST.STUDENT_ID = oViewModel.STUDENT_ID;
            //oViewModel.MONTHLY_INST.INSTD_ID = null;
            
            //CACHE - YEAR
            oViewModel.MONTHLY_INST.CACHE_YEAR_CODE = oViewModel.YEAR_CODE;
            oViewModel.MONTHLY_INST.CACHE_YEAR_SHORTDESC = oViewModel.YEAR_SHORTDESC;
            oViewModel.MONTHLY_INST.CACHE_YEAR_DESC = oViewModel.YEAR_DESC;
            oViewModel.MONTHLY_INST.CACHE_YEAR_FROM = oViewModel.YEAR_FROM;
            oViewModel.MONTHLY_INST.CACHE_YEAR_TO = oViewModel.YEAR_TO;

            //SET MAP TO SCLUB-MODEL
            oViewModel.MONTHLY_INST_SCLUB = oViewModel.MONTHLY_INST;
            return oViewModel;
        } //End private Transaction_indetailVM CREATEMapspp_ViewModel(Transaction_indetailVM poViewModel, Transaction_indetailVM poViewModel_par)
        //ADD
        private Transaction_indetailVM addDetail_SCLUB(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        {
            Transaction_indetailVM oViewModel = poViewModel;
            MonthsppVM item = poItem;
            MonthsppVM oMonthitem = oViewModel.MONTHLY_MONTHS.Where(fld => fld.ID == item.ID).FirstOrDefault();

            //Add Transaction Detail
            if (oViewModel.DETAIL == null) { oViewModel.DETAIL = new List<Transaction_inddetailVM>(); }
            Transaction_inddetailVM oViewModelDETAIL = getItem_SCLUB(oMonthitem, oViewModel);
            oViewModel.DETAIL.Add(oViewModelDETAIL);

            return oViewModel;
        } //End private Transaction_indetailVM addDetail(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        private Transaction_indetailVM addDetail_SCLUBfirst(Transaction_indetailVM poViewModel, MonthsppVM poItem)
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
                oViewModel = this.addDetail_SCLUB(oViewModel, item);
            } //End if ((item.MONTHSPP_SEQNO >= oViewModel.MONTHSPP1.MONTHSPP_SEQNO) &&


            return oViewModel;
        } //End private Transaction_indetailVM addDetail_first(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        private Transaction_indetailVM addDetail_SCLUBnext(Transaction_indetailVM poViewModel, MonthsppVM poItem)
        {
            Transaction_indetailVM oViewModel = poViewModel;
            MonthsppVM item = poItem;

            if ((item.MONTHSPP_SEQNO >= oViewModel.MONTHSPP1.MONTHSPP_SEQNO) &&
                (item.MONTHSPP_SEQNO <= oViewModel.MONTHSPP2)) {
                oViewModel.MONTHSPP_COUNT = (byte?)(oViewModel.MONTHSPP_COUNT + 1);
                //Add Transaction Detail
                oViewModel = this.addDetail_SCLUB(oViewModel, item);
            } //End if ((item.MONTHSPP_SEQNO >= oViewModel.MONTHSPP1.MONTHSPP_SEQNO) &&

            return oViewModel;
        } //End private Transaction_indetailVM addDetail_next(Transaction_indetailVM poViewModel, MonthsppVM poItem)

        //GET
        private Installment_indetailVM getINST_SCLUB(Transaction_indetailVM poViewModel)
        {
            return this.getINST_MONTHLY(poViewModel);
        } //End private Installment_indetailVM getINST_SCLUB(Transaction_indetailVM poViewModel)
        private Transaction_inddetailVM getItem_SCLUB(MonthsppVM poMonthitem, Transaction_indetailVM poViewModel)
        {
            return this.getItem_MONTHLY(poMonthitem, poViewModel);
        } //End private Transaction_inddetailVM getItem_SCLUB(MonthsppVM poMonthitem, Transaction_indetailVM poViewModel)
    } //End public partial class Transaction_inController : Controller
} //End namespace APPBASE.Controllers
