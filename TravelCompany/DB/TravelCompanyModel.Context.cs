﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelCompany.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TravelCompanyEntities : DbContext
    {
        public TravelCompanyEntities()
            : base("name=TravelCompanyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<PriceList> PriceLists { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Settlement> Settlements { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<Transport> Transports { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}