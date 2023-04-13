using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class BarcodeFeed
    {
        public int BarcodeFeedId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FileName { get; set; }

        [Required]
        public bool IsProcessed { get; set; }

        [Required]
        public bool IsValid { get; set; }

        [Required]
        public int RowCount { get; set; }

        [Required]
        [MaxLength(20)]
        public string ProcessedBy { get; set; }

        [Required]
        public DateTime ProcessedDate { get; set; }

        [MaxLength(200)]
        public string ExceptionReason { get; set; }

        [ForeignKey("Project")]
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
