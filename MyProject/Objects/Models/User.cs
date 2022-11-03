using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;


namespace MyProject.Objects.Models
{ 

    public class User
    {


        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Введите ФИО")]
        [StringLength(20)]
        [Required(ErrorMessage = "Это обязательное поле")]
        public string FIO { get; set; }

        [Display(Name = "Введите номер телефона")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Это обязательное поле")]
        public string phoneN { get; set; }

        [Display(Name = "Введите ваш адрес")]
        [StringLength(20)]
        [Required(ErrorMessage = "Это обязательное поле")]
        public string adress { get; set; }

        [Display(Name = "Введите Логин")]
        [StringLength(20)]
        [Required(ErrorMessage = "Это обязательное поле")]
        public string login { get; set; }

        [Display(Name = "Введите Пароль")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Это обязательное поле")]
        public string password { get; set; }


    }
}
