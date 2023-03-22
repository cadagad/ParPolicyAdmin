using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class VwDuplicatePolicy
    {
        public long  PolicyId { get; set; }
        public string PolicyNumber { get; set; }
        public string HolderName { get; set; }
        public string BirthDate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public bool PossibleDuplicate { get; set; }

        public bool UserFlaggedDuplicate { get; set; }
    }
}
