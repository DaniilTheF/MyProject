using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;


namespace MyProject.Objects.Models
{
    public class UserAcc
    {
        [BindNever]
        public int Id { get; set; }
        [BindNever]
        public User Users { get; set; }
        [Display(Name = "Введите Логин")]
        [StringLength(20)]
        [Required(ErrorMessage = "Это обязательное поле")]
        public string Loggin { get; set; }
        [Display(Name = "Введите Пароль")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Это обязательное поле")]
        public string Password { get; set; } 
    }
}
