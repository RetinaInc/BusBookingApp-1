using System.ComponentModel.DataAnnotations;

namespace Domain.Bus
{
    public class Company
    {
        [Key]
        public virtual int CompanyId { get; set; }
        [Required]
        [MaxLength(50)]
        public virtual string Name { get; set; }
    }
}
