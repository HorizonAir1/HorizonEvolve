//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Flight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flight()
        {
            this.Bookings = new HashSet<Booking>();
            this.SeatingCharts = new HashSet<SeatingChart>();
        }
    
        public int flight_id { get; set; }
        public System.TimeSpan arrival_time { get; set; }
        public System.DateTime arrival_date { get; set; }
        public System.TimeSpan depart_time { get; set; }
        public System.DateTime depart_date { get; set; }
        public string destination { get; set; }
        public string departure { get; set; }
        public int aircraft_id { get; set; }
    
        public virtual Aircraft Aircraft { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeatingChart> SeatingCharts { get; set; }
    }
}
