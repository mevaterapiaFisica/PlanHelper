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
    
    public partial class TreatmentPhase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TreatmentPhase()
        {
            this.Prescriptions = new HashSet<Prescription>();
            this.TreatmentPhase1 = new HashSet<TreatmentPhase>();
        }
    
        public long TreatmentPhaseSer { get; set; }
        public long CourseSer { get; set; }
        public Nullable<long> RelTreatmentPhaseSer { get; set; }
        public string TimeGapType { get; set; }
        public Nullable<int> PhaseGapNumberOfDays { get; set; }
        public string OtherInfo { get; set; }
        public string HstryUserName { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual Course Course { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TreatmentPhase> TreatmentPhase1 { get; set; }
        public virtual TreatmentPhase TreatmentPhase2 { get; set; }
    }
}