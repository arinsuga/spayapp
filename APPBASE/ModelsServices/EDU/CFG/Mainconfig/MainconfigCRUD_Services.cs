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
    public class MainconfigCRUD:IDisposable
    {
        public int? ID { get; set; }
        public int? RECEIPT_NO { get; set; }

        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }

        //Constructor
        public MainconfigCRUD() { } //End public MainconfigCRUD()
        //Disposle
        public void Dispose() { }  
        //METHODS
        public void Create(MainconfigdetailVM poViewModel)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    Mainconfig oModel = new Mainconfig();
                    //Map Form Data
                    oModel.InjectFrom(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_DTA_STS_CREATE;
                    //Process CRUD
                    db.Mainconfigs.Add(oModel);
                    db.SaveChanges();
                    this.ID = oModel.ID;
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create
        public void Update(MainconfigdetailVM poViewModel)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    Mainconfig oModel = db.Mainconfigs.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.ID);
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
                    Mainconfig oModel = db.Mainconfigs.Find(id);
                    db.Mainconfigs.Remove(oModel);
                    db.SaveChanges();
                    this.ID = oModel.ID;
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Delete" + e.Message; } //End catch
        } //End public void Delete
        public void Rollup_RECEIPTNO()
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    Mainconfig oModel = db.Mainconfigs.AsNoTracking().FirstOrDefault();
                    if (oModel.RECEIPT_NO == null) oModel.RECEIPT_NO = 1;
                    else oModel.RECEIPT_NO = oModel.RECEIPT_NO + 1;
                    //Process CRUD
                    db.Entry(oModel).State = EntityState.Modified;
                    db.SaveChanges();
                    this.ID = oModel.ID;
                    this.RECEIPT_NO = oModel.RECEIPT_NO;
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Update" + e.Message; } //End catch
        } //End public void Update
    } //End public class MainconfigCRUD
} //End namespace APPBASE.Models
