﻿using Data.Entities.Configurations;
using LinkQuality.Data.Repository.UtilitiesRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PuntoDeVentaData.Entities.Parameters;
using PuntoDeVentaData.Entities.Security;
using PuntoDeVentaData.Entities.Templates;
using PuntoDeVentaData.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        
        }

        #region RESOURCE
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Parameters> Parameters { get; set; }
        public virtual DbSet<Notificacion> Notificacions { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<BucketFile> BucketFiles { get; set; }

        #endregion

        #region SECURITY
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuRole> MenuRoles { get; set; }
        public virtual DbSet<AuditoryAccess> AuditoryAccesses { get; set; }
        public virtual DbSet<ApplicationVersion> ApplicationVersions { get; set; }
        #endregion

        #region SECURITY CONFIGS
        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public virtual DbSet<IdentityUserRole<string>> UserRoles { get; set;}
        #endregion

        #region CLASIFICATION
        public virtual DbSet<ParameterType> ParameterTypes { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigurationDefaultRoles();
            modelBuilder.ConfigurationDefaultDataUsuario();
            modelBuilder.ConfigurationDefaultDataUserRol();
            modelBuilder.ConfigurationTablesUsersAndRols();
            modelBuilder.ConfigurationDefaultDataTipoParametro();
            modelBuilder.ConfigurationDefaultDataParametros();
            modelBuilder.ConfigurationDefaultDataMenu();

            modelBuilder.ConfigurationDefaultDataMenuRole();
            modelBuilder.ConfigurationDefaultDataEmailTemplate();

            
        }

        public override int SaveChanges()
        {
            var entities = (from entry in ChangeTracker.Entries()
                            where entry.State == EntityState.Modified || entry.State == EntityState.Added
                            select entry.Entity);

            var validationResults = new List<ValidationResult>();
            foreach (var entity in entities)
            {
                if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults))
                {
                    // throw new ValidationException() or do whatever you want
                }
            }
            return base.SaveChanges();
        }
    }
}
