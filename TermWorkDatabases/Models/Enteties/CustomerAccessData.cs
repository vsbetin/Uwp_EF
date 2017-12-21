using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermWorkDatabases.Models.Enteties
{
    [Table("Customer_access_data")]
    public class CustomerAccessData
    {
        [Key, ForeignKey("Customer")]
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required, MinLength(5), MaxLength(30)]
        public string Login { get; set; }

        [Required, MinLength(8), MaxLength(40)]
        public string Password { get; set; }
    }
}
