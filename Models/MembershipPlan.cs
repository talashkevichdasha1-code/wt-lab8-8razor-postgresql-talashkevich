using System.ComponentModel.DataAnnotations;

namespace wt_lab8_8razor_postgresql_talashkevich.Models;

public class MembershipPlan
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Введите название абонемента")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(typeof(decimal), "0.01", "1000000",
        ErrorMessage = "Стоимость должна быть больше нуля")]
    public decimal Price { get; set; }

    [Range(1, 36, ErrorMessage = "Срок должен быть от 1 до 36 месяцев")]
    public int DurationMonths { get; set; }
}