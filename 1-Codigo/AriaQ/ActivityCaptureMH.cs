//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AriaQ
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActivityCaptureMH
    {
        public long ActivityCaptureSer { get; set; }
        public int ActivityCaptureRevCount { get; set; }
        public long ActivityInstanceSer { get; set; }
        public int ActivityInstanceRevCount { get; set; }
        public Nullable<long> AccountBillingCodeSer { get; set; }
        public Nullable<int> AccountBillingCodeRevCount { get; set; }
        public Nullable<long> PatientPayorSer { get; set; }
        public Nullable<int> PatientPayorRevCount { get; set; }
        public Nullable<long> PayorSer { get; set; }
        public Nullable<long> ResourceSer { get; set; }
        public Nullable<long> AttendingOncologistSer { get; set; }
        public Nullable<long> DepartmentSer { get; set; }
        public Nullable<long> CourseSer { get; set; }
        public string LastKnownCourseId { get; set; }
        public int InPatientFlag { get; set; }
        public string PatientStatus { get; set; }
        public string CompletionResetBy { get; set; }
        public string Comment { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual ActivityCapture ActivityCapture { get; set; }
    }
}