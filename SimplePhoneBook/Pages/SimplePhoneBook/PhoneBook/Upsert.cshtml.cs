using SimplePhoneBook.DataAccess.Data.Repository;
using SimplePhoneBook.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimplePhoneBook.Pages.SimplePhoneBook.PhoneBook
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.PhoneBook PhoneBookObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            PhoneBookObj = new Models.PhoneBook();
            if (id != null)
            {
                PhoneBookObj = _unitOfWork.PhoneBook.GetFirstOrDefault(u => u.Id == id);
                if (PhoneBookObj == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (PhoneBookObj.Id == 0)
            {
                _unitOfWork.PhoneBook.Add(PhoneBookObj);
            }
            else
            {
                _unitOfWork.PhoneBook.Update(PhoneBookObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}