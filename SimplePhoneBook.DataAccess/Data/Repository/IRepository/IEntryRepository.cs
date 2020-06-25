using SimplePhoneBook.Models;

using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePhoneBook.DataAccess.Data.Repository.IRepository
{
    public interface IEntryRepository : IRepository<Entry>
    {
        IEnumerable<SelectListItem> GetEntryListForDropDown();

        void Update(Entry entry);
    }
}
