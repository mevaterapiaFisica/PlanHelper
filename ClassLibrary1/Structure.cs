//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Structure
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Structure()
        {
            this.DVHEstimationTrainingSetPlanSetupStructureMappings = new HashSet<DVHEstimationTrainingSetPlanSetupStructureMapping>();
            this.EstimatedDVHs = new HashSet<EstimatedDVH>();
            this.FieldStructures = new HashSet<FieldStructure>();
            this.PlanSetupStructureModelStructures = new HashSet<PlanSetupStructureModelStructure>();
            this.SourcePositions = new HashSet<SourcePosition>();
            this.StructureStructureCodes = new HashSet<StructureStructureCode>();
            this.VolOptStructs = new HashSet<VolOptStruct>();
        }
    
        public long StructureSer { get; set; }
        public long StructureSetSer { get; set; }
        public Nullable<long> PatientVolumeSer { get; set; }
        public long StructureTypeSer { get; set; }
        public string StructureId { get; set; }
        public string StructureName { get; set; }
        public string Comment { get; set; }
        public int ROINumber { get; set; }
        public int ROIObservationNumber { get; set; }
        public string GenerationAlgorithm { get; set; }
        public string GenAlgoComment { get; set; }
        public int DVHLineColor { get; set; }
        public int DVHLineStyle { get; set; }
        public double DVHLineWidth { get; set; }
        public Nullable<int> FirstSlice { get; set; }
        public Nullable<int> LastSlice { get; set; }
        public Nullable<double> MaterialCTValue { get; set; }
        public Nullable<long> MaterialSer { get; set; }
        public string ROIPhysicalProperty { get; set; }
        public string ROIPhysicalPropertyValue { get; set; }
        public Nullable<double> SearchCTHigh { get; set; }
        public Nullable<double> SearchCTLow { get; set; }
        public Nullable<double> EUDAlpha { get; set; }
        public Nullable<double> TCPAlpha { get; set; }
        public Nullable<double> TCPBeta { get; set; }
        public Nullable<double> TCPGamma { get; set; }
        public Nullable<double> ThicknessCm { get; set; }
        public string FileName { get; set; }
        public string Interpreter { get; set; }
        public string ROIObservationId { get; set; }
        public string ROIMaterialId { get; set; }
        public string VolumeCodeDesignator { get; set; }
        public string VolumeCodeVersion { get; set; }
        public string VolumeCodeValue { get; set; }
        public string VolumeCodeMeaning { get; set; }
        public string Status { get; set; }
        public System.DateTime StatusDate { get; set; }
        public string StatusUserName { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
        public int IsVisible { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DVHEstimationTrainingSetPlanSetupStructureMapping> DVHEstimationTrainingSetPlanSetupStructureMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EstimatedDVH> EstimatedDVHs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FieldStructure> FieldStructures { get; set; }
        public virtual Material Material { get; set; }
        public virtual PatientVolume PatientVolume { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanSetupStructureModelStructure> PlanSetupStructureModelStructures { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SourcePosition> SourcePositions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StructureStructureCode> StructureStructureCodes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VolOptStruct> VolOptStructs { get; set; }
        public virtual StructureSet StructureSet { get; set; }
        public virtual StructureType StructureType { get; set; }
    }
}