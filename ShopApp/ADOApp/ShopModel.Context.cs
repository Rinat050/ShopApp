﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopApp.ADOApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShopDBEntities : DbContext
    {
        public ShopDBEntities()
            : base("name=ShopDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Order_Items> Order_Items { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Recept_Items> Recept_Items { get; set; }
        public virtual DbSet<Recepts> Recepts { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Meals> Meals { get; set; }
    }
}
