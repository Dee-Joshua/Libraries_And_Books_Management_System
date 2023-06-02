namespace LABMS.WebApi.Exceptions
{
    public class LibraryNotFoundExceptionm : NotFoundException
    {
        public LibraryNotFoundExceptionm(string libraryName) 
            : base($"The Library {libraryName} doesn't exist in the database")
        {
        }
    }
}
