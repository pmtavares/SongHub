using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SongHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendences { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //User FluentAPI to override conventions
        //this is to avoid circular relation
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Gig)
                .WithMany(g=> g.Attendances)
                .WillCascadeOnDelete(false); //Turn off cascade delete

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followers)
                .WithRequired(f => f.Followee)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followees)
                .WithRequired(f => f.Follower)
                .WillCascadeOnDelete(false);


            /* CODE below is to correct the following error when updating DB ****
            Introducing FOREIGN KEY constraint 'FK_dbo.UserNotifications_dbo.AspNetUsers_UserId' on table 
            'UserNotifications' may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or 
            ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints. Could not create constraint or index. 
            See previous errors.
             * */
            modelBuilder.Entity<UserNotification>()
                .HasRequired(n => n.User)
                .WithMany(u=> u.UserNotifications)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);        
        }
    }
}