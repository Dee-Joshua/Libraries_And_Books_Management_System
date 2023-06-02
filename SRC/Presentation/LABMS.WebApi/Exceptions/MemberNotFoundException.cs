namespace LABMS.WebApi.Exceptions
{
    public class MemberNotFoundException : NotFoundException
    {
        public MemberNotFoundException(int phoneNumber) 
            : base($"The Member with the phone number {phoneNumber}, doesn't exist in the database")
        {
        }
    }
}
