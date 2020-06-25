using SimplePhoneBook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePhoneBook.DataAccess.Data.Repository.IRepository
{
    public interface IPhoneBookRepository : IRepository<PhoneBook>
    {
        //method
        IEnumerable<SelectListItem> GetPhoneBookListForDropDown();

        //method
        void Update(PhoneBook phonebook);

    }
}
