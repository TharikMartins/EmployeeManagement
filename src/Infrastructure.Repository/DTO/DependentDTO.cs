using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Repository.DTO
{

    [Table("Dependent", Schema = "dbo")]
    public class DependentDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        
        [Required]
        public string Gender { get; set; }

        [Required]
        public EmployeeDTO Employee { get; set; }
        public int EmployeeId{ get; set; }
    }
}
