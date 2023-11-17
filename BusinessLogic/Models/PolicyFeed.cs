using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Models
{
    public class PolicyFeed
    {
        public int PolicyFeedId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FileName { get; set; }

        [Required]
        public bool IsProcessed { get; set; }

        [Required]
        public bool IsValid { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        public int? RowCount { get; set; }

        [MaxLength(20)]
        public string ProcessedBy { get; set; }

        public DateTime? ProcessedDate { get; set; }

        public int? UniqueRecordCount { get; set; }

        [MaxLength(100)]
        public string ExceptionReason { get; set; }

        [ForeignKey("Project")]
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
