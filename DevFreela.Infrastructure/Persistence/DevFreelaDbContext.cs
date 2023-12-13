using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasKey(p => p.id);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Client)
                .WithMany(p => p.OwnedProjects)
                .HasForeignKey(p => p.IdClient)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Freelancer)
                .WithMany(p => p.FreelanceProjects)
                .HasForeignKey(p => p.Idfreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectComment>()
                .HasKey(p => p.id);

            modelBuilder.Entity<ProjectComment>()
                .HasOne(s => s.Project)
                .WithMany(s => s.Comments)
                .HasForeignKey(s => s.IdProject);

            modelBuilder.Entity<ProjectComment>()
                .HasOne(s => s.User)
                .WithMany(s => s.Comments)
                .HasForeignKey(s => s.IdUser);

            modelBuilder.Entity<Skill>()
                .HasKey(s => s.id);

            modelBuilder.Entity<User>()
                .HasKey(s => s.id);

            modelBuilder.Entity<User>()
                .HasMany(p => p.Skills)
                .WithOne()
                .HasForeignKey(p => p.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserSkill>()
                .HasKey(p => p.id);
        }
    }
}
