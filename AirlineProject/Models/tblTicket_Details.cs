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
    
    public partial class tblTicket_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTicket_Details()
        {
            this.tblSeat_Details = new HashSet<tblSeat_Details>();
        }
    
        public int Receipt_ID { get; set; }
        public Nullable<int> Schedule_ID { get; set; }
        public Nullable<int> User_ID { get; set; }
        public string Trip_type { get; set; }
        public Nullable<int> Other_Receipt_ID { get; set; }
        public Nullable<int> Number_Of_Tickets { get; set; }
        public string Tickets_Status { get; set; }
        public Nullable<double> Total_Amount { get; set; }
    
        public virtual tblFlight_Schedule tblFlight_Schedule { get; set; }
        public virtual tblUser tblUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSeat_Details> tblSeat_Details { get; set; }
    }
}
