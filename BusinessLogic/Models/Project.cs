using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Type { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsArchived { get; set; }

        [Required]
        [MaxLength(20)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
