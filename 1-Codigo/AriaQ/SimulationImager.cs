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
    
    public partial class SimulationImager
    {
        public long ResourceSer { get; set; }
        public long SimulatorResourceSer { get; set; }
        public string CalibrationAccuracy { get; set; }
        public Nullable<System.DateTime> CalibrationDate { get; set; }
        public Nullable<double> ExposureTime { get; set; }
        public string VideoBoard { get; set; }
        public Nullable<int> NoOfXLines { get; set; }
        public Nullable<int> NoOfYLines { get; set; }
        public double ResolutionX { get; set; }
        public double ResolutionY { get; set; }
    
        public virtual ImagingDevice ImagingDevice { get; set; }
        public virtual Simulator Simulator { get; set; }
    }
}