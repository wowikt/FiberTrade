﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FifteenGameDbFirstRepository.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FifteenGameDbFirstEntities : DbContext
    {
        public FifteenGameDbFirstEntities()
            : base("name=FifteenGameDbFirstEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CurrentGameCell> CurrentGameCells { get; set; }
        public virtual DbSet<CurrentGame> CurrentGames { get; set; }
        public virtual DbSet<FinishedGame> FinishedGames { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
