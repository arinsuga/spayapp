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
    public class YearCRUD
    {
        public int? ID { get; set; }
        public Boolean isERR { get; set; }
        public string ERRMSG { get; set; }

        //Constructor
        public YearCRUD() { } //End public YearCRUD()
        public void Create(YeardetailVM poViewModel)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    Year oModel = new Year();
                    //Map Form Data
                    oModel.InjectFrom(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_DTA_STS_CREATE;
                    //Process CRUD
                    db.Years.Add(oModel);
                    db.SaveChanges();
                    this.ID = oModel.ID;
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create
        public void Update(YeardetailVM poViewModel)
        {
            try
            {
                using (var db = new DBMAINContext())
                {
                    Year oModel = db.Years.AsNoTracking().SingleOrDefault(fld => fld.ID == poViewModel.ID);
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
                    Year oModel = db.Years.Find(id);
                    db.Years.Remove(oModel);
                    db.SaveChanges();
                    this.ID = oModel.ID;
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Delete" + e.Message; } //End catch
        } //End public void Delete

        public void Create()
        {
            SysinfodetailVM oViewModel = new SysinfoDS().getData();
            try
            {
                using (var db = new DBMAINContext())
                {
                    int nYEAR = oViewModel.SYSDATE.Value.Year;
                    int nMONTH = oViewModel.SYSDATE.Value.Month;
                    int nYEAR_FROM = 0;
                    int nYEAR_TO = 0;
                    //1 Juli - 31 Desember (Semester 1)
                    if ((nMONTH >= 7) && (nMONTH <= 12)) {
                        nYEAR_FROM = nYEAR;
                        nYEAR_TO = nYEAR + 1;
                    } //End if ((nMONTH >= 7) && (nMONTH <= 12))
                    //1 Januari - 30 Juni (Semester 2)
                    if ((nMONTH >= 1) && (nMONTH <= 6)) {
                        nYEAR_FROM = nYEAR-1;
                        nYEAR_TO = nYEAR;
                    } //End if ((nMONTH >= 1) && (nMONTH <= 6))
                    string sYEAR_CODE = nYEAR_FROM.ToString() + " - " + nYEAR_TO.ToString();
                    DateTime? oDatefrom = hlpConvertionAndFormating.ConvertStringToDateShort("01/07/" + nYEAR_FROM.ToString());
                    DateTime? oDateto = hlpConvertionAndFormating.ConvertStringToDateShort("30/06/" + nYEAR_TO.ToString());


                    /*----------------------------------------------------------------------*/
                    YearDS oDS = new YearDS();
                    YeardetailVM oData = oDS.getData_byPeriod(oDatefrom, oDateto);
                    if (oData == null) {
                        Year oModel = new Year();
                        //Set Field Header
                        oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                        //Set DTA_STS
                        oModel.DTA_STS = valFLAG.FLAG_DTA_STS_CREATE;
                        oModel.YEAR_CODE = sYEAR_CODE;
                        oModel.YEAR_SHORTDESC = sYEAR_CODE;
                        oModel.YEAR_DESC = sYEAR_CODE;
                        oModel.YEAR_FROM = oDatefrom;
                        oModel.YEAR_TO = oDateto;

                        //Process CRUD
                        db.Years.Add(oModel);
                        db.SaveChanges();
                        this.ID = oModel.ID;
                    } //End if (oData != null)
                } //End using
            } //End try
            catch (Exception e) { isERR = true; this.ERRMSG = "CRUD - Create: " + e.Message; } //End catch
        } //End public void Create
    } //End public class YearCRUD
} //End namespace APPBASE.Models

