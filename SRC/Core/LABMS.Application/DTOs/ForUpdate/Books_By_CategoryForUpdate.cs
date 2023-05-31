using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.DTOs.ForUpdate
{
    public record Books_By_CategoryForUpdate
    {
        public int CategoryId { get; init; }

        public int Isbn { get; init; }
    }
}
