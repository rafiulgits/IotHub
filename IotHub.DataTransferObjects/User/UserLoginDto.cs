using System.ComponentModel.DataAnnotations;

namespace IotHub.DataTransferObjects.User
{
    public class UserLoginDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
