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
        //GET
        private Installment_indetailVM getINST_RANDOM(Transaction_indetailVM poViewModel)
        {
            //Installment_indetailVM vReturn = oDSInstallment.getData(poViewModel.STUDENT_ID, poViewModel.TRINTYPE_ID, poViewModel.CACHE_YEAR_FROM, poViewModel.CACHE_YEAR_TO);
            Installment_indetailVM vReturn = oDSInstallment.getData(poViewModel.STUDENT_ID, poViewModel.TRINTYPE_ID, poViewModel.YEAR_FROM, poViewModel.YEAR_TO);
            if (vReturn == null)
            {
                vReturn = new Installment_indetailVM();
                vReturn.DTA_STS = valFLAG.FLAG_DTA_STS_CREATE;
                vReturn.INST_TYPEID = (Byte?)poViewModel.TRINTYPE_ID;
                vReturn.INST_QTYBASE = 0;
            }
            else  { vReturn.DTA_STS = valFLAG.FLAG_DTA_STS_UPDATE; }

            if (vReturn.INST_QTY == null) { vReturn.INST_QTY = 0; }
            if (vReturn.INST_AMOUNT == null) { vReturn.INST_AMOUNT = 0; }

            //if (vReturn.INST_QTYBASE == null) { vReturn.INST_QTYBASE = 0; }
            if (vReturn.INST_AMOUNTBASE == null) { vReturn.INST_AMOUNTBASE = poViewModel.TRND_AMOUNTBASE; }

            //vReturn.INST_QTY_OUTSTANDING = vReturn.INST_QTYBASE - vReturn.INST_QTY;
            vReturn.INST_AMOUNT_OUTSTANDING = vReturn.INST_AMOUNTBASE - vReturn.INST_AMOUNT;

            return vReturn;
        } //End private Installment_indetailVM getINST_RANDOM(Transaction_indetailVM poViewModel)
        private Transaction_inddetailVM getItem_RANDOM(Transaction_indetailVM poViewModel)
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
            vReturn.TRND_PRICE = oViewModel.TRND_AMOUNT;
            vReturn.TRND_AMOUNT = oViewModel.TRND_AMOUNT;
            vReturn.TRND_PRICEBASE = oViewModel.TRND_AMOUNT;
            vReturn.TRND_QTYBASE = 1;
            vReturn.TRND_AMOUNTBASE = oViewModel.TRND_AMOUNT;
            vReturn.INSTD_SEQNO = (int?)oViewModel.INST.INST_QTY;

            if (vReturn.INST_AMOUNT < vReturn.INST_AMOUNTBASE)
                vReturn.TRND_DESC = "Cicilan " + oViewModel.TRINTYPE_SHORTDESC + " ke " +
                                    oViewModel.INST.INST_QTY.ToString() + " " +
                                    oViewModel.YEAR_SHORTDESC;
            else
                vReturn.TRND_DESC = "Pelunasan " + oViewModel.TRINTYPE_SHORTDESC +
                                    oViewModel.YEAR_SHORTDESC;

            return vReturn;
        } //End private Transaction_inddetailVM getItem_RANDOM(MonthsppVM poMonthitem, Transaction_indetailVM poViewModel)



        private Installment_indetailVM getINST_RANDOM_BACKUP(Transaction_indetailVM poViewModel)
        {
            Installment_indetailVM vReturn = oDSInstallment.getData(poViewModel.STUDENT_ID, poViewModel.TRINTYPE_ID, poViewModel.CACHE_YEAR_FROM, poViewModel.CACHE_YEAR_TO);
            if (vReturn == null)
            {
                vReturn = new Installment_indetailVM();
                vReturn.DTA_STS = valFLAG.FLAG_DTA_STS_CREATE;
                vReturn.INST_QTYBASE = 0;
            }
            else
            {
                vReturn.DTA_STS = valFLAG.FLAG_DTA_STS_UPDATE;
                vReturn.INST_QTYBASE = vReturn.INST_QTYBASE + 1;
            }

            if (vReturn.INST_QTY == null) { vReturn.INST_QTY = 1; }
            else vReturn.INST_QTY = vReturn.INST_QTY + 1;
            return vReturn;
        } //End private Installment_indetailVM getINST_RANDOM_BACKUP(Transaction_indetailVM poViewModel)
    } //End public partial class Transaction_inController : Controller
} //End namespace APPBASE.Controllers
