using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.DTOs.ForCreation
{
    public record Books_By_AuthorForCreation
    {
        public int AuthorId { get; init; }

        public int Isbn { get; init; }
    }
}
