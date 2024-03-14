//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class TBL_Beneficiary
    {
        public System.Guid Beneficiary_Id_pk { get; set; }
        public Nullable<int> HindiEng { get; set; }
        public Nullable<int> DistrictId_fk { get; set; }
        public Nullable<int> BlockId_fk { get; set; }
        public Nullable<int> CLFId_fk { get; set; }
        public Nullable<int> PanchayatId_fk { get; set; }
        public Nullable<int> VillageOId_fk { get; set; }
        public Nullable<int> ReportingMonth { get; set; }
        public Nullable<int> ReportingYear { get; set; }
        public string HealthCenter { get; set; }
        public string BFYVillageName { get; set; }
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }
        public Nullable<System.DateTime> BFYDOB { get; set; }
        public Nullable<double> Q4 { get; set; }
        public string Q5 { get; set; }
        public Nullable<int> Q6DOMYear { get; set; }
        public Nullable<System.DateTime> Q6 { get; set; }
        public Nullable<int> Q6_Year { get; set; }
        public string Q7 { get; set; }
        public Nullable<int> Q8 { get; set; }
        public string Q9 { get; set; }
        public Nullable<int> Q10 { get; set; }
        public Nullable<int> Q11 { get; set; }
        public string Q12_1 { get; set; }
        public Nullable<System.DateTime> YoungestDOB { get; set; }
        public Nullable<double> Q12 { get; set; }
        public string Q13 { get; set; }
        public string Q14 { get; set; }
        public Nullable<int> Q15 { get; set; }
        public Nullable<int> Q16 { get; set; }
        public Nullable<int> Q17 { get; set; }
        public string Q18 { get; set; }
        public Nullable<int> Q19 { get; set; }
        public Nullable<int> Q20 { get; set; }
        public Nullable<int> Q21 { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}
