using System.ComponentModel.DataAnnotations;

namespace SistemaBibliotecas.DAL.Entites
{
    public class AuditBase
    {
        [Key]
        [Required]

        public virtual Guid Id { get; set; }
    }
}
