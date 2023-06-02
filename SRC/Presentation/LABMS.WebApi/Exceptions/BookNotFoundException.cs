namespace LABMS.WebApi.Exceptions
{
    public class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(string bookTitle) 
            : base($"The Library Book with title {bookTitle} doesn't exist in the database")
        {
        }
    }
}
