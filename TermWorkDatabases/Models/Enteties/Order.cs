using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermWorkDatabases.Models.Enteties
{
    [Table("Orders")]
    class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [ForeignKey("CompanieProduct")]
        public int CompanieProductId { get; set; }

        [Required]
        public CompanyProduct CompanieProduct { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public DateTime FinishDate { get; set; }    
        
        [Required]
        public bool IsStarted { get; set; }

        [Required]
        public bool IsFinished { get; set; }
    }
}
