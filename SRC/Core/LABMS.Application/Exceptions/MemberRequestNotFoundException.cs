using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Exceptions
{
    public class MemberRequestNotFoundException:NotFoundException
    {
        public MemberRequestNotFoundException(int id):base($"The Member request with id {id} is not found in the database")
        {
            
        }
        public MemberRequestNotFoundException():base($"Member request not found in the database")
        {
            
        }
    }
}
