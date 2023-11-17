using System.ComponentModel.DataAnnotations;

namespace SistemaBibliotecas.DAL.Entites
{
    public class Book : AuditBase
    {
        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MaxLength(50, ErrorMessage = "The field {0} must have a max of {1} characters")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [MaxLength(50, ErrorMessage = "The field {0} must have a max of {1} characters")]
        [Display(Name = "Autor")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [Display(Name = "Status")]
        public bool Status { get; set; }


        [Display(Name = "Borrowing")]
        public ICollection<Borrowing>? Borrowings { get; set; }
    }
}
