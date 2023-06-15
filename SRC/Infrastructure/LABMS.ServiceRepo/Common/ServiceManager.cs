using AutoMapper;
using LABMS.Application.Common;
using LABMS.Domain.entities;
using LABMS.ServiceContract.Common;
using LABMS.ServiceContract.Interfaces;
using LABMS.ServiceRepository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.ServiceRepository.Common
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMemberService> memberService;
        private readonly Lazy<IAddressService> addressService;
        private readonly Lazy<ILibraryService> libraryService;
        private readonly Lazy<IBookService> bookService;
        private readonly Lazy<IAuthorService> authorService;    
        private readonly Lazy<IAmazonBooksService> amazonBooksService;
        private readonly Lazy<IBooks_At_Library_Service> books_At_Library_Service;
        private readonly Lazy<IBooks_By_Author_Service> books_By_Author_Service;
        private readonly Lazy<IMemberRequestService> memberRequestService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            memberService = new Lazy<IMemberService>(()=> new MemberService(repositoryManager, mapper));
            addressService = new Lazy<IAddressService>(()=>new  AddressService(repositoryManager, mapper));
            libraryService = new Lazy<ILibraryService>(()=> new LibraryService(repositoryManager, mapper));
            bookService = new Lazy<IBookService>(()=>new BookService(repositoryManager, mapper));
            authorService = new Lazy<IAuthorService>(()=>new AuthorService(repositoryManager, mapper));
            //amazonBooksService = new Lazy<IAmazonBooksService>(()=> new AmazonBooksService(repositoryManager, mapper));
            books_At_Library_Service = new Lazy<IBooks_At_Library_Service>(()=>new Books_At_LibrariesService(repositoryManager,mapper));
            books_By_Author_Service = new Lazy<IBooks_By_Author_Service>(() => new Book_By_AuthorService(repositoryManager, mapper));
            memberRequestService = new Lazy<IMemberRequestService>(()=>new Member_RequestService(repositoryManager, mapper));
        }

        public IMemberService MemberService => memberService.Value;

        public IAddressService AddressService => addressService.Value;

        public ILibraryService LibraryService => libraryService.Value;

        public IBookService BookService => bookService.Value;

        public IAuthorService AuthorService => authorService.Value;

        public IAmazonBooksService AmazonBooksService => throw new NotImplementedException();

        public IBooks_At_Library_Service BookAtLibraryService => books_At_Library_Service.Value;

        public IBooks_By_Author_Service BookByAuthorService => books_By_Author_Service.Value;

        public IMemberRequestService MemberRequestService => memberRequestService.Value;
    }
}
