//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BykesProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int BookingID { get; set; }
        public string Id { get; set; }
        public int BykeId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Byke Byke { get; set; }
    }
}