using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Domain.Entities
{
    public class ScheduleTask
    {
        public int Id { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public int TaskId { get; set; }
        public TaskItem Task { get; set; }

        public DateTime PlannedTime { get; set; }
        [Required, MaxLength(20)]
        public string? Status { get; set; }
    }
}
