using Microsoft.EntityFrameworkCore;
using PawFinderModel;

namespace PawFinderDL
{
    public class PawFinderDBcontext : DbContext
    {
        public DbSet<User> User {get;set;}
        public DbSet<Like> Like {get;set;}
        public DbSet<Match> Match {get;set;}
        public DbSet<Pass> Pass {get;set;}
        public DbSet<Message> Message{get;set;}


        public PawFinderDBcontext():base()
        {

        }

        public PawFinderDBcontext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        {
            p_modelBuilder.Entity<User>()
                .Property(e => e.UserID)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Message>()
                .Property(e => e.messageID)
                .ValueGeneratedOnAdd();

            p_modelBuilder.Entity<Like>()
                .HasOne(e => e.Liker)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            p_modelBuilder.Entity<Like>()
                .HasOne(e => e.Liked)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);;

            p_modelBuilder.Entity<Match>()
                .HasOne(e => e.MatcherOne)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);;

            p_modelBuilder.Entity<Match>()
                .HasOne(e => e.MatcherTwo)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);;

            p_modelBuilder.Entity<Pass>()
                .HasOne(e => e.Passer)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);;

            p_modelBuilder.Entity<Pass>()
                .HasOne(e => e.Passee)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);;

            p_modelBuilder.Entity<Message>()
                .HasOne(e => e.Sender)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);;

            p_modelBuilder.Entity<Message>()
                .HasOne(e => e.Receiver)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);;


        }

    }
}