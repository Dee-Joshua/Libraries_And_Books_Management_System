namespace LABMS.WebApi.Exceptions
{
    public class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(string categoryName) 
            : base($"The Book Category {categoryName} doesn't exist in the database")
        {
        }
    }
}
