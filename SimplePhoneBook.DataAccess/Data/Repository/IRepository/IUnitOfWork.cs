using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePhoneBook.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IEntryRepository Entry { get; }

        IPhoneBookRepository PhoneBook { get; }

        void Save();
    }
}
