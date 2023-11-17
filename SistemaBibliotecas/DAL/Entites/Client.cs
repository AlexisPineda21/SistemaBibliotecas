using System.ComponentModel.DataAnnotations;

namespace SistemaBibliotecas.DAL.Entites
{
    public class Client : AuditBase
    {
        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MaxLength(50, ErrorMessage = "The field {0} must have a max of {1} characters")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MaxLength(50, ErrorMessage = "The field {0} must have a max of {1} characters")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [MaxLength(15, ErrorMessage = "The field {0} must have a max of {1} characters")]
        [MinLength(4, ErrorMessage = "The field {0} must have a min of {1} characters")]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Display(Name = "Borrowing")]
        public ICollection<Borrowing>? Borrowings { get; set; }
    }
}
