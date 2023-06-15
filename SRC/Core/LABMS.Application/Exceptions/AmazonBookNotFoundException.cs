using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Exceptions
{
    public sealed class AmazonBookNotFoundException : NotFoundException
    {
        public AmazonBookNotFoundException(string title)
            : base($"The Amazon Book with title {title} doesn't exist in the database")
        {
        }
    }
}
