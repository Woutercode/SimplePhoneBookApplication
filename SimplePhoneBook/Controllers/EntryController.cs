using SimplePhoneBook.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace SimplePhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EntryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.Entry.GetAll() });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Entry.GetFirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success=false, message="ERROR while deleting."});
            }
            _unitOfWork.Entry.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Entry deleted successful." });
        }
    }
}
