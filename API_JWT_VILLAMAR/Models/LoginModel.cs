using System.ComponentModel.DataAnnotations;

namespace API_JWT_VILLAMAR.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Usuario es requerido")]
        public string Username { get; set; }

        [Required(ErrorMessage="Clave requerida")]

        public string Password { get; set; }
    }
}
