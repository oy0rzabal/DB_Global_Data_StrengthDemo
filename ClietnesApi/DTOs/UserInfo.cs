using System.ComponentModel.DataAnnotations;

namespace ClientesAPI.DTOs
{
    public class UserInfo
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
