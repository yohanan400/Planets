﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlanetsDAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PlanetsEntities : DbContext
    {
        public PlanetsEntities()
            : base("name=PlanetsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Asteroid> Asteroids { get; set; }
        public virtual DbSet<Comet> Comets { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<PictureOfTheDay> PictureOfTheDays { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Neo> Neos { get; set; }
    }
}
