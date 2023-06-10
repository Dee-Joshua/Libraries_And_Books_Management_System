using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Exceptions
{
    public class AddressAlreadyExistException:CannotCreateException
    {
        public AddressAlreadyExistException(int id):base($"Cannnot create an address for Entity id {id} because it already has an address")
        {
            
        }
    }
}
