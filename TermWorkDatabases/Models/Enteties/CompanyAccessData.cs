using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermWorkDatabases.Models.Enteties
{
    [Table("Company_access_data")]
    class CompanyAccessData
    {
        [Key, ForeignKey("Company")]
        public int Id { get; set; }

        [Required]
        public Company Company { get; set; }

        [Required, MinLength(5), MaxLength(30)]
        public string Login { get; set; }

        [Required, MinLength(8), MaxLength(40)]
        public string Password { get; set; }   
    }
}
