using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermWorkDatabases.Models.Enteties
{
    [Table("Plants")]
    class Plant
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [Required]
        public Company Company { get; set; }

        [Required]
        public bool IsFree { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Plant()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
