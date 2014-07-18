﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Bus
{
    public class Schedule
    {
        [Key]
        public virtual int ScheduleId { get; set; }
        [Required]
        [MaxLength(500)]
        public virtual string Description { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public virtual DateTime DepartureTime { get; set; }
        [Required]
        public virtual int JourneyFromId { get; set; }
        public virtual Location JourneyFrom { get; set; }
        [Required]
        public virtual int JourneyToId { get; set; }        
        public virtual Location JourneyTo { get; set; }
        [Required]
        public virtual int BusTypeId { get; set; }
        public virtual BusType BusType { get; set; }
        [Required]
        public virtual int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
