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
        //HEADER
        private Transaction_indetailVM CREATEInit_ViewModel(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = poViewModel;
            //GET EXTRA CUSTOM-TRANSACTIONDETAIL BASE
            oDSClasslevel.getData(oViewModel.CLASSLEVEL_ID, oViewModel.TRINTYPE_ID, oViewModel.IS_PINDAHAN);
            //EXTRA CUSTOM-TRANSACTIONDETAIL BASE
            oViewModel.TRND_PRICEBASE = oDSClasslevel.TRND_PRICEBASE;
            oViewModel.TRND_QTYBASE = oDSClasslevel.TRND_QTYBASE;
            oViewModel.TRND_AMOUNTBASE = oDSClasslevel.TRND_AMOUNTBASE;
            //EXTRA CUSTOM-TRANSACTIONDETAIL BASE-DENDA
            oViewModel.TRND_PRICEBASE_DENDA = oDSClasslevel.TRND_PRICEBASE_DENDA;
            oViewModel.TRND_QTYBASE_DENDA = oDSClasslevel.TRND_QTYBASE_DENDA;
            oViewModel.TRND_AMOUNTBASE_DENDA = oDSClasslevel.TRND_AMOUNTBASE_DENDA;
            //ACtionID=3: Create/Add transaction Detail
            if (oViewModel.ActionID == 3)
            {
                //EXTRA CUSTOM-TRANSACTIONDETAIL
                oViewModel.TRND_AMOUNT = oDSClasslevel.TRND_AMOUNTBASE;
                oViewModel.TRND_DESC = null;
                //EXTRA CUSTOM-TRANSACTIONDETAIL-DENDA
                oViewModel.TRND_AMOUNT_DENDA = oDSClasslevel.TRND_AMOUNTBASE_DENDA;
                oViewModel.TRND_DESC_DENDA = null;
            }
            //ACtionID=4: Edit transaction Detail
            if (oViewModel.ActionID == 4)
            {
                //EXTRA CUSTOM-TRANSACTIONDETAIL
                oViewModel.TRND_AMOUNT = oViewModel.TRND_AMOUNT;
                oViewModel.TRND_DESC = oViewModel.TRND_DESC;
                //EXTRA CUSTOM-TRANSACTIONDETAIL-DENDA
                oViewModel.TRND_AMOUNT_DENDA = oViewModel.TRND_AMOUNT_DENDA;
                oViewModel.TRND_DESC_DENDA = oViewModel.TRND_DESC_DENDA;
            } //End if (oViewModel.ActionID == 3)

            return oViewModel;
        } //End private Transaction_indetailVM CREATEInit_ViewModel(Transaction_indetailVM poViewModel)
        private Transaction_indetailVM CREATEMap_ViewModel(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = poViewModel;

            //RESET DETAIL TRANSACTION BY TRINTYPE: REGULER
            oViewModel.DETAIL = this.removeItem(oViewModel);
            //Add Transaction Detail
            if (oViewModel.DETAIL == null) { oViewModel.DETAIL = new List<Transaction_inddetailVM>(); }
            Transaction_inddetailVM oViewModelDETAIL = getItem(oViewModel);
            oViewModel.DETAIL.Add(oViewModelDETAIL);
            //Reset TRINTYPE
            oViewModel.TRINTYPE_ID = null;
            oViewModel.TRINTYPE_CODE = null;
            oViewModel.TRINTYPE_SHORTDESC = null;
            oViewModel.TRINTYPE_DESC = null;
            oViewModel.TRINMETHOD_ID = null;

            return oViewModel;
        } //End private Transaction_indetailVM CREATEInit_ViewModel(Transaction_indetailVM poViewModel)
        //ITEM
        private Transaction_inddetailVM getItem(Transaction_indetailVM poViewModel)
        {
            Transaction_inddetailVM vReturn = new Transaction_inddetailVM();
            Transaction_indetailVM oViewModel = poViewModel;

            //Add Transaction Detail
            vReturn.TRINTYPE_ID = oViewModel.TRINTYPE_ID;
            vReturn.TRND_METHODID = oViewModel.TRINMETHOD_ID;
            vReturn.TRND_TYPEID = oViewModel.TRINTYPE_ID;
            vReturn.TRINTYPE_CODE = oViewModel.TRINTYPE_CODE;
            vReturn.TRINTYPE_SHORTDESC = oViewModel.TRINTYPE_SHORTDESC;
            vReturn.TRINTYPE_DESC = oViewModel.TRINTYPE_DESC;

            //vReturn.TRND_PRICE = 1;
            vReturn.TRND_PRICE = oViewModel.TRND_AMOUNT;
            vReturn.TRND_QTY = 1;
            vReturn.TRND_AMOUNT = oViewModel.TRND_AMOUNT;
            
            vReturn.TRND_PRICEBASE = oViewModel.TRND_AMOUNT;
            vReturn.TRND_QTYBASE = 1;
            vReturn.TRND_AMOUNTBASE = oViewModel.TRND_AMOUNT;
            
            vReturn.TRND_DESC = oViewModel.TRND_DESC;

            return vReturn;
        } //End private Transaction_inddetailVM getItem(MonthsppVM poMonthitem, Transaction_indetailVM poViewModel)
        private List<Transaction_inddetailVM> removeItem(Transaction_indetailVM poViewModel)
        {
            Transaction_indetailVM oViewModel = poViewModel;

            return removeItem(oViewModel, oViewModel.TRINTYPE_ID);
        } //End private List<Transaction_inddetailVM> removeItem(Transaction_indetailVM poViewModel)
        private List<Transaction_inddetailVM> removeItem(Transaction_indetailVM poViewModel, int? pnTRINTYPE_ID)
        {
            Transaction_indetailVM oViewModel = poViewModel;

            //RESET DETAIL TRANSACTION BY TRINTYPE: REGULER
            if (oViewModel.DETAIL != null)
            {
                //DELETE SPP
                var oRemove = oViewModel.DETAIL.Where(fld => fld.TRINTYPE_ID == pnTRINTYPE_ID).ToList();
                oViewModel.DETAIL.RemoveAll(fld => oRemove.Any(a => a.TRINTYPE_ID == fld.TRINTYPE_ID));
            } //End if (oViewModel.DETAIL != null)
            
            return oViewModel.DETAIL;
        } //End private List<Transaction_inddetailVM> removeItem(Transaction_indetailVM poViewModel, int? pnTRINTYPE_ID)

        //RESET SESSION
        private void resetSESSIOAN()
        {
        } //End private void resetSESSIOAN()
        private void resetSESSIOAN_Transaction()
        {
            Session[hlpConfig.SessionInfo.getTransaction_inID()] = null;
        } //End private void resetSESSIOAN_Transaction(Transaction_indetailVM poViewModel)
        private void resetSESSIOAN_TransactionView()
        {
            Session[hlpConfig.SessionInfo.getTransactionView_inID()] = null;
        } //End private void resetSESSIOAN_Report(Transaction_indetailVM poViewModel)

        //UPDATE SESSION
        private void updateSESSIOAN() {
        } //End private void updateSESSIOAN()
        private void updateSESSIOAN_Transaction(Transaction_indetailVM poViewModel)
        {
            Session[hlpConfig.SessionInfo.getTransaction_inID()] = poViewModel;
        } //End private void updateSESSIOAN()
        private void updateSESSIOAN_TransactionView(Transaction_indetailVM poViewModel)
        {
            Session[hlpConfig.SessionInfo.getTransactionView_inID()] = poViewModel;
        } //End private void updateSESSIOAN_TransactionView(Transaction_indetailVM poViewModel)

        //GET SESSION
        private void getSESSIOAN()
        {
        } //End private void getSESSIOAN()
        private Transaction_indetailVM getSESSIOAN_Transaction()
        {
            return (Transaction_indetailVM)Session[hlpConfig.SessionInfo.getTransaction_inID()];
        } //End private Transaction_indetailVM getSESSIOAN_Transaction()
        private void getSESSIOAN_TransactionView(Transaction_indetailVM poViewModel)
        {
            
        } //End private void getSESSIOAN_TransactionView(Transaction_indetailVM poViewModel)
    } //End public partial class Transaction_inController : Controller
} //End namespace APPBASE.Controllers
