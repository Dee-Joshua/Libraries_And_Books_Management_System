using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Domain.entities
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required(ErrorMessage = "Building number is required.")]
        [StringLength(10, ErrorMessage = "Building number cannot exceed 10 characters.")]
        public string? BuildingNumber { get; set; }

        [Required(ErrorMessage = "Street name is required.")]
        [StringLength(50, ErrorMessage = "Street name cannot exceed 50 characters.")]
        public string? StreetName { get; set; }

        [Required(ErrorMessage = "Area/locality is required.")]
        [StringLength(50, ErrorMessage = "Area/locality cannot exceed 50 characters.")]
        public string? AreaLocality { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [StringLength(50, ErrorMessage = "State cannot exceed 50 characters.")]
        public string? State { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50, ErrorMessage = "Country cannot exceed 50 characters.")]
        public string? Country { get; set; }

        // Navigation property for the one-to-many relationship
        public virtual ICollection<Member>? Members { get; set; }
        public virtual ICollection<Library>? Libraries { get; set; }
    }

}
