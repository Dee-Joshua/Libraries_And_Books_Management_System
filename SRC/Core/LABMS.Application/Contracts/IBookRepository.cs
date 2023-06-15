﻿using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Contracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges);
        Task<Book> GetBookByIdAsync(int id, bool trackChanges);
        Task<Book> GetBookByTitle(string bookTitle, bool trackChanges);
        void CreateBook(Book book);
        void DeleteBook(Book book);
    }
}
