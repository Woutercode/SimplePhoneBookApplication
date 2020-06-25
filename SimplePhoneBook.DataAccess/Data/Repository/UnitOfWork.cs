using SimplePhoneBook.DataAccess.Data.Repository.IRepository;
using SimplePhoneBook.Models;

using SimplePhoneBook.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePhoneBook.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Entry = new EntryRepository(_db);
            PhoneBook = new PhoneBookRepository(_db);
        }

        public IEntryRepository Entry { get; private set; }
        public IPhoneBookRepository PhoneBook { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
