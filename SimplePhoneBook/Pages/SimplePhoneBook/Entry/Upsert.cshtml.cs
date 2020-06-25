using SimplePhoneBook.DataAccess.Data.Repository;
using SimplePhoneBook.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimplePhoneBook.Pages.SimplePhoneBook.Entry
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [BindProperty]
        public Models.Entry EntryObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            EntryObj = new Models.Entry();
            if (id != null)
            {
                EntryObj = _unitOfWork.Entry.GetFirstOrDefault(u => u.Id == id);
                if (EntryObj == null)
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
            if(EntryObj.Id == 0)
            {
                _unitOfWork.Entry.Add(EntryObj);
            }
            else
            {
                _unitOfWork.Entry.Update(EntryObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}