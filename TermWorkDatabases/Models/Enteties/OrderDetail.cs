using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermWorkDatabases.Models.Enteties
{
    [Table("Order_details")]
    class OrderDetail
    {
        [Key, ForeignKey("Order")]
        public int Id { get; set; }

        [Required]
        public Order Order { get; set; }

        [ForeignKey("Plant")]
        public int PlantId { get; set; }

        [Required]
        public Plant Plant { get; set; }

        [Required]
        public DateTime StartWorkPlantDate { get; set; }

        [Required]
        public DateTime FinishWorkPlantDate { get; set; }
    }
}
