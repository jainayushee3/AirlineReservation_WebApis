//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirlineProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblFlight_Schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblFlight_Schedule()
        {
            this.tblSeat_Details = new HashSet<tblSeat_Details>();
            this.tblTicket_Details = new HashSet<tblTicket_Details>();
        }
    
        public int Schedule_ID { get; set; }
        public Nullable<int> Flight_ID { get; set; }
        public string Source_Loc { get; set; }
        public string Destination { get; set; }
        public Nullable<System.DateTime> Dep_Time { get; set; }
        public Nullable<System.DateTime> Arr_Time { get; set; }
        public Nullable<System.DateTime> Duration { get; set; }
        public Nullable<System.DateTime> Dep_Date { get; set; }
        public Nullable<double> Price_FC { get; set; }
        public Nullable<double> Price_BC { get; set; }
        public Nullable<double> Price_EC { get; set; }
        public string status { get; set; }
    
        public virtual tblFlight_Details tblFlight_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSeat_Details> tblSeat_Details { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTicket_Details> tblTicket_Details { get; set; }
    }
}
