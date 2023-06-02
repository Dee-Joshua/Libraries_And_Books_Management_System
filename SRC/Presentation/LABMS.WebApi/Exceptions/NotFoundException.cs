namespace LABMS.WebApi.Exceptions
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message): base(message) { }
    }
}
