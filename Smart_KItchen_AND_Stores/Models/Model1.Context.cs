﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Smart_KItchen_AND_Stores.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class SmartKitchenEntities : DbContext
    {
        public SmartKitchenEntities()
            : base("name=SmartKitchenEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // REMOVED the UnintentionalCodeFirstException
            // Configure your User entity
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId)
                .ToTable("Users");

            // If you're using Database First, you can leave this empty or configure as needed
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
