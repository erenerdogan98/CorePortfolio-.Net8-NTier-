using Microsoft.AspNetCore.Mvc;
using Portfolio.BLL.Abstract;
using Portfolio.DTO;

namespace Portfolio.UI.Controllers
{
    [Route("{controller}")]
    public class ContactController(IContactService contactService) : Controller
    {
        [HttpGet("get-contacts")]
        public async Task<IActionResult> GetContacts()
        {
            var values = await contactService.TGetAllAsync();
            //if (!values.Any())
            //    return NotFound("There is no Contact");
            return View(values);
        }

        [HttpGet("add-contact")]
        public IActionResult AddContact()
        {
            return View();
        } 

        [HttpPost("add-contact")]
        public async Task<IActionResult> AddContact(ContactDTO contactDTO)
        {
            // later add this , only 1 contact could add.
            await contactService.TAddAsync(contactDTO);
            return RedirectToAction("GetContacts");
        }
        [HttpGet("update-contact/{id}")]
        public IActionResult UpdateContact(int id)
        {
            var value = contactService.TGetById(id);
            if (value is null)
                return NotFound($" Not Found! with id: {id}");
            return View(value);
        }
        [HttpPost("update-contact")]
        public IActionResult UpdateFeature(ContactDTO contactDTO)
        {
            contactService.TUpdate(contactDTO);
            return RedirectToAction("GetContacts");
        }
        [HttpGet("delete-contact/{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var value = contactService.TGetById(id);
            if (value is null)
                return NotFound($" Not Found! with id: {id}");
            await contactService.TDeleteAsync(value);
            return RedirectToAction("GetContacts");
        }
    }
}
