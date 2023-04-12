using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class Barcode
    {
        public long BarcodeId { get; set; }

        [ForeignKey("BarcodeFeed")]
        public int BarcodeFeedId { get; set; }

        public int LineNumber { get; set; }

        [MaxLength(7)]
        public string BarcodeNumber { get; set; }

        [MaxLength(10)]
        public string PolicyNumber { get; set; }
    }
}
