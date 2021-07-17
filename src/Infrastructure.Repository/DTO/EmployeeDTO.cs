using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Repository.DTO
{
    [Table("Employee", Schema = "dbo")]
    public class EmployeeDTO
    {
        [Key] 
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
        public List<DependentDTO> Dependents { get; set; }
    }
}
