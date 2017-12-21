using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermWorkDatabases.Models.Enteties
{
    [Table("Companies_products")]
    class CompanyProduct
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [Required]
        public Company Company { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public int Cost { get; set; }

        public ICollection<Order> Orders { get; set; }

        public CompanyProduct()
        {
            Orders = new List<Order>();
        }
    }
}
