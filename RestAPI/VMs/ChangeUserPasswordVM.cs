using System.ComponentModel.DataAnnotations;

namespace RestAPI.VMs
{
    public class ChangeUserPasswordVM
    {
        [Display(Name = "كلمة المرور")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "يجب إدخال كلمة المرور")]
        [MinLength(8, ErrorMessage = "يجب أن تتكون كلمة المرور من 8 أحرف على الأقل")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*()])[a-zA-Z0-9!@#$%^&*()]{8,}$", ErrorMessage = "يجب أن تحتوي كلمة المرور على حرف صغير واحد على الأقل وحرف كبير واحد على الأقل ورقم واحد على الأقل ورمز واحد على الأقل")]

        public string Password { get; set; } = null!;
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
