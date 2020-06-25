using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haloda.DataAccess.Data.Repository;
using Haloda.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SimplePhoneBook.Pages.Admin.ProductType
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Haloda.Models.ProductType ProductTypeObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            ProductTypeObj = new Haloda.Models.ProductType();
            //check to make sure is is not nul and if it is then use GetFirstOrDefault
            if (id != null)
            {
                ProductTypeObj = _unitOfWork.ProductType.GetFirstOrDefault(u => u.Id == id);
                if (ProductTypeObj == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        //make use of bindproperty on line 22 then no need to define inside OnPost Handler (Haloda.Models.ProductType ProductTypeObj)
        public IActionResult OnPost(Haloda.Models.ProductType ProductTypeObj) //or else add above without using BindPropery
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (ProductTypeObj.Id == 0)
            {
                _unitOfWork.ProductType.Add(ProductTypeObj);
            }
            else
            {
                _unitOfWork.ProductType.Update(ProductTypeObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}