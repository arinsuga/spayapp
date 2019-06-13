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
using Omu.ValueInjecter;

namespace APPBASE.Models
{
    public partial class Transaction_inCRUD
    {
        public void Init(Transaction_indetailVM poViewModel)
        {
            //Get Mainconfig
            oDSMainconfig = new MainconfigDS();
            //Set private viewmodel
            this.oViewModel = poViewModel;

            //Set Main data
            this.Init_base();
            //Set Transaction data
            this.Init_Transaction();
        } //End public void Init
        public void Init_base()
        {
            this.oViewModel.BRANCH_ID = oDSMainconfig.DEFBRANCH_ID;
            this.oViewModel.YEAR_ID = oDSMainconfig.YEAR_ID;
            this.oViewModel.SEMESTER_ID = oDSMainconfig.SEMESTER_ID;

            this.oViewModel.CACHE_YEAR_CODE = oDSMainconfig.CACHE_YEAR_CODE;
            this.oViewModel.CACHE_YEAR_SHORTDESC = oDSMainconfig.CACHE_YEAR_SHORTDESC;
            this.oViewModel.CACHE_YEAR_DESC = oDSMainconfig.CACHE_YEAR_DESC;
            this.oViewModel.CACHE_YEAR_FROM = oDSMainconfig.CACHE_YEAR_FROM;
            this.oViewModel.CACHE_YEAR_TO = oDSMainconfig.CACHE_YEAR_TO;

        } //End public void Init_base
        public void Init_Transaction()
        {
            //Student Info
            this.oViewModel.CLASSTYPE_ID = this.oViewModel.STUDENT_CLASSTYPE_ID;
            this.oViewModel.CLASSLEVEL_ID = this.oViewModel.STUDENT_CLASSLEVEL_ID;
            this.oViewModel.CLASSROOM_ID = this.oViewModel.STUDENT_CLASSROOM_ID;
            //this.oViewModel.CLASSMAJOR_ID = this.oViewModel.STUDENT_CLASSMAJOR_ID;

            //Transaction Amount
            if (this.oViewModel.TRN_DT==null)
            this.oViewModel.TRN_DT = oDSMainconfig.TRN_DT;
            
            this.oViewModel.TRN_STS = 1;
            this.oViewModel.TRN_AMOUNT = 0;
            //Loop Detail Transaction
            foreach (var item in oViewModel.DETAIL)
            {
                //Set TRN_ID
                item.TRN_ID = oViewModel.ID;
                //Calculate Transaction
                if (item.TRND_AMOUNT != null)
                    this.oViewModel.TRN_AMOUNT = this.oViewModel.TRN_AMOUNT + item.TRND_AMOUNT;
            } //End foreach (var item in oViewModel.DETAIL)
            this.oViewModel.TRN_TERBILANG = "";
            //Transaction RECEAPT_NO
            using (var oCRUDmainconfig = new MainconfigCRUD()) {
                oCRUDmainconfig.Rollup_RECEIPTNO();
                this.oViewModel.RECEIPT_NO = oCRUDmainconfig.RECEIPT_NO;
            } //End using (var oCRUDmainconfig = new MainconfigCRUD())
        } //End public void Init_Transaction
        
        public void SaveNEW(Transaction_indetailVM poViewModel)
        {
            //Action Flag
            this.FIELD_HEADER = hlpFlags_CRUDOption.CREATE;
            this.DTA_STS = valFLAG.FLAG_DTA_STS_CREATE;
            //Initial data
            this.Init(poViewModel);
            //Save table Transaction_in
            this.SaveNEW_create(this.oViewModel);
        } //End public void SaveNEW
        public void SaveEDIT(Transaction_indetailVM poViewModel)
        {
            //Action Flag
            this.FIELD_HEADER = hlpFlags_CRUDOption.UPDATE;
            this.DTA_STS = valFLAG.FLAG_DTA_STS_UPDATE; ;
            //Initial data
            this.Init(poViewModel);
            //Save table Transaction_in
            //this.Create_bulk(this.oViewModel);
        } //End public void SaveNEW
        public void SaveDELETE(Transaction_indetailVM poViewModel)
        {
            //Action Flag
            this.FIELD_HEADER = hlpFlags_CRUDOption.DELETE;
            this.DTA_STS = valFLAG.FLAG_DTA_STS_DELETE; ;
            //Initial data
            this.Init(poViewModel);
            //Save table Transaction_in
            //this.Create_bulk(this.oViewModel);
        } //End public void SaveNEW

        public void SaveNEW_create(Transaction_indetailVM poViewModel)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    //TRN
                    Transaction_in oModelTRN = new Transaction_in();
                    //Map Form Data
                    oModelTRN.InjectFrom(poViewModel);
                    //Set Field Header
                    oModelTRN.setFIELD_HEADER(this.FIELD_HEADER);
                    //Set DTA_STS
                    oModelTRN.DTA_STS = this.DTA_STS;
                    //Process CRUD
                    db.Transaction_ins.Add(oModelTRN);
                    //Update database
                    db.SaveChanges();
                    this.ID = oModelTRN.ID;
                    this.TRN_DT = oModelTRN.TRN_DT;

                    //INST
                    Installment_in oModelINST = null;
                    List<Installment_in> LIST_INST = new List<Installment_in>();
                    Installment_in DETAIL_INST = null;

                    //INST - SPP
                    if (poViewModel.MONTHLY_INST_SPP != null) {
                        poViewModel.MONTHLY_INST = poViewModel.MONTHLY_INST_SPP;
                        //Create
                        if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
                        {
                            oModelINST = new Installment_in();
                            //Map Form Data
                            oModelINST.InjectFrom(poViewModel.MONTHLY_INST);
                            //Set Field Header
                            oModelINST.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                            //Set DTA_STS : Set in METHOD controller
                            //oModelINST.DTA_STS = this.DTA_STS;
                            //Set TRN_DT
                            oModelINST.INST_DT = this.TRN_DT;
                            //Process CRUD
                            db.Installment_ins.Add(oModelINST);
                        } //End if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
                        //Update
                        if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
                        {
                            oModelINST = db.Installment_ins.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.MONTHLY_INST.ID);
                            //Map Form Data
                            oModelINST.InjectFrom(poViewModel.MONTHLY_INST);
                            //Set Field Header
                            oModelINST.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                            //Set DTA_STS : Set in METHOD controller
                            //oModelINST.DTA_STS = this.DTA_STS;
                            //Process CRUD
                            db.Entry(oModelINST).State = EntityState.Modified;
                        } //End if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
                        //Update database-SPP
                        db.SaveChanges();
                        DETAIL_INST = new Installment_in();
                        DETAIL_INST.ID = oModelINST.ID;
                        DETAIL_INST.INST_TYPEID = oModelINST.INST_TYPEID;
                        LIST_INST.Add(DETAIL_INST);
                    } //End if (poViewModel.MONTHLY_INST_SPP != null)

                    //INST - EKSKUL
                    if (poViewModel.MONTHLY_INST_EKSKUL != null) {
                        poViewModel.MONTHLY_INST = poViewModel.MONTHLY_INST_EKSKUL;
                        //Create
                        if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
                        {
                            oModelINST = new Installment_in();
                            //Map Form Data
                            oModelINST.InjectFrom(poViewModel.MONTHLY_INST);
                            //Set Field Header
                            oModelINST.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                            //Set DTA_STS : Set in METHOD controller
                            //oModelINST.DTA_STS = this.DTA_STS;
                            //Set TRN_DT
                            oModelINST.INST_DT = this.TRN_DT;
                            //Process CRUD
                            db.Installment_ins.Add(oModelINST);
                        } //End if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
                        //Update
                        if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
                        {
                            oModelINST = db.Installment_ins.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.MONTHLY_INST.ID);
                            //Map Form Data
                            oModelINST.InjectFrom(poViewModel.MONTHLY_INST);
                            //Set Field Header
                            oModelINST.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                            //Set DTA_STS : Set in METHOD controller
                            //oModelINST.DTA_STS = this.DTA_STS;
                            //Process CRUD
                            db.Entry(oModelINST).State = EntityState.Modified;
                        } //End if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
                        //Update database-EKSKUL
                        db.SaveChanges();
                        DETAIL_INST = new Installment_in();
                        DETAIL_INST.ID = oModelINST.ID;
                        DETAIL_INST.INST_TYPEID = oModelINST.INST_TYPEID;
                        LIST_INST.Add(DETAIL_INST);
                    } //End if (poViewModel.MONTHLY_INST_EKSKUL != null)

                    //INST - SCLUB
                    if (poViewModel.MONTHLY_INST_SCLUB != null) {
                        poViewModel.MONTHLY_INST = poViewModel.MONTHLY_INST_SCLUB;
                        //Create
                        if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
                        {
                            oModelINST = new Installment_in();
                            //Map Form Data
                            oModelINST.InjectFrom(poViewModel.MONTHLY_INST);
                            //Set Field Header
                            oModelINST.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                            //Set DTA_STS : Set in METHOD controller
                            //oModelINST.DTA_STS = this.DTA_STS;
                            //Set TRN_DT
                            oModelINST.INST_DT = this.TRN_DT;
                            //Process CRUD
                            db.Installment_ins.Add(oModelINST);
                        } //End if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
                        //Update
                        if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
                        {
                            oModelINST = db.Installment_ins.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.MONTHLY_INST.ID);
                            //Map Form Data
                            oModelINST.InjectFrom(poViewModel.MONTHLY_INST);
                            //Set Field Header
                            oModelINST.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                            //Set DTA_STS : Set in METHOD controller
                            //oModelINST.DTA_STS = this.DTA_STS;
                            //Process CRUD
                            db.Entry(oModelINST).State = EntityState.Modified;
                        } //End if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
                        //Update database-SCLUB
                        db.SaveChanges();
                        DETAIL_INST = new Installment_in();
                        DETAIL_INST.ID = oModelINST.ID;
                        DETAIL_INST.INST_TYPEID = oModelINST.INST_TYPEID;
                        LIST_INST.Add(DETAIL_INST);
                    } //End if (poViewModel.MONTHLY_INST_SCLUB != null)

                    //INST - RANDOM
                    if (oViewModel.INSTLIST != null) {
                        foreach (var item in oViewModel.INSTLIST)
                        {
                            poViewModel.INST = item;
                            //Create
                            if (poViewModel.INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
                            {
                                oModelINST = new Installment_in();
                                //Map Form Data
                                oModelINST.InjectFrom(poViewModel.INST);
                                //Set Field Header
                                oModelINST.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                                //Set DTA_STS : Set in METHOD controller
                                //oModelINST.DTA_STS = this.DTA_STS;
                                //Set TRN_DT
                                oModelINST.INST_DT = this.TRN_DT;
                                //Process CRUD
                                db.Installment_ins.Add(oModelINST);
                            } //End if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
                            //Update
                            if (poViewModel.INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
                            {
                                oModelINST = db.Installment_ins.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.INST.ID);
                                //Map Form Data
                                oModelINST.InjectFrom(poViewModel.INST);
                                //Set Field Header
                                oModelINST.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                                //Set DTA_STS : Set in METHOD controller
                                //oModelINST.DTA_STS = this.DTA_STS;
                                //Process CRUD
                                db.Entry(oModelINST).State = EntityState.Modified;
                            } //End if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
                            
                            //Save data
                            db.SaveChanges();
                            DETAIL_INST = new Installment_in();
                            DETAIL_INST.ID = oModelINST.ID;
                            DETAIL_INST.INST_TYPEID = oModelINST.INST_TYPEID;
                            LIST_INST.Add(DETAIL_INST);
                        } //End foreach (var item in oViewModel.INSTLIST)
                    } //End if (oViewModel.INSTLIST != null)

                    //TRNDetail
                    Transaction_ind oModelTRN_detail = null;
                    foreach (var item in poViewModel.DETAIL)
                    {
                        oModelTRN_detail = new Transaction_ind();
                        item.TRN_ID = this.ID;
                        //item.INST_ID = this.INST_ID;
                        if (LIST_INST.Count > 0) {
                            var oData_INST = LIST_INST.Where(fld => fld.INST_TYPEID == item.TRINTYPE_ID).SingleOrDefault();
                            if (oData_INST!=null)
                                item.INST_ID = oData_INST.ID;
                        } //End if (LIST_INST.Count > 0)
                        

                        //Map Form Data
                        oModelTRN_detail.InjectFrom(item);
                        //Set Field Header
                        oModelTRN_detail.setFIELD_HEADER(this.FIELD_HEADER);
                        //Set DTA_STS
                        oModelTRN_detail.DTA_STS = this.DTA_STS;

                        //Process CRUD
                        db.Transaction_inds.Add(oModelTRN_detail);
                    } //End foreach (var item in poViewModel.DETAIL)
                    //Update database
                    db.SaveChanges();
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create_bulk

        private DBMAINContext setINST_NOTYETUSE(DBMAINContext poDB, Transaction_indetailVM poViewModel, Installment_in poModelINST)
        {
            DBMAINContext vReturn = poDB;
            DBMAINContext oDBMAINContext = poDB;

            using (var db = oDBMAINContext) {
                //INST - SPP
                Installment_in oModelINST = null;
                //Create
                if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
                {
                    oModelINST = new Installment_in();
                    //Map Form Data
                    oModelINST.InjectFrom(poViewModel.MONTHLY_INST);
                    //Set Field Header
                    oModelINST.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Set DTA_STS : Set in METHOD controller
                    //oModelINST.DTA_STS = this.DTA_STS;
                    //Set TRN_DT
                    oModelINST.INST_DT = this.TRN_DT;
                    //Process CRUD
                    db.Installment_ins.Add(oModelINST);
                } //End if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
                //Update
                if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
                {
                    oModelINST = db.Installment_ins.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.ID);
                    //Map Form Data
                    oModelINST.InjectFrom(poViewModel.MONTHLY_INST);
                    //Set Field Header
                    oModelINST.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Set DTA_STS : Set in METHOD controller
                    //oModelINST.DTA_STS = this.DTA_STS;
                    //Process CRUD
                    db.Entry(oModelINST).State = EntityState.Modified;
                } //End if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)

                vReturn = db;
            } //End using (var db = poDB)

            return vReturn;
        } //End private Installment_in setINST(Installment_in oModelINST)

        public void SaveNEW_create_BACKUP(Transaction_indetailVM poViewModel)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    //TRN
                    Transaction_in oModelTRN = new Transaction_in();
                    //Map Form Data
                    oModelTRN.InjectFrom(poViewModel);
                    //Set Field Header
                    oModelTRN.setFIELD_HEADER(this.FIELD_HEADER);
                    //Set DTA_STS
                    oModelTRN.DTA_STS = this.DTA_STS;
                    //Process CRUD
                    db.Transaction_ins.Add(oModelTRN);
                    //Update database
                    db.SaveChanges();
                    this.ID = oModelTRN.ID;
                    this.TRN_DT = oModelTRN.TRN_DT;

                    //INST - SPP
                    Installment_in oModelINST = null;
                    //Create
                    if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
                    {
                        oModelINST = new Installment_in();
                        //Map Form Data
                        oModelINST.InjectFrom(poViewModel.MONTHLY_INST);
                        //Set Field Header
                        oModelINST.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                        //Set DTA_STS : Set in METHOD controller
                        //oModelINST.DTA_STS = this.DTA_STS;
                        //Set TRN_DT
                        oModelINST.INST_DT = this.TRN_DT;
                        //Process CRUD
                        db.Installment_ins.Add(oModelINST);
                    } //End if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_CREATE)
                    //Update
                    if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)
                    {
                        oModelINST = db.Installment_ins.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.ID);
                        //Map Form Data
                        oModelINST.InjectFrom(poViewModel.MONTHLY_INST);
                        //Set Field Header
                        oModelINST.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                        //Set DTA_STS : Set in METHOD controller
                        //oModelINST.DTA_STS = this.DTA_STS;
                        //Process CRUD
                        db.Entry(oModelINST).State = EntityState.Modified;
                    } //End if (poViewModel.MONTHLY_INST.DTA_STS == valFLAG.FLAG_DTA_STS_UPDATE)

                    //Update database
                    db.SaveChanges();
                    this.INST_ID = oModelINST.ID;

                    //TRNDetail
                    Transaction_ind oModelTRN_detail = null;
                    foreach (var item in poViewModel.DETAIL)
                    {
                        oModelTRN_detail = new Transaction_ind();
                        item.TRN_ID = this.ID;
                        item.INST_ID = this.INST_ID;
                        //Map Form Data
                        oModelTRN_detail.InjectFrom(item);
                        //Set Field Header
                        oModelTRN_detail.setFIELD_HEADER(this.FIELD_HEADER);
                        //Set DTA_STS
                        oModelTRN_detail.DTA_STS = this.DTA_STS;

                        //Process CRUD
                        db.Transaction_inds.Add(oModelTRN_detail);
                    } //End foreach (var item in poViewModel.DETAIL)
                    //Update database
                    db.SaveChanges();
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create_bulk
    } //End public partial class Transaction_inCRUD
} //End namespace APPBASE.Models
