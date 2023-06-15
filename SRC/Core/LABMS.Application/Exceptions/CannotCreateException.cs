using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Exceptions
{
    public class CannotCreateException:Exception
    {
        public CannotCreateException(string message):base(message)
        {
            
        }
    }
}
