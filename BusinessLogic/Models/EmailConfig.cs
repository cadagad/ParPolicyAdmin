using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class EmailConfig
    {
        public int EmailConfigId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Value { get; set; }

        /* Values = Fixed / Dynamic */
        [Required]
        [MaxLength(20)]
        public string Type { get; set; }
    }
}
