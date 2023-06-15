using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForDto;
using LABMS.Application.DTOs.ForUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.ServiceContract.Interfaces
{
    public interface IAmazonBooksService
    {
        Task<IEnumerable<AmazonBooksDto>> GetAllAmazonBooksAsync(bool trackChanges);
        Task<AmazonBooksDto> GetAmazonBookByIdAsync(int id, bool trackChanges);
        Task CreateAmazonBook(AmazonBooksForCreationDto amazonBooks);
        Task UpdateAmazonBool(AmazonBooksForUpdate amazonBooks);
        Task DeleteAmazonBook(int bookId);
    }
}
