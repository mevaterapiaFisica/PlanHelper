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
    
    public partial class PatientDirective
    {
        public long PatientDirectiveSer { get; set; }
        public long PatientSer { get; set; }
        public long DirectiveSer { get; set; }
        public string Comment { get; set; }
        public int ActiveFlag { get; set; }
        public int ValidEntryFlag { get; set; }
        public string ErrorReason { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual Directive Directive { get; set; }
        public virtual Patient Patient { get; set; }
    }
}