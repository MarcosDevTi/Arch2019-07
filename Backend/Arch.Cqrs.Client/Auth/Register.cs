using System.ComponentModel.DataAnnotations;
using Arch.CrossCutting.CqrsContracts;

namespace Arch.Cqrs.Client.Auth
{
    public class Register: ICommand
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public string Password { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }
    }
}