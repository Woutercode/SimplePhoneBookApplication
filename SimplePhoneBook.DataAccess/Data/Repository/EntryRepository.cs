using SimplePhoneBook.DataAccess.Data.Repository.IRepository;
using SimplePhoneBook.Models;

using SimplePhoneBook.DataAccess;

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplePhoneBook.DataAccess.Data.Repository
{
    public class EntryRepository : Repository<Entry>, IEntryRepository
    {
        private readonly ApplicationDbContext _db;

        public EntryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetEntryListForDropDown()
        {
            return _db.Entry.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Entry entry)
        {
            var objFromDb = _db.Entry.FirstOrDefault(s => s.Id == entry.Id);

            objFromDb.Name = entry.Name;
            objFromDb.PhoneNumber = entry.PhoneNumber;

            _db.SaveChanges();

        }
    }



}
