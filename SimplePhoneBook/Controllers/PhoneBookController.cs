using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SimplePhoneBook.DataAccess.Data.Repository.IRepository;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimplePhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PhoneBookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.PhoneBook.GetAll() });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.PhoneBook.GetFirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "ERROR while deleting" });
            }
            _unitOfWork.PhoneBook.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
