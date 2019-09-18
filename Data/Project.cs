using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pusher.Data
{
    public class Project
    {

        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public int? DaysToComplete { get; set; }

        [Required]
        public DateTime? StartingDate { get; set; }

    }
}
