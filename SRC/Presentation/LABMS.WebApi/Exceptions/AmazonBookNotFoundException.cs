namespace LABMS.WebApi.Exceptions
{
    public sealed class AmazonBookNotFoundException : NotFoundException
    {
        public AmazonBookNotFoundException(string title) 
            : base($"The Amazon Book with title {title} doesn't exist in the database")
        {
        }
    }
}
