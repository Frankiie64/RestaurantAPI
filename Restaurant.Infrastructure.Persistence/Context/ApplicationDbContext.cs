using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Core.Application.helper;
using Restaurant.Core.Domain.Common;
using Restaurant.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext: DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private AuthenticationResponse user;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<InfoDish> InfoDish { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {                      
            if (_httpContextAccessor.HttpContext == null)
            {
                List<string> Rol = new();

                Rol.Add("SuperAdmin");

                user = new AuthenticationResponse
                {
                    Id = "01",
                    Username = "masterAdmin",
                    Email = "masterAdmin@gmail.com",
                    Roles = Rol,
                    IsVerified = true
                };                                
            }
            else
            {
                user = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            }

            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = user.Username;
                        break;
                    case EntityState.Added:
                        entry.Entity.Creadted = DateTime.Now;
                        entry.Entity.CreatedBy = user.Username;
                        break;
                }
            }
        
            return base.SaveChangesAsync(cancellationToken);
        }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            #region Table

            
            modelBuilder.Entity<Ingredients>().ToTable("Ingredients");
            modelBuilder.Entity<Dish>().ToTable("Dish");
            modelBuilder.Entity<InfoDish>().ToTable("InfoDish");


            #endregion

            #region constraint

            #region Primary Key

            modelBuilder.Entity<Ingredients>().HasKey(x => x.Id);
            modelBuilder.Entity<Dish>().HasKey(x => x.Id);
            modelBuilder.Entity<InfoDish>().HasKey(x => x.Id);

            #endregion

            #region Relationships

            modelBuilder.Entity<Dish>()
              .HasMany<InfoDish>(x => x.Ingredients)
              .WithOne(x => x.Dish)
              .HasForeignKey(x => x.IdDish)
              .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

                modelBuilder.Entity<Ingredients>()
             .HasMany<InfoDish>(x => x.Dishes)
             .WithOne(x => x.Ingredients)
             .HasForeignKey(x => x.IdIngredient)
             .OnDelete(deleteBehavior: DeleteBehavior.Cascade);             

            #endregion


            #endregion

            #region "Validation Required"

            #region Ingredients

            modelBuilder.Entity<Ingredients>()
                .Property(a => a.Name)
                .IsRequired();

            #endregion

            #region Dish

            modelBuilder.Entity<Dish>()
              .Property(a => a.Name)
              .IsRequired();

            modelBuilder.Entity<Dish>()
             .Property(a => a.Price)
             .IsRequired();

            modelBuilder.Entity<Dish>()
             .Property(a => a.DishFor)
             .IsRequired();

            modelBuilder.Entity<Dish>()
             .Property(a => a.DishCategory)
             .IsRequired();

            #endregion

            #region InfoDish

            modelBuilder.Entity<InfoDish>()
              .Property(a => a.IdDish)
              .IsRequired();

            modelBuilder.Entity<InfoDish>()
              .Property(a => a.IdIngredient)
              .IsRequired();

            #endregion
            #endregion
        }
    }
}