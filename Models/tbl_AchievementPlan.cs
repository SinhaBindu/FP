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
    
    public partial class tbl_AchievementPlan
    {
        public System.Guid AchieveId_pk { get; set; }
        public Nullable<int> DistrictId_fk { get; set; }
        public Nullable<int> BlockId_fk { get; set; }
        public Nullable<int> ClusterId_fk { get; set; }
        public Nullable<int> PanchayatId_fk { get; set; }
        public Nullable<int> VoId_fk { get; set; }
        public Nullable<int> PlanMonth { get; set; }
        public Nullable<int> PlanYear { get; set; }
        public Nullable<System.DateTime> Meetingheld { get; set; }
        public Nullable<int> Noofparticipant { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> FinalApproved { get; set; }
        public Nullable<System.DateTime> FinalApprovedDate { get; set; }
        public string FinalApprovedBy { get; set; }
        public Nullable<bool> IsLevel1Approve { get; set; }
        public Nullable<System.DateTime> Level1ApproveDt { get; set; }
        public string Level1ApproveBy { get; set; }
        public Nullable<bool> IsLevel2Approve { get; set; }
        public Nullable<System.DateTime> Level2ApproveDt { get; set; }
        public string Level2ApproveBy { get; set; }
        public Nullable<bool> IsLevel1Reject { get; set; }
        public string Level1RejectBy { get; set; }
        public Nullable<System.DateTime> Level1RejectDt { get; set; }
        public string Remark1 { get; set; }
        public Nullable<bool> IsLevel2Reject { get; set; }
        public Nullable<System.DateTime> Level2RejectDt { get; set; }
        public string Level2RejectBy { get; set; }
        public string Remark2 { get; set; }
        public Nullable<bool> IsLevel3Reject { get; set; }
        public Nullable<System.DateTime> Level3RejectDt { get; set; }
        public string Level3RejectBy { get; set; }
        public string Remark3 { get; set; }
    }
}
