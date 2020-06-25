using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haloda.DataAccess.Data.Repository;
using Haloda.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SimplePhoneBook.Pages.Admin.Category
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //BindProperty attribute binds property, so developer does not need haloda.models.Category in OnPost Parameter
        [BindProperty]
        public Haloda.Models.Category CategoryObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            CategoryObj = new Haloda.Models.Category();
            if (id != null)
            {
                CategoryObj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
                if (CategoryObj == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        //to update to database for categoryObj
        public IActionResult OnPost()// No need to define parameter/CategoryObj in OnPost due to bindproperty
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(CategoryObj.Id == 0)
            {
                _unitOfWork.Category.Add(CategoryObj);
            }
            else
            {
                _unitOfWork.Category.Update(CategoryObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}