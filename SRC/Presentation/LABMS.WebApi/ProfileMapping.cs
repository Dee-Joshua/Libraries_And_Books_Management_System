using AutoMapper;
using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForDto;
using LABMS.Application.DTOs.ForUpdate;
using LABMS.Domain.entities;

namespace LABMS.WebApi
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            //Address Entity
            CreateMap<Address, AddressDto>();
            CreateMap<AddressForCreation, Address>();
            CreateMap<AddressForUpdate, Address>();

            //AmazonBooks Entity
            CreateMap<AmazonBooks, AmazonBooksDto>();
            CreateMap<AmazonBooksForCreation, AmazonBooks>();
            CreateMap<AmazonBooksForUpdate, AmazonBooks>();

            //Author Entity
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorForCreation, Author>();
            CreateMap<AuthorForUpdate, Author>();

            //Book Entity
            CreateMap<Book, BookDto>();
            CreateMap<BookForCreation, Book>();
            CreateMap<BookForUpdate, Book>();

            //Books_At_Library Entity
            CreateMap<Books_At_Library, Books_At_LibraryDto>();
            CreateMap<Books_At_LibraryForCreation,  Books_At_Library>();
            CreateMap<Books_At_LibraryForUpdate, Books_At_Library>();

            //Books_By_Author Entity
            CreateMap<Books_By_Author, Books_By_AuthorDto>();
            CreateMap<Books_By_AuthorForCreation, Books_By_Author>();
            CreateMap<Books_By_AuthorForUpdate, Books_By_Author>();

            //Books_By_Category Entity
            CreateMap<Books_By_Category, Books_By_CategoryDto>();
            CreateMap<Books_By_CategoryForCreation,  Books_By_Category>();
            CreateMap<Books_By_CategoryForUpdate, Books_By_Category>();

            //Category Entity
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForCreation, Category>();
            CreateMap<CategoryForUpdate, Category>();

            //Library Entity
            CreateMap<Library, LibraryDto>();
            CreateMap<LibraryForCreation, Library>();
            CreateMap<LibraryForUpdate, Library>();

            //Member Entity
            CreateMap<Member, MemberDto>();
            CreateMap<MemberForCreation, Member>();
            CreateMap<MemberForUpdate, Member>();

            //MemeberRequest Entity
            CreateMap<MemberRequest,  MemberRequestDto>();
            CreateMap<MemberRequestForCreation, MemberRequest>();
            CreateMap<MemberRequestForUpdate, MemberRequest>();
        }
    }
}
