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
    public class PhoneBookRepository : Repository<PhoneBook>, IPhoneBookRepository
    {
        private readonly ApplicationDbContext _db;

        public PhoneBookRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetPhoneBookListForDropDown()
        {
            return _db.PhoneBook.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(PhoneBook phonebook)
        {
            var objFromDb = _db.PhoneBook.FirstOrDefault(s => s.Id == phonebook.Id);

            objFromDb.Name = phonebook.Name;

            _db.SaveChanges();
        }
    }
}
