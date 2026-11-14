using System.ComponentModel.DataAnnotations;

namespace wt_lab8_8razor_postgresql_talashkevich.Models;

public class TrainingSession
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите название тренировки")]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    public int MemberId { get; set; }

    public int TrainerId { get; set; }

    [Required(ErrorMessage = "Укажите дату и время тренировки")]
    public DateTime StartTime { get; set; }

    [Range(15, 240, ErrorMessage = "Продолжительность должна быть от 15 до 240 минут")]
    public int DurationMinutes { get; set; }
}