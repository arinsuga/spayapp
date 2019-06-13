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
        private Transaction_indetailVM CREATEInitCANINSTALL_ViewModel(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = poViewModel;

            //GET EXTRA CUSTOM-TRANSACTIONDETAIL BASE
            oDSClasslevel.getData(oViewModel.CLASSLEVEL_ID, oViewModel.TRINTYPE_ID, oViewModel.IS_PINDAHAN);
            //Get INST RANDOM
            oViewModel.INST = this.getINST_CANINSTALL(oViewModel);

            if (oViewModel.INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE) {
                //EXTRA CUSTOM-TRANSACTIONDETAIL BASE
                oViewModel.TRND_PRICEBASE = oViewModel.INST.INST_PRICEBASE;
                //oViewModel.TRND_QTYBASE = oDSClasslevel.TRND_QTYBASE;
                oViewModel.TRND_AMOUNTBASE = oViewModel.INST.INST_AMOUNTBASE;
            } //End if


            //ACtionID=3: Create/Add transaction Detail
            if (oViewModel.ActionID == 3)
            {
                //EXTRA CUSTOM-TRANSACTIONDETAIL
                oViewModel.TRND_AMOUNT = oViewModel.INST.INST_AMOUNT_OUTSTANDING;
                oViewModel.TRND_DESC = null;
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
            } //End

            //Get INSTLIST RANDOM
            if (oViewModel.INSTLIST == null) oViewModel.INSTLIST = new List<Installment_indetailVM>();
            oViewModel.INSTLIST.RemoveAll(fld => fld.INST_TYPEID == oViewModel.INST.INST_TYPEID);
            oViewModel.INSTLIST.Add(oViewModel.INST);
            return oViewModel;
        } //End private Transaction_indetailVM CREATEInitCANINSTALL_ViewModel(Transaction_indetailVM poViewModel)
        private Transaction_indetailVM CREATEMapCANINSTALL_ViewModel(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = poViewModel;

            //RESET DETAIL TRANSACTION BY TRINTYPE: REGULER
            oViewModel.DETAIL = this.removeItem(oViewModel);
            //Add Transaction Detail
            if (oViewModel.DETAIL == null) { oViewModel.DETAIL = new List<Transaction_inddetailVM>(); }
            Transaction_inddetailVM oViewModelDETAIL = this.getItem_CANINSTALL(oViewModel);
            oViewModel.DETAIL.Add(oViewModelDETAIL);

            return oViewModel;
        } //End private Transaction_indetailVM CREATEMapCANINSTALL_ViewModel(Transaction_indetailVM poViewModel)
        private Transaction_indetailVM CREATEMapCANINSTALL_ViewModelINST(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = poViewModel;
            Installment_indetailVM oINST = new Installment_indetailVM();
            int nINSTIndex = oViewModel.INSTLIST.FindIndex(fld => fld.INST_TYPEID == oViewModel.TRINTYPE_ID);
            oINST.InjectFrom(oViewModel.INSTLIST[nINSTIndex]);
            oINST.BRANCH_ID = oViewModel.BRANCH_ID;
            oINST.YEAR_ID = oViewModel.YEAR_ID;
            oINST.SEMESTER_ID = oViewModel.SEMESTER_ID;
            oINST.CLASSTYPE_ID = oViewModel.CLASSTYPE_ID;
            oINST.CLASSLEVEL_ID = oViewModel.CLASSLEVEL_ID;
            oINST.CLASSROOM_ID = oViewModel.CLASSROOM_ID;
            oINST.CLASSMAJOR_ID = oViewModel.CLASSMAJOR_ID;
            oINST.INST_STARTDT = hlpConvertionAndFormating.ConvertStringToDate("01/01/" + oViewModel.YEAR_FROM.Value.Year.ToString().Trim(), "dd/MM/yyyy");
            oINST.INST_ENDDT = hlpConvertionAndFormating.ConvertStringToDate("31/12/" + oViewModel.YEAR_TO.Value.Year.ToString().Trim(), "dd/MM/yyyy");
            oINST.INST_TYPEID = (Byte?)oViewModel.TRINTYPE_ID;
            //BASE VALUE
            oINST.INST_PRICEBASE = oViewModel.TRND_PRICEBASE;
            oINST.INST_AMOUNTBASE = oViewModel.TRND_AMOUNTBASE;
            oINST.INST_QTY = oINST.INST_QTY + 1;
            if (oINST.INST_AMOUNT == null) oINST.INST_AMOUNT = 0;
            oINST.INST_AMOUNT = oINST.INST_AMOUNT + oViewModel.TRND_AMOUNT;
            if (oINST.INST_AMOUNT < oINST.INST_AMOUNTBASE) oINST.INST_STS = 1;
            else oINST.INST_STS = 2;
            oINST.INST_DESC = oViewModel.TRINTYPE_SHORTDESC + " ke " + oINST.INST_QTY.ToString() + " " + oViewModel.YEAR_SHORTDESC;
            oINST.STUDENT_ID = oViewModel.STUDENT_ID;
            //CACHE - YEAR
            oINST.CACHE_YEAR_CODE = oViewModel.YEAR_CODE;
            oINST.CACHE_YEAR_SHORTDESC = oViewModel.YEAR_SHORTDESC;
            oINST.CACHE_YEAR_DESC = oViewModel.YEAR_DESC;
            oINST.CACHE_YEAR_FROM = oViewModel.YEAR_FROM;
            oINST.CACHE_YEAR_TO = oViewModel.YEAR_TO;
            //SET MAP TO SCLUB-MODEL
            oViewModel.INSTLIST[nINSTIndex] = oINST;
            return oViewModel;
        } //End method
        //ITEM
        private Transaction_inddetailVM getItem_CANINSTALL(Transaction_indetailVM poViewModel)
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
            
            vReturn.TRND_QTY = 1;
            vReturn.TRND_PRICE = 1;
            vReturn.TRND_AMOUNT = oViewModel.TRND_AMOUNT;

            vReturn.TRND_PRICEBASE = oViewModel.TRND_PRICEBASE;
            vReturn.TRND_QTYBASE = 1;
            vReturn.TRND_AMOUNTBASE = oViewModel.TRND_AMOUNTBASE;
            
            vReturn.TRND_DESC = oViewModel.TRND_DESC;

            return vReturn;
        } //End private Transaction_inddetailVM getItem_CANINSTALL(Transaction_indetailVM poViewModel)
        //GET
        private Installment_indetailVM getINST_CANINSTALL(Transaction_indetailVM poViewModel)
        {
            return this.getINST_RANDOM(poViewModel);
        } //End method
        private Transaction_inddetailVM getItem_CANINSTALL(MonthsppVM poMonthitem, Transaction_indetailVM poViewModel)
        {
            return this.getItem_MONTHLY(poMonthitem, poViewModel);
        } //End private Transaction_inddetailVM getItem_CANINSTALL(MonthsppVM poMonthitem, Transaction_indetailVM poViewModel)

        private Transaction_indetailVM CREATEInitCANINSTALL_ViewModel_BAK20170511(Transaction_indetailVM poViewModel)
        {
            //Update ViewModel
            Transaction_indetailVM oViewModel = poViewModel;

            //GET EXTRA CUSTOM-TRANSACTIONDETAIL BASE
            oDSClasslevel.getData(oViewModel.CLASSLEVEL_ID, oViewModel.TRINTYPE_ID, oViewModel.IS_PINDAHAN);
            //Get INST RANDOM
            oViewModel.INST = this.getINST_CANINSTALL(oViewModel);

            if (oViewModel.INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
            {
                //EXTRA CUSTOM-TRANSACTIONDETAIL BASE
                oViewModel.TRND_PRICEBASE = oViewModel.INST.INST_PRICEBASE;
                oViewModel.TRND_AMOUNTBASE = oViewModel.INST.INST_AMOUNTBASE;
            } //End if


            //ACtionID=3: Create/Add transaction Detail
            if (oViewModel.ActionID == 3)
            {
                //EXTRA CUSTOM-TRANSACTIONDETAIL
                oViewModel.TRND_AMOUNT = oViewModel.INST.INST_AMOUNT_OUTSTANDING;
                oViewModel.TRND_DESC = null;
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
            } //End if

            //Get INSTLIST RANDOM
            if (oViewModel.INSTLIST == null) oViewModel.INSTLIST = new List<Installment_indetailVM>();
            if (oViewModel.INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
            {
                //if (oViewModel.INSTLIST == null) oViewModel.INSTLIST = new List<Installment_indetailVM>();
                oViewModel.INSTLIST.Add(oViewModel.INST);
            }
            else
            {
                oViewModel.INSTLIST.RemoveAll(fld => fld.INST_TYPEID == oViewModel.INST.INST_TYPEID);
                oViewModel.INSTLIST.Add(oViewModel.INST);
            } //end if

            return oViewModel;
        } //End method
    } //End method
} //End namespace APPBASE.Controllers
