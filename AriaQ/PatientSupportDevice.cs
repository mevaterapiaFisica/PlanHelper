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
    
    public partial class PatientSupportDevice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PatientSupportDevice()
        {
            this.PlanSetups = new HashSet<PlanSetup>();
        }
    
        public long ResourceSer { get; set; }
        public string PatSupportType { get; set; }
        public string PatientSupportDeviceId { get; set; }
        public string PatientSupportDeviceName { get; set; }
        public string AccessoryCode { get; set; }
    
        public virtual Machine Machine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanSetup> PlanSetups { get; set; }
    }
}