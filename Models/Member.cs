using System.ComponentModel.DataAnnotations;

namespace wt_lab8_8razor_postgresql_talashkevich.Models;

public class Member
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите имя участника")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(14, 100, ErrorMessage = "Возраст должен быть от 14 до 100 лет")]
    public int Age { get; set; }

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    public int MembershipPlanId { get; set; }

    public int TrainerId { get; set; }

    public bool IsActive { get; set; }
}