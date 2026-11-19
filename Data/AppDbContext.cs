
using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_talashkevich.Models;

namespace wt_lab8_8razor_postgresql_talashkevich.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Member> Members => Set<Member>();
    public DbSet<MembershipPlan> MembershipPlans => Set<MembershipPlan>();
    public DbSet<Trainer> Trainers => Set<Trainer>();
    public DbSet<TrainingSession> TrainingSessions => Set<TrainingSession>();

    // Таблица пользователей для авторизации
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Member>()
            .HasOne<MembershipPlan>()
            .WithMany()
            .HasForeignKey(m => m.MembershipPlanId);

        modelBuilder.Entity<Member>()
            .HasOne<Trainer>()
            .WithMany()
            .HasForeignKey(m => m.TrainerId);

        modelBuilder.Entity<TrainingSession>()
            .HasOne<Member>()
            .WithMany()
            .HasForeignKey(s => s.MemberId);

        modelBuilder.Entity<TrainingSession>()
            .HasOne<Trainer>()
            .WithMany()
            .HasForeignKey(s => s.TrainerId);

        modelBuilder.Entity<TrainingSession>()
            .Property(s => s.StartTime)
            .HasColumnType("timestamp without time zone");

        modelBuilder.Entity<Trainer>().HasData(
            new Trainer { Id = 1, Name = "Александр Волков", Specialization = "Силовые тренировки", ExperienceYears = 8 },
            new Trainer { Id = 2, Name = "Мария Соколова", Specialization = "Фитнес и растяжка", ExperienceYears = 5 },
            new Trainer { Id = 3, Name = "Дмитрий Орлов", Specialization = "Кардиотренировки", ExperienceYears = 6 }
        );

        modelBuilder.Entity<MembershipPlan>().HasData(
            new MembershipPlan { Id = 1, Name = "Стандарт", Price = 80, DurationMonths = 1 },
            new MembershipPlan { Id = 2, Name = "Премиум", Price = 200, DurationMonths = 3 },
            new MembershipPlan { Id = 3, Name = "Годовой", Price = 600, DurationMonths = 12 }
        );

        modelBuilder.Entity<Member>().HasData(
            new Member { Id = 1, Name = "Анна Петрова", Age = 22, MembershipPlanId = 2, TrainerId = 1, IsActive = true },
            new Member { Id = 2, Name = "Максим Иванов", Age = 25, MembershipPlanId = 1, TrainerId = 2, IsActive = true },
            new Member { Id = 3, Name = "Елена Смирнова", Age = 21, MembershipPlanId = 3, TrainerId = 2, IsActive = true },
            new Member { Id = 4, Name = "Дмитрий Козлов", Age = 30, MembershipPlanId = 1, TrainerId = 3, IsActive = false },
            new Member { Id = 5, Name = "София Морозова", Age = 24, MembershipPlanId = 2, TrainerId = 1, IsActive = true }
        );

        modelBuilder.Entity<TrainingSession>().HasData(
            new TrainingSession { Id = 1, Title = "Силовая тренировка", MemberId = 1, TrainerId = 1, StartTime = new DateTime(2026, 10, 20, 10, 0, 0), DurationMinutes = 60 },
            new TrainingSession { Id = 2, Title = "Фитнес и растяжка", MemberId = 2, TrainerId = 2, StartTime = new DateTime(2026, 10, 20, 12, 0, 0), DurationMinutes = 45 },
            new TrainingSession { Id = 3, Title = "Кардиотренировка", MemberId = 3, TrainerId = 3, StartTime = new DateTime(2026, 10, 21, 15, 0, 0), DurationMinutes = 30 },
            new TrainingSession { Id = 4, Title = "Персональная тренировка", MemberId = 4, TrainerId = 3, StartTime = new DateTime(2026, 10, 21, 17, 0, 0), DurationMinutes = 60 },
            new TrainingSession { Id = 5, Title = "Комплексная тренировка", MemberId = 5, TrainerId = 1, StartTime = new DateTime(2026, 10, 22, 11, 0, 0), DurationMinutes = 90 }
        );
    }
}
