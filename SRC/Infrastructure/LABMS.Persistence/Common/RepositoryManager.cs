using LABMS.Application.Common;
using LABMS.Application.Contracts;
using LABMS.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Persistence.Common
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IAddressRepository> _addressRepository;
        private readonly Lazy<IAmazon_Books_Repository> _amazon_Books_Repository;
        private readonly Lazy<IAuthorRepository> _authorRepository;
        private readonly Lazy<IBookRepository> _bookRepository;
        private readonly Lazy<IBooks_At_Library_Repository> _books_At_Library_Repository;
        private readonly Lazy<IBooks_By_Author_Repository> _books_By_Author_Repository;
        private readonly Lazy<IBooks_By_Category_Repository> _books_By_Category_Repository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<ILibraryRepository> _libraryRepository;
        private readonly Lazy<IMember_Request_Repository> _member_Request_Repository;
        private readonly Lazy<IMemberRepository> _memberRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _addressRepository = new Lazy<IAddressRepository>(() => new AddressRepository(repositoryContext));
            _amazon_Books_Repository = new Lazy<IAmazon_Books_Repository>(() => new Amazon_Books_Repository(repositoryContext));
            _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(repositoryContext));
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(repositoryContext));
            _books_At_Library_Repository = new Lazy<IBooks_At_Library_Repository>(() => new Books_At_Library_Repository(repositoryContext));
            _books_By_Author_Repository = new Lazy<IBooks_By_Author_Repository>(() => new Books_By_Author_Repository(repositoryContext));
            _books_By_Category_Repository = new Lazy<IBooks_By_Category_Repository>(() => new Books_By_Category_Repository(repositoryContext));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
            _libraryRepository = new Lazy<ILibraryRepository>(() => new LibraryRepository(repositoryContext));
            _member_Request_Repository = new Lazy<IMember_Request_Repository>(() => new Member_Request_Repository(repositoryContext));
            _memberRepository = new Lazy<IMemberRepository>(() => new MemberRepository(repositoryContext));
        }

        public IAddressRepository AddressRepository => _addressRepository.Value;

        public IAmazon_Books_Repository AmazonBooksRepository => _amazon_Books_Repository.Value;

        public IAuthorRepository AuthorRepository => _authorRepository.Value;

        public IBookRepository BookRepository => _bookRepository.Value;

        public IBooks_At_Library_Repository BooksAtLibraryRepository => _books_At_Library_Repository.Value;

        public IBooks_By_Author_Repository BooksByAuthorRepository => _books_By_Author_Repository.Value;

        public IBooks_By_Category_Repository BooksByCategoryRepository => _books_By_Category_Repository.Value;

        public ICategoryRepository CategoryRepository => _categoryRepository.Value;

        public ILibraryRepository LibraryRepository => _libraryRepository.Value;

        public IMember_Request_Repository MemberRequestRepository => _member_Request_Repository.Value;

        public IMemberRepository MemberRepository => _memberRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
