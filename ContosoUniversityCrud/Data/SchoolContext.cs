
using ContosoUniversityCrud.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContosoUniversityCrud.Data
{
    public class SchoolContext : DbContext
    {

        public SchoolContext() : base("SchoolContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<TipoStudent> TipoStudents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Student>().HasKey(x => x.ID); //primary key

            modelBuilder.Entity<Student>().Property(x => x.FirstMidName).HasMaxLength(50)
                .IsRequired()
                .HasColumnName("Nombre");


            modelBuilder.Entity<Student>().Property(x => x.LastName).HasMaxLength(60)
                .IsRequired()
                .HasColumnName("Apellido");

            modelBuilder.Entity<TipoStudent>().HasKey(x => x.Cod);
            modelBuilder.Entity<TipoStudent>().Property(x => x.Cod).IsRequired().HasColumnName("Codigo");
        }

            public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                var entity = entry.Entity;
                if (entry.State == EntityState.Deleted)

                {
                    entry.State = EntityState.Modified;
                    entity.GetType().GetProperty("Active").SetValue(entity, 0);


                }
            }
            return base.SaveChanges();






        }
    }
}