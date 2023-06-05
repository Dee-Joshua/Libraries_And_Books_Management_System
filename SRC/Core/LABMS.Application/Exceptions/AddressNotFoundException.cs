using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Exceptions
{
    public class AddressNotFoundException: NotFoundException
    {
        public AddressNotFoundException(int id):base($"No address was found with id {id} in the database")
        {
            
        }
    }
}
