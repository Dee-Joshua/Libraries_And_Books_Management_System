using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.DTOs.ForDto
{
    public record Books_By_CategoryDto
    {
        public int CategoryId { get; init; }

        public int Isbn { get; init; }
    }
}
