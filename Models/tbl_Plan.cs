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
    
    public partial class tbl_Plan
    {
        public System.Guid PlanID_pk { get; set; }
        public Nullable<int> DistrictId_fk { get; set; }
        public Nullable<int> BlockId_fk { get; set; }
        public Nullable<int> CLFId_fk { get; set; }
        public Nullable<int> PanchayatId_fk { get; set; }
        public Nullable<int> VoId_fk { get; set; }
        public Nullable<int> PlanMonth { get; set; }
        public Nullable<int> PlanYear { get; set; }
        public Nullable<System.DateTime> PlanDt { get; set; }
        public Nullable<System.DateTime> HVDt { get; set; }
        public Nullable<int> IsBFY { get; set; }
        public Nullable<System.DateTime> DOMDt { get; set; }
        public Nullable<System.DateTime> DOMHVDt { get; set; }
        public Nullable<int> SubjectId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> IsCount { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}
