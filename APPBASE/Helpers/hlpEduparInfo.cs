using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data;
using System.Data.Entity;
using APPBASE.Helpers;
using APPBASE.Models;

namespace APPBASE.Helpers
{
    public class hlpEduparInfo : IDisposable
    {
        public int? HQBRANCH_ID { get; set; }
        public int? DEFBRANCH_ID { get; set; }
        public int? YEAR_ID { get; set; }
        public Byte? SEMESTER_ID { get; set; }
        public int? CLASSTYPE_ID { get; set; }
        public int? CLASSLEVEL_ID { get; set; }
        public int? CLASSROOM_ID { get; set; }
        private MainconfigDS oDSMainconfig = new MainconfigDS();

        //Constructor 1
        public hlpEduparInfo() { }
        //Constructor 2
        public hlpEduparInfo(DateTime? pdDatetime = null, int? pnClasslevelID = null, int? pnClassroomID = null)
        {
            setProp_Branch();
            if (pdDatetime != null) setProp_YearSemester();
            if (pnClasslevelID != null) setProp_ByClasslevelID(pnClasslevelID);
            if (pnClassroomID != null) setProp_ByClassroomID(pnClassroomID);
        } //End public hlpEduparInfo()

        private void setProp_Branch() {
            MainconfigDS oDSMainconfig = new MainconfigDS();
            BranchallDS oDSBranchall = new BranchallDS();

            this.HQBRANCH_ID = oDSMainconfig.HQBRANCH_ID;
            this.DEFBRANCH_ID = oDSMainconfig.DEFBRANCH_ID;
        } //End private void setProp()
        private void setProp_YearSemester(DateTime? pdDatetime = null)
        {
            YearDS oDSYear = new YearDS();
            SemesterDS oDSSemester = new SemesterDS();

            if (pdDatetime == null)
            {
                this.YEAR_ID = oDSYear.getData_currentYearID();
                this.SEMESTER_ID = oDSSemester.getData_currentSemesterID();
            } //End if (pdDatetime == null)
            else {
                this.YEAR_ID = oDSYear.getData_YearID();
                this.SEMESTER_ID = oDSSemester.getData_SemesterID();
            } //End else (pdDatetime == null)
        } //End private void setProp()
        private void setProp_ByClasslevelID(int? pnClasslevelID)
        {
            ClasslevelDS oDS = new ClasslevelDS();

            this.CLASSLEVEL_ID = pnClasslevelID;
            this.CLASSTYPE_ID = oDS.getData_ClasstypeID(pnClasslevelID);
        } //End private void setProp_ByClasslevelID(int? ClasslevelID)
        private void setProp_ByClassroomID(int? pnClassroomID) {
            this.CLASSROOM_ID = pnClassroomID;
        } //End private void setProp_ByClassroomID(int? ClasslevelID)

        //Disposable
        public void Dispose() { }
    } //End public class EduparInfo
} //End namespace APPBASE.Helper
