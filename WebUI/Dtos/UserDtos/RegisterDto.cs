using System.ComponentModel.DataAnnotations;

namespace WebUI.Dtos.UserDtos
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string RepresentationCode { get; set; }
        public int DepartmentId { get; set; }
    }
}
