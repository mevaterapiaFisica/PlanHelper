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
    
    public partial class ProcedureCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProcedureCode()
        {
            this.ActInstProcCodes = new HashSet<ActInstProcCode>();
            this.ActivityToProcedureCodes = new HashSet<ActivityToProcedureCode>();
            this.BillSysChrgWrks = new HashSet<BillSysChrgWrk>();
            this.ProcedureCodeMHs = new HashSet<ProcedureCodeMH>();
        }
    
        public long ProcedureCodeSer { get; set; }
        public int ProcedureCodeRevCount { get; set; }
        public Nullable<long> ModifierSer { get; set; }
        public Nullable<int> ActivityCodeMdRevCount { get; set; }
        public long ActivityCategorySer { get; set; }
        public string ProcedureCode1 { get; set; }
        public string CodeType { get; set; }
        public string BillingCode { get; set; }
        public Nullable<long> DerivedFromProcedureCodeSer { get; set; }
        public Nullable<int> NoEditFlag { get; set; }
        public string ObjectStatus { get; set; }
        public string UserDefinedCode { get; set; }
        public decimal PrmrProfessCharge { get; set; }
        public decimal PrmrTechCharge { get; set; }
        public decimal PrmrGlblCharge { get; set; }
        public Nullable<double> ProfessionalRVU { get; set; }
        public Nullable<double> TechnicalRVU { get; set; }
        public Nullable<double> GlobalRVU { get; set; }
        public decimal OthrProfessCharge { get; set; }
        public decimal OthrTechCharge { get; set; }
        public decimal OthrGlblCharge { get; set; }
        public int ComplexityCode { get; set; }
        public decimal ActivityCost { get; set; }
        public string Comment { get; set; }
        public string ShortComment { get; set; }
        public Nullable<double> WorkUnit { get; set; }
        public Nullable<decimal> ChargeForecast { get; set; }
        public Nullable<decimal> ActualCharge { get; set; }
        public int ExportableFlag { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
        public Nullable<long> DepartmentSer { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActInstProcCode> ActInstProcCodes { get; set; }
        public virtual ActivityCategory ActivityCategory { get; set; }
        public virtual ActivityCodeMd ActivityCodeMd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityToProcedureCode> ActivityToProcedureCodes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillSysChrgWrk> BillSysChrgWrks { get; set; }
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProcedureCodeMH> ProcedureCodeMHs { get; set; }
    }
}