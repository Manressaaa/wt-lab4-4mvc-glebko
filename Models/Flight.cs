using System.ComponentModel.DataAnnotations;

namespace wt_lab4_4mvc_glebko.Models;

public class Flight
{
    [Required(ErrorMessage = "Укажите номер рейса")]
    [Range(1, 99999, ErrorMessage = "Номер должен быть от 1 до 99999")]
    public int nomer_reisa { get; set; }

    [Required(ErrorMessage = "Укажите город вылета")]
    [StringLength(50, ErrorMessage = "Не более 50 символов")]
    public string gorod_vilet { get; set; } = "";

    [Required(ErrorMessage = "Укажите город прилёта")]
    [StringLength(50, ErrorMessage = "Не более 50 символов")]
    public string gorod_prilet { get; set; } = "";

    [Required(ErrorMessage = "Укажите дату и время вылета")]
    public DateTime vremya_vileta { get; set; }

    [Required(ErrorMessage = "Укажите цену")]
    [Range(0, 1000000, ErrorMessage = "Цена должна быть от 0 до 1 000 000")]
    public decimal cena { get; set; }

    [Required(ErrorMessage = "Укажите количество мест")]
    [Range(0, 1000, ErrorMessage = "Мест должно быть от 0 до 1000")]
    public int mesta { get; set; }

    public bool dostupno { get; set; }
}