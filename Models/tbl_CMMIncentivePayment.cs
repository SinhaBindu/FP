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
    
    public partial class tbl_CMMIncentivePayment
    {
        public System.Guid CMMIPId_pk { get; set; }
        public Nullable<System.Guid> CMId { get; set; }
        public Nullable<int> DistrictId_fk { get; set; }
        public Nullable<int> BlockId_fk { get; set; }
        public Nullable<int> ClusterId_fk { get; set; }
        public Nullable<int> PanchayatId_fk { get; set; }
        public Nullable<int> VoId_fk { get; set; }
        public Nullable<System.Guid> BFYId_fk { get; set; }
        public Nullable<System.Guid> FollowupId_fk { get; set; }
        public Nullable<int> MIMonth { get; set; }
        public Nullable<int> MIYear { get; set; }
        public Nullable<decimal> ClaimedAmount { get; set; }
        public Nullable<bool> Approved1Status { get; set; }
        public Nullable<System.DateTime> Approved1Date { get; set; }
        public string Approved1Remarks { get; set; }
        public string Approved1By { get; set; }
        public Nullable<bool> Approved2Status { get; set; }
        public Nullable<System.DateTime> Approved2Date { get; set; }
        public string Approved2Remarks { get; set; }
        public string Approved2By { get; set; }
        public Nullable<bool> Approved3Status { get; set; }
        public Nullable<System.DateTime> Approved3Date { get; set; }
        public string Approved3Remarks { get; set; }
        public string Approved3By { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedUpdatedOn { get; set; }
    }
}
