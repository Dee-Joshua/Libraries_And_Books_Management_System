using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Exceptions
{
    public class MemberNotFoundException : NotFoundException
    {
        public MemberNotFoundException(int memberId)
            : base($"The Member with the id {memberId} doesn't exist in the database")
        {
        }
        public MemberNotFoundException() : base($"No member request found in the database")
        {

        }
    }
}
