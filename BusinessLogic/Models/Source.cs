using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BusinessLogic.Models
{
    public class Source
    {
        public int SourceId { get; set; }

        
        [Required]
        [MaxLength(10)]
        public string Code { get; set; }


        [Required]
        public bool IsActive { get; set; }


        [MaxLength(20)]
        public string Division { get; set; }


        [MaxLength(20)]
        public string Region { get; set; }
    }
}
