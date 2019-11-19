using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MovieActor>()
                .HasKey(mc => new { mc.MovieId, mc.ActorId });
            modelBuilder.Entity<MovieActor>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(mc => mc.MovieId);
            modelBuilder.Entity<MovieActor>()
                .HasOne(mc => mc.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(mc => mc.ActorId);

            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(g => g.MovieGenres)
                .HasForeignKey(mg => mg.GenreId);
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.MovieId);

            modelBuilder.Entity<Studio>().HasData(
                new Studio() { StudioId = -1, Name = "Warner Bros" });
            modelBuilder.Entity<Studio>().HasData(
                new Studio() { StudioId = -2, Name = "Paramount Pictures" });

            modelBuilder.Entity<Director>().HasData(
                new Director() { DirectorId = -1, Name = "Quentin Tarantino" });
            modelBuilder.Entity<Director>().HasData(
                new Director() { DirectorId = -2, Name = "Guy Ritchie" });

            modelBuilder.Entity<Reviewer>().HasData(
                new Reviewer() { ReviewerId = -1, Name = "Vincent Canby" });
            modelBuilder.Entity<Reviewer>().HasData(
                new Reviewer() { ReviewerId = -2, Name = "Dana Stevens" });

            modelBuilder.Entity<Actor>().HasData(
                new Actor() { ActorId = -1, Name = "Bradley Pitt" });
            modelBuilder.Entity<Actor>().HasData(
                new Actor() { ActorId = -2, Name = "Thomas Hardy" });

            modelBuilder.Entity<Genre>().HasData(
                new Genre() { GenreId = -1, Name = "Drama" });
            modelBuilder.Entity<Genre>().HasData(
                new Genre() { GenreId = -2, Name = "Thriller" });

            modelBuilder.Entity<Movie>().HasData(
                new Movie() { MovieId = -1, Name = "Once Upon a Time in… Hollywood", DirectorId = -1, StudioId = -1, ShortDescription = "Once Upon a Time in Hollywood is a 2019 comedy-drama film written and directed by Quentin Tarantino." });
            modelBuilder.Entity<Movie>().HasData(
                new Movie() { MovieId = -2, Name = "RocknRolla", DirectorId = -2, StudioId = -2, ShortDescription = "RocknRolla is a 2008 action crime film written and directed by Guy Ritchie" });

            modelBuilder.Entity<Review>().HasData(
                new Review() { ReviewId = -1, Text = "Very nice movie", MovieId = -1, ReviewerId = -1 });
            modelBuilder.Entity<Review>().HasData(
                new Review() { ReviewId = -2, Text = "Gorgeous movie", MovieId = -2, ReviewerId = -2 });
        }
    }
}
