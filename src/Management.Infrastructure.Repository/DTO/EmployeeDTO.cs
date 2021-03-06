using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Infrastructure.Repository.DTO
{
    [Table("Employee", Schema = "dbo")]
    public class EmployeeDTO
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
        public string Cpf { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public bool IsActive { get; set; }
        public ICollection<DependentDTO> Dependents { get; set; }
    }
}
