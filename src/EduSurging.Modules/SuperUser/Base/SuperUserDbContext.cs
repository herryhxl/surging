using Edu.Surging.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace Edu.Surging.EFServices.SuperUser.Base
{
    public partial class SuperUserDbContext : EfDbContext, IDbContext
    { 
        #region Ctor
        public SuperUserDbContext(DbContextOptions<SuperUserDbContext> options) : base(options)
        {
        }
        
        #endregion
         #region Utilities

        /// <summary>
        /// Further configuration the model
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //dynamically load all entity and query type configurations
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                typeof(ISuperUserMapping).IsAssignableFrom(type)&& type.Name!= "ISuperUserMapping"); 

            foreach (var typeConfiguration in typeConfigurations)
            {
                var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
                configuration.ApplyConfiguration(modelBuilder);
            }
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
