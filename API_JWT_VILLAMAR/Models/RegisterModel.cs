using System.ComponentModel.DataAnnotations;

namespace API_JWT_VILLAMAR.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage="Nombre de usuario requerido")]
        public string UserName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email requerida")]
        public string Email { get; set; }

        [Required(ErrorMessage="Clave requerida")]
        public string Password { get; set; }

    }
}
