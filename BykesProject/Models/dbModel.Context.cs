﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BykeRentalEntities : DbContext
    {
        public BykeRentalEntities()
            : base("name=BykeRentalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Byke> Bykes { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<UserTyppe> UserTyppes { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<vwBooking> vwBookings { get; set; }
        public virtual DbSet<vwByke> vwBykes { get; set; }
    }
}
