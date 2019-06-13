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
        public int? ID { get; set; }
        public int? INST_ID { get; set; }
        public DateTime? TRN_DT { get; set; }
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }
        
        private Transaction_indetailVM oViewModel= new Transaction_indetailVM();
        private MainconfigDS oDSMainconfig = null;

        //Action Flag
        private Byte? DTA_STS { get; set; }
        private int? FIELD_HEADER { get; set; }
        //Table Model
        private Installment_in oModelINST = new Installment_in();
        private Installment_ind oModelINST_detail = new Installment_ind();

        //Constructor
        public Transaction_inCRUD() { } //End public Transaction_inCRUD()
        public void Create(Transaction_indetailVM poViewModel)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    Transaction_in oModel = new Transaction_in();
                    //Map Form Data
                    oModel.InjectFrom(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_DTA_STS_CREATE;
                    //Process CRUD
                    db.Transaction_ins.Add(oModel);
                    db.SaveChanges();
                    this.ID = oModel.ID;
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create
        public void Update(Transaction_indetailVM poViewModel)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    Transaction_in oModel = db.Transaction_ins.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.ID);
                    //Map Form Data
                    oModel.InjectFrom(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_DTA_STS_UPDATE;
                    //Process CRUD
                    db.Entry(oModel).State = EntityState.Modified;
                    db.SaveChanges();
                    this.ID = oModel.ID;
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Update" + e.Message; } //End catch
        } //End public void Update
        public void Delete(int? id)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    Transaction_in oModel = db.Transaction_ins.Find(id);
                    db.Transaction_ins.Remove(oModel);
                    db.SaveChanges();
                    this.ID = oModel.ID;
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Delete" + e.Message; } //End catch
        } //End public void Delete
    } //End public class Transaction_inCRUD
} //End namespace APPBASE.Models
