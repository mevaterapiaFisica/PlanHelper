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
    
    public partial class BillSysChrgWrk
    {
        public int VarisBillRunSeqId { get; set; }
        public long ActInstProcCodeSer { get; set; }
        public int ActInstProcCodeRevCount { get; set; }
        public string ChargeIndicator { get; set; }
        public string BillSysInstId { get; set; }
        public string BillSysId { get; set; }
        public Nullable<long> PatientSer { get; set; }
        public string PatientLastName { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientMiddleName { get; set; }
        public string PatientId { get; set; }
        public string PatientId2 { get; set; }
        public string PatientAccountNumberId { get; set; }
        public string PatientAddressType { get; set; }
        public string PatientCountry { get; set; }
        public string PatientStateOrProvince { get; set; }
        public string PatientCounty { get; set; }
        public string PatientCityOrTownship { get; set; }
        public string PatientAddressLine1 { get; set; }
        public string PatientAddressLine2 { get; set; }
        public string PatientPostalCode { get; set; }
        public string PhoneNumberHome1 { get; set; }
        public string PhoneNumberHome2 { get; set; }
        public string PhoneNumberHome3 { get; set; }
        public string PhoneNumberBusiness1 { get; set; }
        public string PhoneNumberBusiness2 { get; set; }
        public Nullable<System.DateTime> PatientBirthDate { get; set; }
        public string PatientSSN { get; set; }
        public string PatientRace { get; set; }
        public string PatientMothersMaidenName { get; set; }
        public string PatientSex { get; set; }
        public string PatientStatus { get; set; }
        public string PatientMaritalStatus { get; set; }
        public string PatientLocation { get; set; }
        public Nullable<System.DateTime> PatientDischargeDate { get; set; }
        public Nullable<System.DateTime> PatientAdmissionDate { get; set; }
        public Nullable<long> DepartmentSer { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<long> HospitalSer { get; set; }
        public string HospitalName { get; set; }
        public Nullable<System.DateTime> CompletedDateTime { get; set; }
        public Nullable<System.DateTime> FromDateOfService { get; set; }
        public string CodeType { get; set; }
        public string ActivityType { get; set; }
        public string BillingCode { get; set; }
        public Nullable<int> MedicareComplexCode { get; set; }
        public string ProcedureCode { get; set; }
        public string ModifierCode { get; set; }
        public string UserDefinedCode { get; set; }
        public string ProcedureComment { get; set; }
        public string ProcedureShortComment { get; set; }
        public string ModifierDescription { get; set; }
        public string ModifierCode2 { get; set; }
        public string ModifierDescription2 { get; set; }
        public string ModifierCode3 { get; set; }
        public string ModifierDescription3 { get; set; }
        public string ModifierCode4 { get; set; }
        public string ModifierDescription4 { get; set; }
        public string ModifierCode5 { get; set; }
        public string ModifierDescription5 { get; set; }
        public string ModifierCode6 { get; set; }
        public string ModifierDescription6 { get; set; }
        public string ModifierCode7 { get; set; }
        public string ModifierDescription7 { get; set; }
        public string TSAComment { get; set; }
        public Nullable<int> NoChargeFlag { get; set; }
        public Nullable<int> NumberOfCycles { get; set; }
        public Nullable<decimal> PrmrTechCharge { get; set; }
        public Nullable<decimal> PrmrProfessCharge { get; set; }
        public Nullable<decimal> PrmrGlblCharge { get; set; }
        public Nullable<decimal> OtherGlobalCharge { get; set; }
        public Nullable<decimal> OtherProfessionalCharge { get; set; }
        public Nullable<decimal> OtherTechnicalCharge { get; set; }
        public Nullable<double> TechnicalRVU { get; set; }
        public Nullable<double> ProfessionalRVU { get; set; }
        public Nullable<double> GlobalRVU { get; set; }
        public Nullable<decimal> AverageActivityCost { get; set; }
        public string BillingServiceID { get; set; }
        public Nullable<int> RVUExportCode { get; set; }
        public Nullable<int> RVUExport { get; set; }
        public Nullable<double> RVUMultiplier { get; set; }
        public string ExportType { get; set; }
        public Nullable<int> ExternalBillingCodeExport { get; set; }
        public string ApprovedBy { get; set; }
        public string CompletedBy { get; set; }
        public string DiagnosisCode { get; set; }
        public string DiagnosisDescription { get; set; }
        public string InsuranceCompanyName1 { get; set; }
        public string InsurancePlanType1 { get; set; }
        public string InsurancePlanNumber1 { get; set; }
        public string AuthorizationDescription1 { get; set; }
        public string InsuranceCompanyName2 { get; set; }
        public string InsurancePlanType2 { get; set; }
        public string InsurancePlanNumber2 { get; set; }
        public string AuthorizationDescription2 { get; set; }
        public string InsuranceCompanyName3 { get; set; }
        public string InsurancePlanType3 { get; set; }
        public string InsurancePlanNumber3 { get; set; }
        public string AuthorizationDescription3 { get; set; }
        public string InsuranceCompanyName4 { get; set; }
        public string InsurancePlanType4 { get; set; }
        public string InsurancePlanNumber4 { get; set; }
        public string AuthorizationDescription4 { get; set; }
        public string RadiationOncologistLastName { get; set; }
        public string RadiationOncologistFirstName { get; set; }
        public string RadiationOncologistID { get; set; }
        public string RadiationOncologistSpecialty { get; set; }
        public string ReferringPhysicianLastName { get; set; }
        public string ReferringPhysicianFirstName { get; set; }
        public string ReferringPhysicianID { get; set; }
        public string ReferringPhysicianSpecialty { get; set; }
        public Nullable<long> ActivitySerialNumber { get; set; }
        public Nullable<long> ChargesControlSerialNumber { get; set; }
        public Nullable<long> AccountBillingCodeSer { get; set; }
        public Nullable<int> AccountBillingCodeRevCount { get; set; }
        public Nullable<long> ProcedureCodeSer { get; set; }
        public Nullable<int> ProcedureCodeRevCount { get; set; }
        public Nullable<int> InPatientFlag { get; set; }
        public Nullable<long> ActivityCaptureSer { get; set; }
        public Nullable<int> ActivityCaptureRevCount { get; set; }
        public string TransId { get; set; }
        public string BatchId { get; set; }
        public string FillerRefNo { get; set; }
        public string ExportedBy { get; set; }
    
        public virtual AccountBillingCode AccountBillingCode { get; set; }
        public virtual ActInstProcCode ActInstProcCode { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual ActivityCapture ActivityCapture { get; set; }
        public virtual ChargesControl ChargesControl { get; set; }
        public virtual Department Department { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ProcedureCode ProcedureCode1 { get; set; }
    }
}