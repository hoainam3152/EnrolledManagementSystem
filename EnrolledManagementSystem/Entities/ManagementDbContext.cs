using Microsoft.EntityFrameworkCore;

namespace EnrolledManagementSystem.Entities
{
    public class ManagementDbContext : DbContext
    {
        public ManagementDbContext(DbContextOptions options) : base(options) { }

        #region DbSet

        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<BlockMarkType> BlockMarkTypes { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<MarkType> MarkTypes { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectGroup> SubjectGroups { get; set; }
        public DbSet<TeachingAssignment> TeachingAssignments { get; set; }
        public DbSet<Trainee> Trainees { get; set; }

        #endregion
    }
}
