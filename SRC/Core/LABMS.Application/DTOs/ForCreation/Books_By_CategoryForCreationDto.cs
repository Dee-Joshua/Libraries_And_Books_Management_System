using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.DTOs.ForCreation
{
    public record Books_By_CategoryForCreationDto
    {
        public int CategoryId { get; init; }

        public int Isbn { get; init; }
    }
}
