using System.ComponentModel.DataAnnotations;

namespace RestAPI.VMs
{
    public class LoginVM
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        [MinLength(8)]
        public string Password { get; set; } = null!;

        public bool RememeberMe { get; set; } = false;
    }
}
