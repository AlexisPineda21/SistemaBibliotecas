using System.ComponentModel.DataAnnotations;

namespace SistemaBibliotecas.DAL.Entites
{
    public class Borrowing : AuditBase
    {
        [Required(ErrorMessage = "The field {0} is mandatory")]
        [Display(Name = "BorrowingDate")]
        public DateTime BorrowingDate { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [Display(Name = "DeliveryDate")]
        public DateTime DeliveryDate { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [Display(Name = "Book Id")]
        public Guid BookId { get; set; }

        [Display(Name = "Book")]
        public Book Book { get; set; }



        [Required(ErrorMessage = "The field {0} is mandatory")]
        [Display(Name = "Client Id")]
        public Guid ClientId { get; set; }

        [Display(Name = "Client")]
        public Client Client { get; set; }
    }
}
