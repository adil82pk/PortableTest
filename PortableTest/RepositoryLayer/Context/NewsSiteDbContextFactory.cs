// <copyright file="PoologicDbContextFactory.cs" company="Poologics">
// Copyright (c) Poologics. All rights reserved.
// </copyright>
namespace RepositoryLayer.Context
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using Common.Helper;
    
    /// <summary>
    /// Class PoologicDbContextFactory
    /// </summary>
    class NewsSiteDbContextFactory : IDesignTimeDbContextFactory<NewsSiteDbContext>
    {
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Create DBContext
        /// </summary>
        /// <param name="args">Array of arguments</param>
        /// <returns>Object of PoologicDbContext</returns>
        NewsSiteDbContext IDesignTimeDbContextFactory<NewsSiteDbContext>.CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<NewsSiteDbContext>();


            string connectionString = AppConfiguration.GetConfiguration().GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new NewsSiteDbContext(builder.Options);
        }
    }
}