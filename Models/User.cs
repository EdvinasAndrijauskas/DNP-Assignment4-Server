using System.ComponentModel.DataAnnotations;

namespace Assignment_4___Server.Models
{
    public class User
    {
        [Required, Key] public string UserName { get; set; }

        public string Role { get; set; }
        public string Password { get; set; }
    }
}