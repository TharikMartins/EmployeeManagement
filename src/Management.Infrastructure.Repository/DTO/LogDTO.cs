using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Infrastructure.Repository.DTO
{
    [Table("Log", Schema = "dbo")]
    public class LogDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string MethodType { get; set; }

        [Required]
        public string EndpointName { get; set; }
        
        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
