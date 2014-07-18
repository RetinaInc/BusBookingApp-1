using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Bus
{
    public class Location
    {
        [Key]
        public virtual int LocationId { get; set; }
        [Required]
        [MaxLength(50)]
        public virtual string Name { get; set; }
        public virtual ICollection<Schedule> FromSchedules { get; set; }
        public virtual ICollection<Schedule> ToSchedules { get; set; }
    }
}
