using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace api_auth.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
