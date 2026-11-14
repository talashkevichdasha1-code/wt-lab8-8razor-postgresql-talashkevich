using System.ComponentModel.DataAnnotations;

namespace wt_lab8_8razor_postgresql_talashkevich.Models;

public class Trainer
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите имя тренера")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите специализацию")]
    [StringLength(100)]
    public string Specialization { get; set; } = string.Empty;

    [Range(0, 60, ErrorMessage = "Стаж должен быть от 0 до 60 лет")]
    public int ExperienceYears { get; set; }
}