﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FP.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FP_DBEntities : DbContext
    {
        public FP_DBEntities()
            : base("name=FP_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Block_Master> Block_Master { get; set; }
        public virtual DbSet<District_Master> District_Master { get; set; }
        public virtual DbSet<State_Master> State_Master { get; set; }
        public virtual DbSet<Contraceptive_Child_Master> Contraceptive_Child_Master { get; set; }
        public virtual DbSet<Contraceptive_Master> Contraceptive_Master { get; set; }
        public virtual DbSet<Tbl_ExceptionHandle> Tbl_ExceptionHandle { get; set; }
        public virtual DbSet<Month_Master> Month_Master { get; set; }
        public virtual DbSet<Year_Master> Year_Master { get; set; }
        public virtual DbSet<ModuleRollout_Master> ModuleRollout_Master { get; set; }
        public virtual DbSet<Subject_Master> Subject_Master { get; set; }
        public virtual DbSet<ServiceProvider_Master> ServiceProvider_Master { get; set; }
        public virtual DbSet<tbl_BFYFollowup> tbl_BFYFollowup { get; set; }
        public virtual DbSet<CLF_Master> CLF_Master { get; set; }
        public virtual DbSet<Panchayat_Master> Panchayat_Master { get; set; }
        public virtual DbSet<VO_Master> VO_Master { get; set; }
        public virtual DbSet<tbl_CLF_Emp> tbl_CLF_Emp { get; set; }
        public virtual DbSet<TBL_Emp> TBL_Emp { get; set; }
        public virtual DbSet<tbl_CLFPlanReject> tbl_CLFPlanReject { get; set; }
        public virtual DbSet<tbl_Plan> tbl_Plan { get; set; }
        public virtual DbSet<tbl_Achievement_Log> tbl_Achievement_Log { get; set; }
        public virtual DbSet<tbl_BFYService> tbl_BFYService { get; set; }
        public virtual DbSet<tbl_PaymentHistory> tbl_PaymentHistory { get; set; }
        public virtual DbSet<TBL_Beneficiary> TBL_Beneficiary { get; set; }
        public virtual DbSet<Activities_Master> Activities_Master { get; set; }
        public virtual DbSet<tbl_AchievementPlan> tbl_AchievementPlan { get; set; }
        public virtual DbSet<tbl_CMMIncentivePayment> tbl_CMMIncentivePayment { get; set; }
    }
}
