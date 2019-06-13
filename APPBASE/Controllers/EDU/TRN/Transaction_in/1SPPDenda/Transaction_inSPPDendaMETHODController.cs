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
        private Transaction_indetailVM CREATEInitsppdenda_ViewModel(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = poViewModel;
            //Get INST MONTHLY
            if (oViewModel.MONTHLY_INST == null) {
                oViewModel.MONTHLY_INST = this.getINST_SPP(oViewModel);
                oViewModel.MONTHLY_INST_SPP = oViewModel.MONTHLY_INST;
            } //End if (oViewModel.MONTHLY_INST == null)

            if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
            {
                //EXTRA CUSTOM-TRANSACTIONDETAIL BASE
                oViewModel.TRND_PRICEBASE = (oDSClasslevel.TRND_PRICEBASE_DENDA/100) * oViewModel.MONTHLY_INST.INST_PRICEBASE;
                oViewModel.TRND_AMOUNTBASE = (oDSClasslevel.TRND_PRICEBASE_DENDA / 100) * oViewModel.MONTHLY_INST.INST_PRICEBASE;
                //EXTRA CUSTOM-TRANSACTIONDETAIL
                oViewModel.TRND_AMOUNT = (oDSClasslevel.TRND_PRICEBASE_DENDA / 100) * oViewModel.MONTHLY_INST.INST_PRICEBASE;
            } //End if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)

            //Detail MONTHS
            oViewModel.MONTHLY_MONTHS = new List<MonthsppVM>();
            oViewModel.MONTHS = oDSMonthspp.getDatalist_lookup();
            oViewModel.MONTHLY_MONTHS = oViewModel.MONTHS;

            return oViewModel;
        } //End private Transaction_indetailVM CREATEInitsppdenda_ViewModel(Transaction_indetailVM poViewModel)
        private Transaction_indetailVM CREATEMapsppdenda_ViewModel(Transaction_indetailVM poViewModel, Transaction_indetailVM poViewModel_posted)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = poViewModel;
            Transaction_indetailVM oViewModel_posted = poViewModel_posted;
            oViewModel_posted.TRND_AMOUNT = hlpConvertionAndFormating.ConvertStringToDecimal(oViewModel_posted.TRND_AMOUNT_S);
            oViewModel.TRND_AMOUNT = oViewModel_posted.TRND_AMOUNT;

            oViewModel.MONTHSPP2 = oViewModel_posted.MONTHSPP2;
            oViewModel.MONTHSPP3 = oViewModel_posted.MONTHSPP3;
            oViewModel.IGNOREDENDA = null;

            //RESET DETAIL TRANSACTION BY TRINTYPE: SPP/DENDA SPP/MID GANJIL, DLL
            if (oViewModel.DETAIL != null)
            {
                //DELETE DENDA SPP
                oViewModel.DETAIL = this.removeItem(oViewModel, valFLAG.FLAG_TRINTYPE_SPPDENDA);
            } //End if (oViewModel.DETAIL != null)

            //Add Transaction Detail
            foreach (var item in oViewModel.MONTHLY_MONTHS)
            {
                //addDetailSPP_first
                if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
                {
                    //Add Transaction Detail SPP+Denda if exist
                    oViewModel = this.addDetail_SPPdenda_first(oViewModel, item);
                } //End if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)

                //addDetailSPP_next
                if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
                {
                    //Add Transaction Detail SPP+Denda if exist
                    oViewModel = this.addDetail_SPPdenda_next(oViewModel, item);
                } //End if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
            } //End foreach (var item in poViewModel_posted.MONTHLY_MONTHS)

            return oViewModel;
        } //End private Transaction_indetailVM CREATEMapsppdenda_ViewModel(Transaction_indetailVM poViewModel, Transaction_indetailVM poViewModel_posted)



        private Transaction_indetailVM CREATEInitsppdenda_ViewModel_BAKSTOPIFLUNAS(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = poViewModel;
            //Get INST MONTHLY
            if (oViewModel.MONTHLY_INST == null)
            {
                oViewModel.MONTHLY_INST = this.getINST_SPP(oViewModel);
                oViewModel.MONTHLY_INST_SPP = oViewModel.MONTHLY_INST;
            } //End if (oViewModel.MONTHLY_INST == null)

            if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
            {
                //EXTRA CUSTOM-TRANSACTIONDETAIL BASE
                oViewModel.TRND_PRICEBASE = (oDSClasslevel.TRND_PRICEBASE_DENDA / 100) * oViewModel.MONTHLY_INST.INST_PRICEBASE;
                oViewModel.TRND_AMOUNTBASE = (oDSClasslevel.TRND_PRICEBASE_DENDA / 100) * oViewModel.MONTHLY_INST.INST_PRICEBASE;
                //EXTRA CUSTOM-TRANSACTIONDETAIL
                oViewModel.TRND_AMOUNT = (oDSClasslevel.TRND_PRICEBASE_DENDA / 100) * oViewModel.MONTHLY_INST.INST_PRICEBASE;
            } //End if (oViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)

            //Detail MONTHS
            oViewModel.MONTHLY_MONTHS = new List<MonthsppVM>();
            if (oViewModel.MONTHLY_INST.INST_QTY <= 12)
            {
                oViewModel.MONTHS = oDSMonthspp.getDatalist_lookup();
                oViewModel.MONTHSPP1 = oViewModel.MONTHS.Where(fld => fld.MONTHSPP_SEQNO == 1).FirstOrDefault();
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
        } //End private Transaction_indetailVM CREATEInitsppdenda_ViewModel_BAKSTOPIFLUNAS(Transaction_indetailVM poViewModel)
    } //End public partial class Transaction_inController : Controller
} //End namespace APPBASE.Controllers
