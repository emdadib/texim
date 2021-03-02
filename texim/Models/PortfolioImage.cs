using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace texim.Models
{
    public class PortfolioImage
    {
        [Key]
        public int PortfolioImageId { get; set; }
        [ForeignKey("Portfolio")]
        public int PortfolioId { get; set; }
        public string Image { get; set; }
        public string Thumb { get; set; }

        public Portfolio Portfolio { get; set; }

    }
}
