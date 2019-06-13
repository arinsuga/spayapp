using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using APPBASE.Helpers;
using APPBASE.Models;

namespace APPBASE.Models
{
    #region Default Context Area
        public partial class DBMAINContext : DbContext
        {
            //CFG - Mainconfig
            public DbSet<Mainconfig> Mainconfigs { get; set; }
            public DbSet<Mainconfig_info> Mainconfig_infos { get; set; }
            //CFG - Year
            public DbSet<Year> Years { get; set; }
            //CFG - Semester
            public DbSet<Semester> Semesters { get; set; }
            //CFG - Classtype
            public DbSet<Classtype> Classtypes { get; set; }
            //Classlevel
            public DbSet<Classlevel> Classlevels { get; set; }
            public DbSet<Classlevel_info> Classlevel_infos { get; set; }
            //CFG - Classroom
            public DbSet<Classroom> Classrooms { get; set; }
            public DbSet<Classroom_info> Classroom_infos { get; set; }
            //Classmajor
            public DbSet<Classmajor> Classmajors { get; set; }
            public DbSet<Classmajor_info> Classmajor_infos { get; set; }
            //Monthspp
            public DbSet<Monthspp> Monthspps { get; set; }

            //CFG - Branch
            public DbSet<Branch> Branchs { get; set; }
            public DbSet<Branch_info> Branch_infos { get; set; }
            public DbSet<BranchHQ_info> BranchHQ_infos { get; set; }
            public DbSet<Branchall_info> Branchall_infos { get; set; }
            //CFG - Aboutus
            public DbSet<Aboutus> Aboutuss { get; set; }

            //Trintype
            public DbSet<Trintype> Trintypes { get; set; }


            //LOV - Bloodtype
            public DbSet<Bloodtype> Bloodtypes { get; set; }
            //LOV - Education
            public DbSet<Education> Educations { get; set; }
            //LOV - Gender
            public DbSet<Gender> Genders { get; set; }
            //LOV - Jobtype
            public DbSet<Jobtype> Jobtypes { get; set; }
            //LOV - Religion
            public DbSet<Religion> Religions { get; set; }
            //LOV - Marital
            public DbSet<Marital> Maritals { get; set; }
            //LOV - Emplsts
            public DbSet<Emplsts> Emplstss { get; set; }
            //LOV - Jobtitle
            public DbSet<Jobtitle> Jobtitles { get; set; }
            //LOV - Incometype
            public DbSet<Incometype> Incometypes { get; set; }
            //City
            public DbSet<City> Citys { get; set; }
            //Studentsts
            public DbSet<Studentsts> Studentstss { get; set; }
            //Empmutationsts
            public DbSet<Empmutationsts> Empmutationstss { get; set; }
            //Attendance
            public DbSet<Attendance> Attendances { get; set; }
            
            //Student
            public DbSet<Student> Students { get; set; }
            public DbSet<Student_info> Student_infos { get; set; }
            //Employee
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Employee_info> Employee_infos { get; set; }

            //Receipt
            public DbSet<Receipt> Receipts { get; set; }

            //Transaction_in
            public DbSet<Transaction_in> Transaction_ins { get; set; }
            public DbSet<Transaction_in_info> Transaction_in_infos { get; set; }
            //Transaction_ind
            public DbSet<Transaction_ind> Transaction_inds { get; set; }
            public DbSet<Transaction_ind_info> Transaction_ind_infos { get; set; }
            //Reportin_in
            public DbSet<Reportin_in_info> Reportin_in_infos { get; set; }

            //Installment_in
            public DbSet<Installment_in> Installment_ins { get; set; }
            public DbSet<Installment_in_info> Installment_in_infos { get; set; }
            //Installment_ind
            public DbSet<Installment_ind> Installment_inds { get; set; }
            public DbSet<Installment_ind_info> Installment_ind_infos { get; set; }

        } //End public class DBMAINContext : DbContext
    #endregion
} //End namespace APPBASE.Models